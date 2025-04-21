namespace DungeonExplorer
{
    public class ICollectible : IHelper
    {
        /// <summary>
        /// Item is getting picked up.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="item"></param>
        public void Collect(Creature creature, Item item)
        {
            // Assigns the collected value
            if (!IsCollected)
            {
                creature.CreatureDamage = item.ItemDamage;
                creature.CreatureHealth += item.ItemHealth;
                creature.CreatureLuck += item.ItemLuck;
            }
        }
        
        /// <summary>
        /// Checks whether the item has been collected already.
        /// </summary>
        public bool IsCollected { get; set; }
    }
}