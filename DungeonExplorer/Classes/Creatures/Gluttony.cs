namespace DungeonExplorer
{
    public class Gluttony : Monster
    {
        /// <summary>
        /// Constructor for Gluttony.
        /// </summary>
        public Gluttony() : base("Gluttony", 15, 3, 140) { }

        /// <summary>
        /// Applies dynamic polymorphism to create the unique attack behaviour.
        /// Basically, this method is just a wrapper for the damage method.
        /// The monster shows the message and deals regular damage.
        /// </summary>
        /// 
        /// <param name="target">
        /// Target creature. The player, basically.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Display message
            IHelper.DisplayMessage("\nGluttony strikes your belly!" +
                                   "\nIt is crawling slowly towards you with it's slimy body...\n");
            
            // Actual damage
            IDamagable.Damage(this, target);
        }
    }
}