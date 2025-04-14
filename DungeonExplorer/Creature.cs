namespace DungeonExplorer
{
    public abstract class Creature : IDamagable
    {
        public string CreatureName;
        public int CreatureDamage;
        public int CreatureLuck;
        public int CreatureHealth;

        public abstract string GetCreatureName();
    }
}