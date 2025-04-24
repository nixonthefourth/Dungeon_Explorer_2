namespace DungeonExplorer
{
    public class Statistics
    {
        /// <summary>
        /// Gets or sets the total number of enemies defeated by the player.
        /// </summary>
        public static int EnemiesKilled { get; set; }

        /// <summary>
        /// Gets or sets the total number of items gathered by the player.
        /// </summary>
        public static int ItemsCollected { get; set; }

        /// <summary>
        /// Gets or sets the total number of rooms cleared by the player.
        /// </summary>
        public static int RoomsCleared { get; set; }

        /// <summary>
        /// Displays the player's current statistics including the total number of enemies killed,
        /// items collected, and rooms cleared. Utilises the IHelper interface to format and
        /// display the message with a specific visual effect.
        /// </summary>
        public static void DisplayStatistics()
        {
            // Displays user's statistics
            IHelper.DisplayMessage("\nPlayer's Statistics:" +
                                   $"\nEnemies killed: {EnemiesKilled}" +
                                   $"\nItems collected: {ItemsCollected}" +
                                   $"\nRooms cleared: {RoomsCleared}\n");
        }
    }
}