namespace DungeonExplorer
{
    public class Fight : IHelper
    {
        private static bool PlayerShieldFlag;
        private static bool PlayerRunFlag;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="currentRoom"></param>
        public static void FightEncounter(Creature player, Rooms currentRoom)
        {
            // Generates the enemy
            Monsters roomMonster = currentRoom.GenerateRoomEnemy();
            
            // If there is an enemy, then start combat
            if (roomMonster != null)
            {
                // Appearance message
                IHelper.DisplayMessage($"{roomMonster.CreatureName} appeared!");
                
                // Confirming the action
                Story.ConfirmationMessage();
                
                // Fighting system itself
                while (true || PlayerRunFlag is false)
                {
                    // Checks the monster's health
                    if (roomMonster.CreatureHealth <= 0)
                    {
                        IHelper.DisplayMessage($"{roomMonster.CreatureName} has been killed lol");
                        break;
                    }
                    
                    // Checks player's health
                    else if (player.CreatureHealth <= 0)
                    {
                        break;
                    }

                    // Case of the actual fight, when neither of the creatures are dead
                    else
                    {
                        // Player's turn
                        PlayerTurn(player, roomMonster);
                        
                        // Monster's turn
                    }
                }
            }
            
            // Case, when enemy hasn't been generated
            else
            {
                IHelper.DisplayMessage("There is no enemy, lucky you!\n \n".ToUpper());
            }
        }

        /// <summary>
        /// Fight turn that player is taking.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player's entity that is passed to the method in order to link player's data.
        /// </param>
        /// 
        /// <param name="target">
        /// Target enemy that is supposed to be damaged
        /// </param>
        private static void PlayerTurn(Creature player, Creature target)
        {
            // Entrance message
            IHelper.DisplayMessage($"\n{player.CreatureName}'s turn\n" +
                                   "Press Enter to continue...");
            Console.ReadLine();
            
            // Selection menu for the player's actions
            IHelper.DisplayMessage("1 | Damage\n" +
                                   "2 | Shield\n" +
                                   "3 | Attempt to run\n");
            
            // Selection loop
            while (true)
            {
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
                         * Trying luck, if the resultant number exceeds in the threshold of 5,
                         * the user will successfully reduce next enemy's attack by 20.
                         */

                        if (IHelper.GenerateRandom() + player.CreatureLuck >= 5)
                        {
                            PlayerShieldFlag = true;
                            IHelper.DisplayMessage($"{player.CreatureName} has been shielded!\n");
                        }

                        // Unsuccessful shielding
                        else
                        {
                            PlayerShieldFlag = false;
                            IHelper.DisplayMessage($"{player.CreatureName}'s shielding was unlucky.\n");
                        }

                        break;
                    }

                    // Attempt to run from a fight
                    else if (userInput == "3")
                    { 
                        /*
                         * Trying luck by generating a random number, plus adding a luck multiplier.
                         * If the resultant number exceeds certain threshold, then the run is successful.
                         * Otherwise, player stays in the fight.
                         */

                        if (IHelper.GenerateRandom() + player.CreatureLuck >= 7)
                        {
                            // Setting flag to true, so player can run away
                            PlayerRunFlag = true;
                            IHelper.DisplayMessage($"{player.CreatureName} has managed to run away!\n");

                            // Make sure the enemy is dead and new enemy can be generated later.
                            target.CreatureHealth = 0;

                            break;
                        }

                        // Case, where the attempt is unsuccessful and we are still in the fight
                        else
                        {
                            // Setting flag to false, so player stays in the fight loop
                            PlayerRunFlag = false;
                            IHelper.DisplayMessage("No can do baby doll, you are staying here.\n");

                            break;
                        }
                    }
                }
                
                // When wrong input is given
                catch (Exception e)
                {
                    IHelper.DisplayMessage("\nOnly ints are allowed!");
                }
            }
        }
    }
}