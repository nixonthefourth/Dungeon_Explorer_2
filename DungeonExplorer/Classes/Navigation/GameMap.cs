namespace DungeonExplorer
{
    public class GameMap
    {
        /// <summary>
        /// First room.
        /// </summary>
        public static Room room1;

        /// <summary>
        /// Second room.
        /// </summary>
        public static Room room2;

        /// <summary>
        /// Third room.
        /// </summary>
        public static Room room3;

        /// <summary>
        /// Fourth room.
        /// </summary>
        public static Room room4;

        /// <summary>
        /// Fifth room.
        /// </summary>
        public static Room room5;

        /// <summary>
        /// Sixth room.
        /// </summary>
        public static Room room6;

        /// <summary>
        /// Seventh room.
        /// </summary>
        public static Room room7;
        
        /// <summary>
        /// Eighth room, where magic finishes.
        /// </summary>
        public static Room room8;

        /// <summary>
        /// The room that the player is currently in the game.
        /// </summary>
        public static Room currentRoom;

        /// <summary>
        /// Method for generating rooms.
        /// </summary>
        ///
        /// <returns>
        /// Returns the current room.
        /// </returns>
        public Room GenerateRooms()
        {
            // Generating rooms
            room1 = new Room("Room 1", 0, 0);
            room2 = new Room("Room 2", 0, 0);
            room3 = new Room("Room 3", 0, 0);
            room4 = new Room("Room 4", 0, 0);
            room5 = new Room("Room 5", 0, 0);
            room6 = new Room("Room 6", 0, 0);
            room7 = new Room("Room 7", 0, 0);
            room8 = new Room("Room 8", 0, 0);
            
            // Setting the first room as the current room
            currentRoom = room1;
            
            return currentRoom;
        }

        /// <summary>
        /// Method for executing the room.
        /// If the player reaches the end of the game, the game is won.
        /// Measured in the room count. Room 7 is the end of the game.
        /// </summary>
        ///
        /// <param name="player">
        /// Passes the player object.
        /// </param>
        ///
        /// <param name="inventory">
        /// Passes the inventory object.
        /// </param>
        public void ExecuteRoom(Player player, Inventory inventory)
        {
            // Execution loop
            Menu.RoomMenu(player, inventory);
            
            // Winning condition
            if (currentRoom == room8) Story.WinAdventure();
        }

        /// <summary>
        /// Updates the current room to the next sequential room in the game map.
        /// </summary>
        /// 
        /// <param name="currentRoom">
        /// The current room that the player is in. This will be updated to the next room.
        /// </param>
        public static void NextRoom()
        {
            // Switching rooms
            if (currentRoom == room1) currentRoom = room2;
            else if (currentRoom == room2) currentRoom = room3;
            else if (currentRoom == room3) currentRoom = room4;
            else if (currentRoom == room4) currentRoom = room5;
            else if (currentRoom == room5) currentRoom = room6;
            else if (currentRoom == room6) currentRoom = room7;
            else if (currentRoom == room7) currentRoom = room8;

        }

        /// <summary>
        /// Moves the player to the previous room in the sequence.
        /// </summary>
        /// 
        /// <param name="currentRoom">
        /// The room the player is currently in, which will be updated to the previous room.
        /// </param>
        public static void PreviousRoom()
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