namespace DungeonExplorer
{
    public class Fight : IHelper
    {
        public static void FightEncounter(Creature player, Rooms currentRoom)
        {
            // Generates the enemy
            Monsters roomMonster = currentRoom.GenerateRoomEnemy();
            
            // If there is an enemy, then start combat
            if (roomMonster != null)
            {
                // Appearance message
                IHelper.DisplayMessage($"{roomMonster} appeared!");
                
                // Confirming the action
                Story.ConfirmationMessage();
                
                // Fighting system itself
                while (true)
                {
                    // Checks the monster's health
                    if (roomMonster.CreatureHealth <= 0)
                    {
                        IHelper.DisplayMessage($"{roomMonster} has been killed lol");
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

        private void PlayerTurn(Creature player, Creature target)
        {
            // Entrance message
            IHelper.DisplayMessage($"{player.CreatureName}'s turn\n" +
                                   "Press Enter to continue...");
            Console.ReadLine();
            
            // Selection menu for the player's actions
            IHelper.DisplayMessage("1 | Damage\n" +
                                   "2 | Shield\n" +
                                   "3 | Attempt to run");
            
        }
    }
}