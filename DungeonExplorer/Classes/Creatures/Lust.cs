namespace DungeonExplorer
{
    public class Lust : Monster
    {
        /// <summary>
        /// Constructor for Lust.
        /// </summary>
        public Lust() : base("Lust", 30, 2, 40) { }

        /// <summary>
        /// Executes the unique attack behavior for the Lust monster.
        /// Uses the technique of static polymorphism.
        /// </summary>
        /// 
        /// <param name="target">
        /// The target creature that will receive the attack.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Actual implementation with damage and a message
            IHelper.DisplayMessage("\nLust strikes your balls...\n");
            IDamagable.Damage(this, target);
        }
    }
}