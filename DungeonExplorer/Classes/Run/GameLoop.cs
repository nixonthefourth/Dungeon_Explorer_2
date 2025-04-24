namespace DungeonExplorer

{
    public class GameLoop
    {
        /// <summary>
        /// Running sequence, which will be passed later into the entry point of the program.
        /// Allows for abstraction and encapsulation of the runtime.
        /// </summary>
        public static void Run()
        {
            // Initialising the new player in the game
            Player player = new Player(null, 10, 1, 100);
            
            // Initialising the inventory
            Inventory inventory = new Inventory();
            
            // Runtime
            // Starting story
            Story.StoryStart(player);
            
            // Generating the game map
            GameMap gameMap = new GameMap();
            
            var currentRoom = gameMap.GenerateRooms();
            while (true)
            {
                gameMap.ExecuteRoom(currentRoom, player, inventory);
            }
        }
    }
}