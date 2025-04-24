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
            // Case, where the creature deals damage
            if (GenerateRandom() <= 7)
            {
                creatureReceives.CreatureHealth -= creatureDamages.CreatureDamage;
                
                CheckHealthOutput(creatureDamages, creatureReceives);
                
                DisplayMessage($"\n{creatureReceives.CreatureName} has been injured!\n" +
                               $"Health of {creatureReceives.CreatureName}: {creatureReceives.CreatureHealth}\n" +
                               $"Health of {creatureDamages.CreatureName}: {creatureDamages.CreatureHealth}\n");
            }
            
            // Case, where the creature doesn't deal damage
            else if (GenerateRandom() >= 8) DisplayMessage($"\n{creatureDamages.CreatureName}'s hit was missed!\n");
        }

        /// <summary>
        /// Ensures that the health values of both creatures are clamped to a minimum of zero.
        /// </summary>
        /// 
        /// <param name="creatureDamages">
        /// The creature that is dealing damage.
        /// </param>
        /// 
        /// <param name="creatureReceives">
        /// The creature that is receiving damage.
        /// </param>
        private protected static void CheckHealthOutput(Creature creatureDamages, Creature creatureReceives)
        {
            // In case of negative health values, set them to zero.
            // Case of the damager
            if (creatureDamages.CreatureHealth <= 0)
            {
                creatureDamages.CreatureHealth = 0;
            }
            
            // Case of the receiver
            else if (creatureReceives.CreatureHealth <= 0)
            {
                creatureReceives.CreatureHealth = 0;
            }
        }
    }
}