namespace DungeonExplorer
{
    public abstract class Creature : IDamagable
    {
        public string CreatureName;
        public int CreatureDamage;
        public float CreatureLuck;
        public int CreatureHealth;
    }
}