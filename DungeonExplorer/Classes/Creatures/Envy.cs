namespace DungeonExplorer
{
    public class Envy : Monster
    {
        /// <summary>
        /// Constructor for Envy.
        /// </summary>
        public Envy() : base("Envy", 18, 2, 70) { }

        /// <summary>
        /// Executes Envy's unique attack behavior on the specified target.
        /// Uses the technique of dynamic polymorphism to create a triple damage technique.
        /// </summary>
        /// 
        /// <param name="target">
        /// The target creature receiving the damage.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Triple damage
            if (IHelper.GenerateRandom() + this.CreatureLuck >= 8)
            {
                // Actual implementation
                for (int i = 1; i <= 3; i++)
                {
                    IHelper.DisplayMessage($"\nStrike {i} of 3\n");
                    IDamagable.Damage(this, target);
                }
            }
            
            // Regular damage
            else IDamagable.Damage(this, target);
        }
    }
}