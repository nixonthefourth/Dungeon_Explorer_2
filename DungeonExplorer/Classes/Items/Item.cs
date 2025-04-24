namespace DungeonExplorer
{
    public class Item : ICollectible
    {
        // Private variables
        /// <summary>
        /// Protected field for the name of the item.
        /// </summary>
        private protected string _itemName;
        
        /// <summary>
        /// Protected field for the damage parameter of the item.
        /// </summary>
        private protected int _itemDamage;
        
        /// <summary>
        /// Protected field for the health parameter of the item.
        /// </summary>
        private protected int _itemHealth;
        
        /// <summary>
        /// Protected field for the luck parameter of the item.
        /// </summary>
        private protected int _itemLuck;
        
        /// <summary>
        /// Protected field that shows whether the item has been collected.
        /// </summary>
        private protected bool _itemCollected;
        
        // Public variables
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                // Sets default values
                if (string.IsNullOrEmpty(value))
                {
                    _itemName = "Default Item";
                }
                
                // Sets proper value
                else _itemName = value;
            }
        }
        
        /// <summary>
        /// Damage parameter of the item.
        /// </summary>
        public int ItemDamage
        {
            get { return _itemDamage; }
            set
            {
                // If there is no valid input
                if (string.IsNullOrWhiteSpace(value.ToString())) _itemDamage = 20;
                
                // If value is less then 0
                else if (value < 0) _itemDamage = 20;
                
                // Assigns the proper value
                else _itemDamage = value;
            }
        }
        
        /// <summary>
        /// Health parameter of the item.
        /// </summary>
        public int ItemHealth
        {
            get { return _itemHealth; }
            set
            {
                // Sets default values
                // Empty case
                if (string.IsNullOrWhiteSpace(value.ToString())) _itemHealth = 20;
                
                // Sets the value
                else _itemHealth = value;
            }
        }
        
        /// <summary>
        /// Luck parameter of the item.
        /// </summary>
        public int ItemLuck
        {
            get { return _itemLuck; }
            set
            {
                // If there is no valid input
                if (string.IsNullOrWhiteSpace(value.ToString())) _itemLuck = 1;
                
                // No valid input either
                else if (value < 0) _itemLuck = 1;
                
                // Assigns the proper value
                else _itemLuck = value;
            }
        }

        /// <summary>
        /// Indicates whether the item has been collected.
        /// </summary>
        public bool ItemCollected
        {
            get { return _itemCollected; }
            set
            {
                // Sets default values
                // Empty case
                if (string.IsNullOrWhiteSpace(value.ToString())) _itemCollected = false;
                
                // Sets the value
                else _itemCollected = value;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the Item class with the specified parameters.
        /// </summary>
        /// 
        /// <param name="itemName">
        /// The name of the item.
        /// </param>
        /// 
        /// <param name="itemDamage">
        /// The damage value of the item.
        /// </param>
        /// 
        /// <param name="itemHealth">
        /// The health value of the item.
        /// </param>
        /// 
        /// <param name="itemLuck">
        /// Luck value of the item.
        /// </param>
        ///
        /// <param name="isItemCollected">
        /// Indicates whether the item has been collected.
        /// </param>
        public Item(string itemName, int itemDamage, int itemHealth, int itemLuck, bool isItemCollected)
        {
            ItemName = itemName;
            ItemDamage = itemDamage;
            ItemHealth = itemHealth;
            ItemLuck = itemLuck;
            ItemCollected = isItemCollected;
        }

        /// <summary>
        /// Stores a list of items with the corresponding parameters.
        /// </summary>
        /// 
        /// <returns>
        /// Returns the object of the item list.
        /// </returns>
        public static Item SelectItem()
        {
            List<Item> items = new List<Item>()
            {
                // Weapons
                new Weapon("Jar of Marmelade", 20, 0, 0, false),
                new Weapon("Laser Pointer", 3, 3, 0, false),
                new Weapon("Razor Blade", 15, 1, 0, false),
                new Weapon("Mixer", 30, 2, 0, false),
                new Weapon("The Judge", 25, 2, 10, false),
                
                // Potions
                new Potion("Cheeky Potion", 0, 0, 20, false),
                new Potion("Flower Bunch", 0, 1, 10, false),
                new Potion("Potion of Clumsy Words", 20, 1, 0, false),
                new Potion("Bottle of VK", 0, 4, 15, false)
            };

            // Returns the object
            return items[new Random().Next(items.Count)];
        }

        /// <summary>
        /// Uses item.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player, who is applying the item.
        /// </param>
        /// 
        /// <param name="item">
        /// Item, which is found and should be assigned.
        /// </param>
        public virtual void UseItem(Player player, Item item)
        {
            IHelper.DisplayMessage("\nItem is found");
            Collect(player, item);
        }
    }
}