namespace DungeonExplorer
{
    public class Sloth : Monster
    {
        /// <summary>
        /// Constructor for Sloth.
        /// </summary>
        public Sloth() : base("Sloth", 50, 1, 100) { }

        /// <summary>
        /// Takes its time to attack, but it does deal a lot of damage.
        /// Applies the technique of dynamic polymorphism.
        /// </summary>
        /// 
        /// <param name="target">
        /// Target creature. The player.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Actual implementation
            IHelper.DisplayMessage("\nSloth strikes your mind!");
            
            // Damage deal
            if (IHelper.GenerateRandom() + this.CreatureLuck >= 6)
            {
                IDamagable.Damage(this, target);
            }
        }
    }
}