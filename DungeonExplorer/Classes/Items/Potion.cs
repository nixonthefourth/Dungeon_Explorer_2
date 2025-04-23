namespace DungeonExplorer
{
    public class Potion : Item
    {
        /// <summary>
        /// Constructor for the potion.
        /// </summary>
        /// 
        /// <param name="potionName">
        /// Name parameter of the potion.
        /// </param>
        /// 
        /// <param name="potionDamage">
        /// Damage parameter of the potion.
        /// </param>
        /// 
        /// <param name="potionLuck">
        /// Luck parameter of the potion.
        /// </param>
        /// 
        /// <param name="potionHealth">
        /// Health parameter of the potion.
        /// </param>
        ///
        /// <param name="itemCollected">
        /// Item is collected or not.
        /// </param>
        public Potion(string potionName, int potionDamage, int potionLuck, int potionHealth, bool itemCollected) 
            : base(potionName, potionDamage, potionLuck, potionHealth, itemCollected)
        {
            ItemDamage = potionDamage;
            ItemHealth = potionHealth;
            ItemLuck = potionLuck;
            ItemName = potionName;
            ItemCollected = itemCollected;
        }
        
        /// <summary>
        /// Item is activated.
        /// </summary>
        /// 
        /// <param name="player">
        /// Player, who uses the item.
        /// </param>
        /// 
        /// <param name="item">
        /// Item, which is being used.
        /// </param>
        public override void UseItem(Player player, Item item)
        {
            IHelper.DisplayMessage($"\nYou have picked up a potion {item.ItemName}!");
            Collect(player, item);
        }
    }
}