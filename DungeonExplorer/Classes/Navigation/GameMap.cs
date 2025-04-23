namespace DungeonExplorer
{
    public class GameMap
    {
        static Room room1;
        static Room room2;
        static Room room3;
        static Room room4;
        static Room room5;
        static Room room6;
        static Room room7;
        
        /// <summary>
        /// Method for generating rooms.
        /// </summary>
        public void GenerateRooms()
        {
            Room room1 = new Room("Room 1");
            Room room2 = new Room("Room 2");
            Room room3 = new Room("Room 3");
            Room room4 = new Room("Room 4");
            Room room5 = new Room("Room 5");
            Room room6 = new Room("Room 6");
            Room room7 = new Room("Room 7");
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

        /// <summary>
        /// Updates the current room to the next sequential room in the game map.
        /// </summary>
        /// 
        /// <param name="currentRoom">
        /// The current room that the player is in. This will be updated to the next room.
        /// </param>
        public static void NextRoom(Room currentRoom)
        {
            // Switching rooms
            if (currentRoom == room1) currentRoom = room2;
            else if (currentRoom == room2) currentRoom = room3;
            else if (currentRoom == room3) currentRoom = room4;
            else if (currentRoom == room4) currentRoom = room5;
            else if (currentRoom == room5) currentRoom = room6;
            else if (currentRoom == room6) currentRoom = room7;
        }

        /// <summary>
        /// Moves the player to the previous room in the sequence.
        /// </summary>
        /// 
        /// <param name="currentRoom">
        /// The room the player is currently in, which will be updated to the previous room.
        /// </param>
        public static void PreviousRoom(Room currentRoom)
        {
            // Switching rooms
            if (currentRoom == room7) currentRoom = room6;
            else if (currentRoom == room6) currentRoom = room5;
            else if (currentRoom == room5) currentRoom = room4;
            else if (currentRoom == room4) currentRoom = room3;
            else if (currentRoom == room3) currentRoom = room2;
            else if (currentRoom == room2) currentRoom = room1;
        }
    }
}