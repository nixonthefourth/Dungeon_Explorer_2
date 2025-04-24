namespace DungeonExplorer
{
    public class Inventory
    {
        /// <summary>
        /// Private collection of items in the inventory.
        /// </summary>
        private List<Item> _items = new List<Item>();
        
        /// <summary>
        /// Maximum number of items the inventory can hold.
        /// </summary>
        private protected const int MaxCapacity = 3;

        /// <summary>
        /// Gets a read-only view of the items in the inventory.
        /// </summary>
        /// 
        /// <returns>
        /// Returns a read-only list of the current inventory items.
        /// </returns>
        public IReadOnlyList<Item> Items => _items.AsReadOnly();

        /// <summary>
        /// Adds an item to the inventory if space is available.
        /// </summary>
        /// 
        /// <param name="item">
        /// The item added to the inventory.
        /// </param>
        /// 
        /// <remarks>
        /// This method will display a message indicating either success or failure.
        /// </remarks>
        public void AddItem(Item item)
        {
            // Case, when the inventory is full
            if (_items.Count >= MaxCapacity) IHelper.DisplayMessage("\nInventory is full!\n");

            // Adds the item to the inventory
            _items.Add(item);
            
            // Message
            IHelper.DisplayMessage($"\n{item.ItemName} added to inventory.\n");
        }

        /// <summary>
        /// Removes an item from the inventory by its name parameter.
        /// </summary>
        /// 
        /// <param name="itemName">
        /// The name of the item to remove.
        /// </param>
        /// 
        /// <remarks>
        /// Displays a message confirming removal or showing if the item wasn't found.
        /// </remarks>
        public void RemoveItem(string itemName)
        {
            // Application of LINQ using lambda expressions
            var itemToRemove = _items.FirstOrDefault(i => i.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            
            // If the item is found, it is removed later.
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                IHelper.DisplayMessage($"\n{itemName} removed from inventory.\n");
                
                // Item's parameter is changed to false, so it can be collected again.
                itemToRemove.ItemCollected = false;
            }
            
            // If the item wasn't found
            else IHelper.DisplayMessage($"\n{itemName} not found in inventory.\n");
        }

        /// <summary>
        /// Displays the contents of the inventory with details for each item.
        /// </summary>
        /// 
        /// <remarks>
        /// Shows a message if the inventory is empty.
        /// Otherwise, displays each item's parameters.
        /// </remarks>
        public void DisplayInventory()
        {
            // If the inventory is empty
            if (_items.Count == 0)
            {
                IHelper.DisplayMessage("\nInventory is empty.\n");
                return;
            }

            // Displays the inventory
            IHelper.DisplayMessage("\nInventory:");
            foreach (var item in _items)
            {
                IHelper.DisplayMessage($"\n– {item.ItemName}" +
                                       $"\nDamage: {item.ItemDamage}" +
                                       $"\nHealth: {item.ItemHealth}" +
                                       $"\nLuck: {item.ItemLuck}\n");
            }
        }

        /// <summary>
        /// Allows the player to select an item by name and use it if it exists in the inventory.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player who is using the item.
        /// </param>
        public void SelectItem(Player player)
        {
            // If the inventory is empty, the player can't select an item.
            if (_items.Count == 0)
            {
                IHelper.DisplayMessage("\nInventory is empty. No items to select.\n");
                return;
            }

            string itemName;

            // Input validation loop
            while (true)
            {
                IHelper.DisplayMessage("\nPlease enter the name of the item you want to select: ");
                itemName = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(itemName))
                {
                    IHelper.DisplayMessage("\nInvalid input.");
                }
                
                else break;
            }

            // Try to find the item by name
            var selectedItem = _items.FirstOrDefault(i => i.ItemName.ToLower() == itemName);

            // Item selection
            if (selectedItem != null) selectedItem.UseItem(player, selectedItem);
            else IHelper.DisplayMessage($"\n{itemName} not found in inventory.\n");
        }

        
        /// <summary>
        /// Sorts weapons in the descending order by damage. Data is converted into a list.
        /// </summary>
        public void SortWeaponsByDamageDescending()
        {
            // Sorting
            var sortedWeapons = _items
                .OfType<Weapon>()
                .OrderByDescending(w => w.ItemDamage)
                .ToList();

            IHelper.DisplayMessage("\nWeapons sorted by damage (descending):\n");
            foreach (var weapon in sortedWeapons)
            {
                IHelper.DisplayMessage($"\n–{weapon.ItemName}: {weapon.ItemDamage} Damage");
            }
        }
    }
}