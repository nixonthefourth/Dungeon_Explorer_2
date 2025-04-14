namespace DungeonExplorer
{
    public interface IDamagable : IHelper
    {
        private void Damage(Creature creatureDamages, Creature creatureReceives)
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
                DisplayMessage("Hit was missed!");
            }
            
            // Case of death
            if (creatureReceives.CreatureHealth is 0)
            {
                DisplayMessage($"{creatureReceives} is dead!");
            }
        }
    }
}