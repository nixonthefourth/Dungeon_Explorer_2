namespace DungeonExplorer
{
    public class Gluttony : Monster
    {
        /// <summary>
        /// Constructor for Gluttony.
        /// </summary>
        public Gluttony() : base("Gluttony", 15, 3, 140) { }

        public override void UniqueAttackBehavior(Creature target)
        {
            // Display message
            IHelper.DisplayMessage("\nGluttony strikes your belly!" +
                                   "\nIt is crawling slowly towards you with it's slimy body...");
            
            // Actual damage
            IDamagable.Damage(this, target);
        }
    }
}