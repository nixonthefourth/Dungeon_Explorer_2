namespace DungeonExplorer
{
    public class Inventory
    {
        /// <summary>
        /// Private collection of items in the inventory.
        /// </summary>
        private protected List<Item> _items = new List<Item>();
        
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
        /// <returns>
        /// True if the item was successfully added; 
        /// False if the inventory is full.
        /// </returns>
        /// 
        /// <remarks>
        /// This method will display a message indicating either success or failure.
        /// </remarks>
        public bool AddItem(Item item)
        {
            // Case, when the inventory is full
            if (_items.Count >= MaxCapacity)
            {
                IHelper.DisplayMessage("Inventory is full!");
                return false;
            }

            // Adds the item to the inventory
            _items.Add(item);
            
            // Message
            IHelper.DisplayMessage($"{item.ItemName} added to inventory.");
            return true;
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
                IHelper.DisplayMessage($"{itemName} removed from inventory.");
            }
            
            // If the item wasn't found
            else IHelper.DisplayMessage($"{itemName} not found in inventory.");
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
                IHelper.DisplayMessage("Inventory is empty.");
                return;
            }

            // Displays the inventory
            IHelper.DisplayMessage("Inventory:");
            foreach (var item in _items)
            {
                IHelper.DisplayMessage($"\n– {item.ItemName}" +
                                       $"\n Damage: {item.ItemDamage}" +
                                       $"\n Health: {item.ItemHealth}" +
                                       $"\nLuck: {item.ItemLuck}");
            }
        }

        /// <summary>
        /// Item selection mechanism.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player's object.
        /// </param>
        /// 
        /// <param name="item">
        /// Item's object.
        /// </param>
        public void SelectItem(Player player, Item item)
        {
            // Application of LINQ using lambda expressions
            var itemToSelect = _items.FirstOrDefault(i => i.ItemName.Equals(item.ItemName, StringComparison.OrdinalIgnoreCase));
            
            // If the item is found, it is selected later.
            if (itemToSelect != null) itemToSelect.UseItem(player, itemToSelect);
            
            // If the item wasn't found
            else IHelper.DisplayMessage($"{item.ItemName} not found in inventory.");
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

            IHelper.DisplayMessage("Weapons sorted by damage (descending):");
            foreach (var weapon in sortedWeapons)
            {
                IHelper.DisplayMessage($"\n– {weapon.ItemName}: {weapon.ItemDamage} Damage");
            }
        }
    }
}