namespace DungeonExplorer
{
    public class Fight : IHelper
    {
        private static bool _playerShieldFlag = false;
        private static bool _playerRunFlag = false;
        
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
        public static void FightEncounter(Creature player, Rooms currentRoom)
        {
            // Generates the enemy
            Monsters roomMonster = currentRoom.GenerateRoomEnemy();
            
            // If there is an enemy, then start combat
            if (roomMonster != null)
            {
                // Appearance message
                IHelper.DisplayMessage($"\n{roomMonster.CreatureName} has appeared!");
                
                // Confirming the action
                Story.ConfirmationMessage();
                
                // The fighting system itself
                while (true || _playerRunFlag is false)
                {
                    // Checks the monster's health
                    if (roomMonster.CreatureHealth <= 0)
                    {
                        IHelper.DisplayMessage($"\n{roomMonster.CreatureName} has been killed lol");
                        break;
                    }
                    
                    // Checks player's health
                    else if (player.CreatureHealth <= 0)
                    {
                        HealthValidation(player);
                        break;
                    }

                    // Case of the actual fight, when neither is dead
                    else
                    {
                        // Player's turn
                        PlayerTurn(player, roomMonster);
                        
                        // Monster's turn
                        MonsterTurn(roomMonster, player);
                    }
                }
            }
            
            // Case, when the enemy hasn't been generated
            else
            {
                IHelper.DisplayMessage("There is no enemy, lucky you!\n \n");
            }
        }

        /// <summary>
        /// Fight turn that player is taking.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player's entity that is passed to the method to link player's data.
        /// </param>
        /// 
        /// <param name="target">
        /// The target enemy that is supposed to be damaged
        /// </param>
        private static void PlayerTurn(Creature player, Creature target)
        {
            // Entrance message
            IHelper.DisplayMessage($"\n{player.CreatureName}'s turn\n" +
                                   "Press Enter to continue...");
            Console.ReadLine();
            
            // Selection menu for the player's actions
            IHelper.DisplayMessage("\n1 | Damage\n" +
                                   "2 | Shield\n" +
                                   "3 | Attempt to run\n");
            
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
                            _playerShieldFlag = true;
                        }

                        // Unsuccessful shielding
                        else
                        {
                            IHelper.DisplayMessage($"\n{player.CreatureName}'s shielding was unlucky.");
                            _playerShieldFlag = false;
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
                            _playerRunFlag = true;
                            IHelper.DisplayMessage($"\n{player.CreatureName} has managed to run away!");

                            // Make sure the enemy is dead, and the new enemy can be generated later.
                            target.CreatureHealth = 0;

                            break;
                        }

                        // Case, where the attempt is unsuccessful and we are still in the fight
                        else
                        {
                            // Setting a flag to false, so the player stays in the fight loop
                            _playerRunFlag = false;
                            IHelper.DisplayMessage("\nNo can do baby doll, you are staying here.");

                            break;
                        }
                    }
                }
                
                // When the wrong input is given
                catch (Exception)
                {
                    IHelper.DisplayMessage("\n\nOnly ints are allowed!");
                }
            }
        }

        /// <summary>
        /// Executes the monster's turn during a fight encounter.
        /// Handles actionable AI for the monster and determines its attack behavior
        /// based on the player's status and the monster's attributes.
        /// </summary>
        /// 
        /// <param name="monster">
        /// The monster object engaged in the fight, representing its stats and actions.
        /// </param>
        /// 
        /// <param name="target">
        /// The target of the monster's attack.
        /// </param>
        private static void MonsterTurn(Creature monster, Creature target)
        {
            // Entrance message
            IHelper.DisplayMessage($"\n{monster.CreatureName}'s turn\n" +
                                   "Press Enter to continue...");
            
            Console.ReadLine();
            
            // Monster's actionable AI
            // Regular case
            try
            {
                /*
                 * Checks whether the player had run away.
                 * In case the player doesn't manage to do so – monster attacks.
                 */
                
                if (_playerRunFlag is false)
                {
                    // Enemy damages, if this case mathematically is less or equal to 7
                    if (IHelper.GenerateRandom() + monster.CreatureLuck <= 7)
                    {
                        // Checking the shield mechanic
                        if (_playerShieldFlag)
                        {
                            // Decreasing damage and then creature would be dealing it
                            monster.CreatureDamage -= 10;
                            IDamagable.Damage(monster, target);
                            
                            // Returning creature's damage, so it doesn't change permanently
                            monster.CreatureDamage += 10;
                        }
                        
                        // If shielding was unsuccessful
                        else
                        {
                            // Dealing regular damage
                            IDamagable.Damage(monster, target);
                        }
                    }
                }
            }
            
            // Erroneous case
            catch (Exception)
            {
                IHelper.DisplayMessage("\n\nAn error has occured!");
            }
        }
        
        /// <summary>
        /// We are validating the health of the player to check whether the player is dead or alive.
        /// In case of going below 0 health-wise, we are making it equal to 0, so bugs are prevented.
        /// And then the player is killed.
        /// </summary>
        private static void HealthValidation(Creature player)
        {
            if (player.CreatureHealth <= 0)
            {
                player.CreatureHealth = 0;
                Story.LoseAdventure();
            }
        }
    }
}