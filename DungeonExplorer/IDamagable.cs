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
                Console.WriteLine("Damage Dealt");
            }
            
            // Case, where creature doesn't deal damage
            else if (GenerateRandom() >= 8)
            {
                Console.WriteLine("Damage Wasn't Dealt");
            }
        }
    }
}