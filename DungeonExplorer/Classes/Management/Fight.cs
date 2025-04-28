namespace DungeonExplorer
{
    public class Fight : IHealable, IHealthValidation
    {
        private static bool PlayerShieldFlag { get; set; }
        private static bool PlayerRunFlag { get; set; }
        
        /// <summary>
        /// The fight system of this game. Handles all the aspects of in-game AI, as well as user actions.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player's entity that is passed to the method to link player's data.
        /// </param>
        /// 
        /// <param name="currentRoom">
        /// Room, where the fight is taking place.
        /// </param>
        public static void FightEncounter(Player player, Room currentRoom)
        {
            // Generates the enemy
            Monster roomMonster = currentRoom.GenerateRoomEnemy();
            
            // If there is an enemy, then start combat
            if (roomMonster != null)
            {
                // Appearance message
                IHelper.DisplayMessage($"\n{roomMonster.CreatureName} has appeared!");
                
                // Confirming the action
                Story.ConfirmationMessage();
                
                // The fighting system itself
                while (true)
                {
                    // Checks the player's health
                    // Validators
                    IHealthValidation.HealthValidation(player);
                    
                    // Checks the monster's health
                    if (roomMonster.CreatureHealth <= 0)
                    {
                        roomMonster.CreatureHealth = 0;
                        IHelper.DisplayMessage($"\n{roomMonster.CreatureName} has been killed lol");
                        break;
                    }

                    // Case of the actual fight, when neither is dead
                    else
                    {
                        // Player's turn
                        Turn(player, roomMonster);

                        // Checking whether a run is possible, in case the player triggers it
                        if (PlayerRunFlag) break;
                        
                        // Monster's turn, when unique attacks are implemented. Allows for more dynamic AI.
                        if (roomMonster is Monster monster) monster.UniqueAttackBehavior(player);
                        
                        // Fallback case, when stuff doesn't work out
                        else IDamagable.Damage(roomMonster, player);
                    }
                }
            }
            
            // Case, when the enemy hasn't been generated
            else IHelper.DisplayMessage("There is no enemy, lucky you!\n \n");
        }

        /// <summary>
        /// Fight turn that player is taking.
        /// Allows for static polymorphism.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player's entity that is passed to the method to link player's data.
        /// </param>
        /// 
        /// <param name="target">
        /// The target enemy that is supposed to be damaged
        /// </param>
        private static void Turn(Creature player, Creature target)
        {
            // Entrance message
            IHelper.DisplayMessage($"\n{player.CreatureName}'s turn\n" +
                                   "Press Enter to continue...");
            Console.ReadLine();
            
            // Selection menu for the player's actions
            IHelper.DisplayMessage("\n1 | Damage\n" +
                                   "2 | Shield\n" +
                                   "3 | Attempt to run\n \n");
            
            // Selection loop
            while (true)
            {
                // Taking user's input
                string userInput = Console.ReadLine();
                
                try
                {
                    // Case, where the player chooses to damage
                    if (userInput == "1")
                    {
                        IDamagable.Damage(player, target);
                        break;
                    }

                    // Case, when shield is used
                    else if (userInput == "2")
                    { 
                        /*
                         * Trying luck, if the resultant number exceeds the threshold of 5,
                         * the user will successfully reduce the damage intake by 10.
                         */

                        if (IHelper.GenerateRandom() + player.CreatureLuck >= 5)
                        {
                            IHelper.DisplayMessage($"\n{player.CreatureName} has been shielded!");
                            PlayerShieldFlag = true;
                        }

                        // Unsuccessful shielding
                        else
                        {
                            IHelper.DisplayMessage($"\n{player.CreatureName}'s shielding was unlucky.");
                            PlayerShieldFlag = false;
                        }

                        break;
                    }

                    // Attempt to run from a fight
                    else if (userInput == "3")
                    { 
                        /*
                         * Trying luck by generating a random number, plus adding a luck multiplier.
                         * If the resultant number exceeds a certain threshold, then the run is successful.
                         * Otherwise, the player stays in the fight.
                         */

                        if (IHelper.GenerateRandom() + player.CreatureLuck >= 7)
                        {
                            // Setting a flag to true, so the player can run away
                            PlayerRunFlag = true;
                            IHelper.DisplayMessage($"\n{player.CreatureName} has managed to run away!");

                            // Make sure the enemy is dead, and the new enemy can be generated later.
                            target.CreatureHealth = 0;
                            
                            // Return the flag
                            PlayerRunFlag = false;

                            break;
                        }

                        // Case, where the attempt is unsuccessful and we are still in the fight
                        else
                        {
                            // Setting a flag to false, so the player stays in the fight loop
                            PlayerRunFlag = false;
                            IHelper.DisplayMessage("\nNo can do baby doll, you are staying here.");

                            break;
                        }
                    }
                }
                
                // When the wrong input is given
                catch (Exception)
                {
                    IHelper.DisplayMessage("\nOnly ints are allowed!\n");
                }
            }
        }
    }
}