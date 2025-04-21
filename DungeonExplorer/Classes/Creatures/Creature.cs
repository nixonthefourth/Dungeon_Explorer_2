namespace DungeonExplorer
{
    public abstract class Creature : IDamagable
    {
        /// <summary>
        /// Returns and sets the health parameter.
        /// </summary>
        public string CreatureName { get; set; }

        /// <summary>
        /// Returns and sets the damage parameter.
        /// </summary>
        public int CreatureDamage { get; set; }

        /// <summary>
        /// Returns and sets the value of the luck parameter.
        /// </summary>
        public int CreatureLuck { get; set; }
        
        /// <summary>
        /// Returns and sets the health parameter.
        /// </summary>
        public int CreatureHealth { get; set; }
    }
}