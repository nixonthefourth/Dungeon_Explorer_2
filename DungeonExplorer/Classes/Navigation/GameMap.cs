namespace DungeonExplorer
{
    public class GameMap
    {
        /// <summary>
        /// Method for generating rooms.
        /// </summary>
        public void GenerateRooms()
        {
            Room room1 = new Room();
            Room room2 = new Room();
            Room room3 = new Room();
            Room room4 = new Room();
            Room room5 = new Room();
            Room room6 = new Room();
            Room room7 = new Room();
        }

        /// <summary>
        /// Method for executing the room.
        /// </summary>
        /// 
        /// <param name="currentRoom">
        /// Passes the room that is currently being executed.
        /// </param>
        public void ExecuteRoom(Room currentRoom, Player player, Inventory inventory)
        {
            // Getting room's description
            Story.GetRoomDescription();
            
            // Execution loop
            Menu.RoomMenu(player, currentRoom, inventory);
        }

        public static void NextRoom()
        {
            
        }
        
        public static void PreviousRoom()
        {
            
        }
    }
}