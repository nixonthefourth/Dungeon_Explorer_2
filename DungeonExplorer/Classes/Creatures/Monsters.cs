namespace DungeonExplorer
{
    public class Monsters : Creature
    {
        /// <summary>
        /// Constructor for a monster.
        /// </summary>
        /// 
        /// <param name="monsterName">
        /// Name of the monster.
        /// </param>
        /// 
        /// <param name="monsterDamage">
        /// Damage that monster deals.
        /// </param>
        /// 
        /// <param name="monsterLuck">
        /// Luck multiplier for the actions monster's AI takes.
        /// </param>
        /// 
        /// <param name="monsterHealth">
        /// Initial health monster contains.
        /// </param>
        public Monsters(string monsterName, int monsterDamage, int monsterLuck, int monsterHealth) : base()
        {
            CreatureName = monsterName;
            CreatureDamage = monsterDamage;
            CreatureLuck = monsterLuck;
            CreatureHealth = monsterHealth;
        }

        /// <summary>
        /// Boring way of selecting enemies based on cardinal sins.
        /// </summary>
        /// 
        /// <returns>
        /// Returns objects (instances) randomly selected from the list.
        /// </returns>
        public static Monsters SelectMonster()
        {
            // List of monsters
            List<Monsters> monsters = new List<Monsters>()
            {
                new Monsters("Pride", 20, 1, 100),
                new Monsters("Greed", 25, 2, 80),
                new Monsters("Wrath", 15, 2, 100),
                new Monsters("Envy", 18, 2, 70),
                new Monsters("Lust", 30, 2, 90),
                new Monsters("Gluttony", 15, 3, 140),
                new Monsters("Sloth", 40, 3, 90)
            };
            
            // Return of the list and random selection of numbers for the objects.
            return monsters[new Random().Next(monsters.Count)];
        }
    }
}