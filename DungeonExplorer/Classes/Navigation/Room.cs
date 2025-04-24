namespace DungeonExplorer
{
    public class Room : IHelper, IHealthValidation
    {
        // Public variables
        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        /// 
        /// <remarks>
        /// Represents the name or identifier assigned to a specific room within the dungeon.
        /// This property is used to track and display the room's unique identity throughout the gameplay.
        /// </remarks>
        public string RoomName { get; set; }

        public Room(string roomName)
        {
            RoomName = roomName;
        }
        
        /// <summary>
        /// Generates enemy in the room.
        /// </summary>
        ///
        /// <returns>
        /// Returns either a generated monster or null, in case no monsters have been created.
        /// </returns>
        public Monster GenerateRoomEnemy()
        {
            // Case where, generation is successful
            if (IHelper.GenerateRandom() <= 7) return Monster.SelectMonster();
            
            // Unsuccessful case
            else return null;
        }

        /// <summary>
        /// Generates item in the room.
        /// </summary>
        /// 
        /// <returns>
        /// Returns either a generated item or null, in case no items have been created.
        /// </returns>
        public Item GenerateRoomItems()
        {
            // Case where, generation is successful
            if (IHelper.GenerateRandom() <= 7) return Item.SelectItem();
            
            // Unsuccessful case
            else return null;
        }

        /// <summary>
        /// Generates puzzles for the room, providing challenges to the player.
        /// The type of puzzle is determined randomly.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player attempting the puzzle. The result of the challenge may impact the player's health.
        /// </param>
        public void GenerateRoomPuzzles(Player player)
        {
            if (IHelper.GenerateRandom() <= 5) RoomPattern(player);
            else RoomMath(player);
        }

        /// <summary>
        /// Handles the pattern recognition challenge in the room.
        /// The player must identify the next number in a given sequence.
        /// Failing to do so results in health loss.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player attempting the pattern recognition challenge.
        /// The player's health is impacted based on their success or failure.
        /// </param>
        private protected void RoomPattern(Player player)
        {
            // Message
            IHelper.DisplayMessage("\nYou need to recognise patterns in the room." +
                                   "\nOtherwise, you lose your health." +
                                   "\nEnter the next number in the sequence:");
            
            // Pattern
            int[] pattern = new[] { 0, 1, 1, 2, 3, 5 };

            // Exception handling
            try
            {
                while (true)
                {
                    // Input
                    int input = int.Parse(Console.ReadLine());
                
                    // Validation
                    if (input == 8)
                    {
                        // Message
                        IHelper.DisplayMessage("\nCorrect!" +
                                               $"\nYou have {player.CreatureHealth} health left.");
                        
                        break;
                    }

                    // Unsuccessful case
                    else
                    {
                        // Manages player's health parameter
                        IHealthValidation.HealthValidation(player);
                        player.CreatureHealth -= 10;
                        
                        // Message
                        IHelper.DisplayMessage("\nIncorrect!" +
                                               $"\nYou have {player.CreatureHealth} health left.");
                    }
                }
            }
            
            catch (Exception)
            {
                IHelper.DisplayMessage("Invalid input. Enter integers instead.");
            }
        }

        /// <summary>
        /// Handles a math-based challenge within the room, requiring the player to solve a problem.
        /// Failure results in a health penalty for the player.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player instance engaging in the math challenge.
        /// </param>
        private protected void RoomMath(Player player)
        {
            // Message
            IHelper.DisplayMessage("\nYou need to solve math problems in the room." +
                                   "\nOtherwise, you lose your health." +
                                   "\n\n4x = 8" +
                                   "\nSolve for x: ");

            // Exception handling
            try
            {
                while (true)
                {
                    // Input
                    int input = int.Parse(Console.ReadLine());
                
                    // Validation
                    if (input == 2)
                    {
                        // Message
                        IHelper.DisplayMessage("\nCorrect!" +
                                               $"\nYou have {player.CreatureHealth} health left.\n");
                        
                        break;
                    }

                    // Unsuccessful case
                    else
                    {
                        // Manages player's health parameter
                        IHealthValidation.HealthValidation(player);
                        player.CreatureHealth -= 10;
                        
                        // Message
                        IHelper.DisplayMessage("\nIncorrect!" +
                                               $"\nYou have {player.CreatureHealth} health left.\n");
                    }
                }
            }
            
            catch (Exception)
            {
                IHelper.DisplayMessage("\nInvalid input. Enter integers instead.");
            }
        }
    }
}