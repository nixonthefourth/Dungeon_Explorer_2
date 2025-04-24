namespace DungeonExplorer
{
    public class Greed : Monster
    {
        /// <summary>
        /// Constructor for the class Greed.
        /// </summary>
        public Greed() : base("Greed", 25, 2, 80) { }

        /// <summary>
        /// Creature is getting healed from the player, when monster's health goes lower than 30.
        /// Otherwise, the regular damage parameter is used.
        /// Uses static polymorphism.
        /// </summary>
        /// 
        /// <param name="target">
        /// The creature getting attacked.
        /// </param>
        public override void UniqueAttackBehavior(Creature target)
        {
            IHelper.DisplayMessage("\nGreed strikes your wallet!");

            // Greed heals from the player's health bar
            if (this.CreatureHealth <= 30 && IHelper.GenerateRandom() + this.CreatureLuck >= 8)
            {
                // Parameter change
                IHealable.HealCreature(this, 10);
                target.CreatureHealth -= 10;
                
                // Display status
                IHelper.DisplayMessage($"\n {target.CreatureName} has lost 10 points!\n" +
                                       $"\nNew health: {target.CreatureHealth}\n" +
                                       "\nGreed sucks out of your wallet...\n" +
                                       "\nIt is getting healed by 10 points!\n");
            }

            // Regular damage
            else IDamagable.Damage(this, target);
        }
    }
}