namespace DungeonExplorer
{
    public class Menu
    {
        // Public variables
        
        /// <summary>
        /// Displays the inventory menu and handles user interactions for inventory management.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player interacting with the inventory menu.
        /// </param>
        /// 
        /// <param name="inventory">
        /// The inventory that is being managed.
        /// </param>
        /// 
        /// <remarks>
        /// Provides various options including displaying the inventory, removing an item, activating an item,
        /// sorting weapons, or exiting the menu. Validates user input and ensures proper option handling.
        /// Displays a message in case of invalid input.
        /// </remarks>
        public static void InventoryMenu(Player player, Inventory inventory)
        {
            IHelper.DisplayMessage("\nInventory menu:" +
                                   "\n1 | Display inventory" +
                                   "\n2 | Remove item" +
                                   "\n3 | Activate the item" +
                                   "\n4 | Sort weapons" +
                                   "\n5 | Exit");

            // Input validation
            try
            {
                // Selection loop for the inventory
                while (true)
                {
                    // Collecting input
                    IHelper.DisplayMessage("\nPlease enter the desired action from the list: ");
                    int menuAction = int.Parse(Console.ReadLine());
                    
                    // Choosing options
                    // Display inventory option
                    if (menuAction == 1) inventory.DisplayInventory();
                    
                    // Remove the item option
                    else if (menuAction == 2)
                    {
                        string itemName;
                        
                        // Input validation
                        while (true)
                        {
                            // Item input
                            IHelper.DisplayMessage("\nPlease enter the name of the item you want to remove: ");
                            itemName = Console.ReadLine();
                            
                            // Input validation
                            if (itemName.Length == 0 || itemName == "" || itemName == " ")
                            {
                                IHelper.DisplayMessage("\nInvalid input.");
                            }
                
                            // Successful case
                            else break;
                        }
                        
                        // Item is removed
                        inventory.RemoveItem(itemName);
                    }
                    
                    // Item is getting actively selected
                    else if (menuAction == 3)
                    {
                        string itemName;
                        
                        // Input validation
                        while (true)
                        {
                            // Item input
                            IHelper.DisplayMessage("\nPlease enter the name of the item you want to select: ");
                            itemName = Console.ReadLine();
                            
                            // Input validation
                            if (itemName.Length == 0 || itemName == "" || itemName == " ")
                            {
                                IHelper.DisplayMessage("\nInvalid input.");
                            }
                
                            // Successful case
                            else break;
                        }
                        
                        // Item is selected
                        inventory.SelectItem(player);
                    }
                    
                    // Sorting weapons option
                    else if (menuAction == 4)
                    {
                        inventory.SortWeaponsByDamageDescending();
                        inventory.DisplayInventory();
                        
                        Story.ConfirmationMessage();
                    }
                    
                    // Break option
                    else if (menuAction == 5)
                    {
                        break;
                    }
                }
            }
            
            catch (Exception)
            {
                IHelper.DisplayMessage("\nInvalid input. Only ints are allowed.");
            }
        }

        /// <summary>
        /// Displays the room menu and manages user interactions for room navigation, combat,
        /// item search, and inventory management.
        /// </summary>
        /// <param name="player">
        /// The player interacting within the current room.
        /// </param>
        /// 
        /// <param name="currentRoom">
        /// The current room being explored by the player.
        /// </param>
        /// 
        /// <param name="inventory">
        /// The player's inventory available for management.
        /// </param>
        /// 
        /// <remarks>
        /// Provides several actions, including navigating to the previous or next room, engaging
        /// in combat with monsters, searching the room for items, and accessing the inventory menu.
        /// Includes input validation and an appropriate handling of invalid user selections.
        /// </remarks>
        public static void RoomMenu(Player player, Inventory inventory)
        {
            // Run the puzzle sequence
            if (GameMap.currentRoom.RoomName == "Room 3" || GameMap.currentRoom.RoomName == "Room 4" || GameMap.currentRoom.RoomName == "Room 6")
            {
                GameMap.currentRoom.GenerateRoomPuzzles(player);
            }
            
            // Displaying player's status
            IHelper.DisplayMessage($"\n{player.CreatureName} is in {GameMap.currentRoom.RoomName}." +
                                   $"\nHealth: {player.CreatureHealth}" +
                                   $"\nDamage: {player.CreatureDamage}" +
                                   $"\nLuck: {player.CreatureLuck}");
            
            // Displaying menu
            IHelper.DisplayMessage("\n\nGame actions:" +
                                   "\n1 | Previous room" +
                                   "\n2 | Next room" +
                                   "\n3 | Fight" +
                                   "\n4 | Look for items" +
                                   "\n5 | Manage inventory" +
                                   "\n6 | Get room description" +
                                   "\n7 | Display statistics");

            // Input validation
            try
            {
                // Selection loop for the room menu
                while (true)
                {
                    Item roomItem = null;
                    
                    // Collecting input
                    IHelper.DisplayMessage("\n\nPlease enter the desired action from the list: ");
                    int menuAction = int.Parse(Console.ReadLine());
                    
                    // Choosing options
                    // Previous room option
                    if (menuAction == 1)
                    {
                        // Checking if the player is in the first room
                        // If not, the player is moved back to the previous room.
                        if (GameMap.currentRoom.RoomName != "Room 1")
                        {
                            IHelper.DisplayMessage("\nMoving back to the previous room...");
                            GameMap.PreviousRoom();
                        }

                        // Unsuccessful case for the room movement
                        else IHelper.DisplayMessage("\nYou are already in the first room.");

                        break;
                    }
                    
                    // Next room option
                    else if (menuAction == 2)
                    {
                        IHelper.DisplayMessage("\nMoving to the next room...");
                        GameMap.NextRoom();
                        
                        // The counter increases
                        Statistics.RoomsCleared++;
                        
                        break;
                    }
                    
                    
                    
                    // Fight option
                    else if (menuAction == 3 && GameMap.currentRoom.MonsterCounter <= 2)
                    {
                        IHelper.DisplayMessage($"\n{player.CreatureName} decides to fight.");
                        Fight.FightEncounter(player, GameMap.currentRoom);
                        
                        // The counter increases
                        Statistics.EnemiesKilled++;
                        
                        // The counter increases
                        GameMap.currentRoom.MonsterCounter++;
                        
                        // Increase the statistics parameter
                        player.PlayerStatsUpgrade(player);
                        
                        break;
                    }
                    
                    // Option, where the player looks for the items
                    else if (menuAction == 4 && GameMap.currentRoom.ItemCounter == 0)
                    {
                        // Item is generated
                        roomItem = GameMap.currentRoom.GenerateRoomItems();

                        // Item is found
                        if (roomItem != null)
                        {
                            IHelper.DisplayMessage("\nYou found an item!");
                        
                            // Item is added to the inventory
                            inventory.AddItem(roomItem);
                            
                            // The counter increases
                            Statistics.ItemsCollected++;
                        
                            // The counter increases
                            GameMap.currentRoom.ItemCounter++;
                        }
                        
                        // If the item wasn't found
                        else IHelper.DisplayMessage("\nYou didn't find any items.");
                        
                        break;
                    }
                    
                    // Option, where the item search is unsuccessful
                    else if (menuAction == 4 && GameMap.currentRoom.ItemCounter != 0)
                    {
                        IHelper.DisplayMessage("\nItems are already found in this room!");
                    }
                    
                    // Option, where the player manages the inventory
                    else if (menuAction == 5)
                    {
                        // Calling confirmation message
                        Story.ConfirmationMessage();
                        
                        // Inventory management system
                        InventoryMenu(player, inventory);
                        
                        break;
                    }
                    
                    // Option, where the user gets a description
                    else if (menuAction == 6)
                    {
                        Story.GetRoomDescription();
                        
                        Story.ConfirmationMessage();
                        
                        break;
                    }
                    
                    // Statistics display option
                    else if (menuAction == 7)
                    {
                        Statistics.DisplayStatistics();
                        
                        Story.ConfirmationMessage();
                        
                        break;
                    }
                }
            }
            
            catch (Exception)
            {
                IHelper.DisplayMessage("\nInvalid input. Only ints are allowed.");
            }
        }
    }
}