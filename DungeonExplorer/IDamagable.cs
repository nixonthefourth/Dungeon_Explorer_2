namespace DungeonExplorer
{
    public interface IDamagable : IHelper
    {
        public static void Damage(Creature creatureDamages, Creature creatureReceives)
        {
            // Case, where creature deals damage
            if (GenerateRandom() <= 7)
            {
                creatureReceives.CreatureHealth -= creatureDamages.CreatureDamage;
                
                DisplayMessage($"\n{creatureReceives.CreatureName} has been injured!\n \n" +
                               $"Health of {creatureReceives.CreatureName}: {creatureReceives.CreatureHealth}\n" +
                               $"Health of {creatureDamages.CreatureName}: {creatureDamages.CreatureDamage}");
            }
            
            // Case, where creature doesn't deal damage
            else if (GenerateRandom() >= 8)
            {
                DisplayMessage($"\n{creatureDamages.CreatureName}'s hit was missed!");
            }
        }
    }
}