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
        /// </summary>
        /// 
        /// <param name="target">
        /// Target creature.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Actual implementation
            IHelper.DisplayMessage("\nSloth strikes your mind!");
            if (IHelper.GenerateRandom() + this.CreatureLuck >= 6)
            {
                IDamagable.Damage(this, target);
            }
        }
    }
}