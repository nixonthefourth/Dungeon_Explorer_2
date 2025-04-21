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
        public Weapon(string weaponName, int weaponDamage, int weaponLuck) : base()
        {
            ItemName = weaponName;
            ItemDamage = weaponDamage;
            ItemLuck = weaponLuck;
        }
    }
}