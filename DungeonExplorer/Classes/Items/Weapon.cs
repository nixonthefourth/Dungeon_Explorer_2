namespace DungeonExplorer
{
    public class Weapon : Item
    {
        /// <summary>
        /// Constructor for the weapon subclass.
        /// </summary>
        /// 
        /// <param name="weaponName">
        /// Name parameter of the weapon item.
        /// </param>
        /// 
        /// <param name="weaponDamage">
        /// Damage parameter of the weapon item.
        /// </param>
        /// 
        /// <param name="weaponLuck">
        /// The weapon's luck parameter.
        /// </param>
        ///
        /// <param name="weaponHealth">
        /// Health that may be added by the use of a weapon.
        /// </param>
        ///
        /// <param name="itemCollected">
        /// Item is collected or not.
        /// </param>
        public Weapon(string weaponName, int weaponDamage, int weaponLuck, int weaponHealth, bool itemCollected) 
            : base(weaponName, weaponDamage, weaponLuck, weaponHealth, itemCollected)
        {
            ItemName = weaponName;
            ItemDamage = weaponDamage;
            ItemLuck = weaponLuck;
            ItemHealth = weaponHealth;
            ItemCollected = itemCollected;
        }
        
        /// <summary>
        /// Item is activated.
        /// Allows for the static polymorphism.
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
            IHelper.DisplayMessage($"\nYou have picked up a weapon {item.ItemName}!");
            Collect(player, item);
        }
    }
}