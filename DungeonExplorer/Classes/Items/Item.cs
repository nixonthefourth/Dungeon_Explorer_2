namespace DungeonExplorer
{
    public class Item : ICollectible
    {
        // Private variables
        private string _itemName;
        private int _itemDamage;
        private int _itemHealth;
        private int _itemLuck;
        
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
        public Item(string itemName, int itemDamage, int itemHealth, int itemLuck)
        {
            ItemName = itemName;
            ItemDamage = itemDamage;
            ItemHealth = itemHealth;
            ItemLuck = itemLuck;
        }
    }
}