namespace DungeonExplorer
{
    public abstract class Creature : IDamagable
    {
        public string CreatureName;
        public int CreatureDamage;
        public int CreatureLuck;
        public int CreatureHealth;

        /// <summary>
        /// Abstract implementation of the getter for creatures.
        /// </summary>
        /// 
        /// <returns>
        /// Returns string of the name of the assigned creature.
        /// </returns>
        ///
        /// <remarks>
        /// Player gets the method for defining names.
        /// Enemy gets a returner.
        /// </remarks>
        public abstract string GetCreatureName();
    }
}