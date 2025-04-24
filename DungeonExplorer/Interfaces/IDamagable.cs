namespace DungeonExplorer
{
    public interface IDamagable : IHelper, IHealthValidation
    {
        /// <summary>
        /// Handles damage application from one creature to another in the game.
        /// </summary>
        /// 
        /// <param name="creatureDamages">
        /// The creature that is dealing damage.
        /// </param>
        /// 
        /// <param name="creatureReceives">
        /// The creature that is receiving damage.
        /// </param>
        public static void Damage(Creature creatureDamages, Creature creatureReceives)
        {
            // Validators
            HealthValidation(creatureDamages);
            EnemyHealthValidation(creatureReceives);
            
            // Case, where the creature deals damage
            if (GenerateRandom() <= 7)
            {
                creatureReceives.CreatureHealth -= creatureDamages.CreatureDamage;
                
                DisplayMessage($"\n{creatureReceives.CreatureName} has been injured!\n" +
                               $"Health of {creatureReceives.CreatureName}: {creatureReceives.CreatureHealth}\n" +
                               $"Health of {creatureDamages.CreatureName}: {creatureDamages.CreatureHealth}\n");
            }
            
            // Case, where the creature doesn't deal damage
            else if (GenerateRandom() >= 8)
            {
                DisplayMessage($"\n{creatureDamages.CreatureName}'s hit was missed!\n");
            }
        }
    }
}