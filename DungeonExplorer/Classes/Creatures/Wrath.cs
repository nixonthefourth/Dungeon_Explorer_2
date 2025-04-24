using System.Net.Http.Headers;

namespace DungeonExplorer
{
    public class Wrath : Monster
    {
        /// <summary>
        /// Constructor for Wrath.
        /// </summary>
        public Wrath() : base("Wrath", 15, 2, 100) { }

        /// <summary>
        /// Executes the unique attack behavior for Wrath.
        /// It deals double damage if the combined random value and its luck parameter are higher than 5.
        /// Applies the technique of static polymorphism.
        /// </summary>
        /// 
        /// <param name="target">
        /// The creature getting attacked.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            // Wrath deals double damage if the luck parameter is higher than 5
            if (IHelper.GenerateRandom() + this.CreatureLuck >= 5)
            {
                // Change the parameter and deal damage
                this.CreatureDamage *= 2;
                IHelper.DisplayMessage("\nWrath strikes with fury!");
                IDamagable.Damage(this, target);
            }
            
            // Regular damage
            else IDamagable.Damage(this, target);
        }
    }
}