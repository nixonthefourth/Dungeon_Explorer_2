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
        public Potion(string potionName, int potionDamage, int potionLuck, int potionHealth) 
            : base(potionName, potionDamage, potionLuck, potionHealth)
        {
            ItemDamage = potionDamage;
            ItemHealth = potionHealth;
            ItemLuck = potionLuck;
            ItemName = potionName;
        }
    }
}