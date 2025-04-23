namespace DungeonExplorer
{
    public class ICollectible : IHelper
    {
        /// <summary>
        /// Checks whether the item has been collected already.
        /// </summary>
        public bool IsCollected { get; set; }
        
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
        public void Collect(Creature creature, Item item)
        {
            // Assigns the collected value
            if (!IsCollected)
            {
                // Assigns the values
                creature.CreatureDamage = item.ItemDamage;
                creature.CreatureHealth += item.ItemHealth;
                creature.CreatureLuck += item.ItemLuck;
            }
            
            // If the item is already collected
            else IHelper.DisplayMessage($"\nThis item is already collected!");
        }
    }
}