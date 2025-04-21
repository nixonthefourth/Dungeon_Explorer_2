namespace DungeonExplorer
{
    public class Item : ICollectible
    {
        /// <summary>
        /// Name of the item.
        /// </summary>
        public string ItemName { get; set; }
        
        /// <summary>
        /// Damage parameter of the item.
        /// </summary>
        public int ItemDamage { get; set; }
        
        /// <summary>
        /// Health parameter of the item.
        /// </summary>
        public int ItemHealth { get; set; }
        
        /// <summary>
        /// Luck parameter of the item.
        /// </summary>
        public int ItemLuck { get; set; }
    }
}