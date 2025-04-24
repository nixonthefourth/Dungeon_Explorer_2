namespace DungeonExplorer
{
    public class Pride : Monster
    {
        /// <summary>
        /// Constructor for the Pride.
        /// </summary>
        public Pride() : base("Pride", 10, 1, 100) { }

        /// <summary>
        /// Inherited unique attack behaviour. Applies the technique of dynamic polymorphism.
        /// </summary>
        /// 
        /// <param name="target">
        /// Targets the creature that gets damage (player, basically).
        /// </param>
        ///
        /// <remarks>
        /// Pride has 2 attack behaviours. First one deals the regular damage.
        /// The second one is doing twice as much damage when the health parameter is reduced.
        /// </remarks>
        public override void UniqueAttackBehavior(Creature target)
        {
            IHelper.DisplayMessage("\nPride strikes your ego!");
            
            // Pride deals the double damage if the health parameter drops lower than 60
            if (this.CreatureHealth <= 60)
            {
                // Double damage
                IHelper.DisplayMessage($"\n{CreatureName} strikes with fury!");
                this.CreatureDamage *= 2;
                
                // Actual damage dealing
                IDamagable.Damage(this, target);
            }
            
            // Regular case
            else IDamagable.Damage(this, target);
        }
    }

}