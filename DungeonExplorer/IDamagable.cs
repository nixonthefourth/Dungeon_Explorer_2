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
                
                DisplayMessage($"{creatureReceives} has been injured!\n \n" +
                               $"Health of {creatureReceives}: {creatureReceives.CreatureHealth}\n" +
                               $"Health of {creatureDamages}: {creatureDamages.CreatureDamage}");
            }
            
            // Case, where creature doesn't deal damage
            else if (GenerateRandom() >= 8)
            {
                DisplayMessage($"{creatureDamages}'s hit was missed!");
            }
        }
    }
}