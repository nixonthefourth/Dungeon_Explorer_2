namespace DungeonExplorer
{
    public class ICollectible : IHelper
    {
        /// <summary>
        /// Item is getting picked up.
        /// </summary>
        /// 
        /// <param name="creature">
        /// The creature, where the item is assigned.
        /// </param>
        /// 
        /// <param name="item">
        /// The item itself, which is getting assigned.
        /// </param>
        ///
        /// <remarks>
        /// Item is getting picked up and assigned to the creature.
        /// It is checked if the item is already collected. If it is, the message is displayed.
        /// It is impossible to collect the same item twice.
        /// </remarks>
        public void Collect(Creature creature, Item item)
        {
            // Assigns the collected value
            if (item.ItemCollected == false)
            {
                // Assigns the values
                creature.CreatureDamage = item.ItemDamage;
                creature.CreatureHealth += item.ItemHealth;
                creature.CreatureLuck += item.ItemLuck;
            }
            
            // If the item is already collected
            else IHelper.DisplayMessage($"\nThis item is already collected!");
            
            // Changes the value to true
            item.ItemCollected = true;
        }
    }
}