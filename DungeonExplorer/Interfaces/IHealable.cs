namespace DungeonExplorer

{
    public interface IHealable : IHelper
    {
        /// <summary>
        /// Allows healing the creature.
        /// </summary>
        /// 
        /// <param name="creature">
        /// Creature that should be healed.
        /// </param>
        /// 
        /// <param name="value">
        /// Value by how much the creature should be healed.
        /// </param>
        ///
        /// <remarks>
        /// This piece of code simply displays a status and changes it through addition.
        /// </remarks>
        public static void HealCreature(Creature creature, int value)
        {
            // Displaying message and applying changes
            DisplayMessage($"\n{creature.CreatureName} has been healed!");
            creature.CreatureHealth += value;
            
            // Showing the applied changes
            DisplayMessage($"\n{creature.CreatureName}'s new health is {creature.CreatureHealth}");
        }
    }
}