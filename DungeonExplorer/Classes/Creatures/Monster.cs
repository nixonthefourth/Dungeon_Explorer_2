namespace DungeonExplorer
{
    public class Monster : Creature
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
        public Monster(string monsterName, int monsterDamage, int monsterLuck, int monsterHealth) 
            : base(monsterName, monsterDamage, monsterLuck, monsterHealth)
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
        public static Monster SelectMonster()
        {
            // List of monsters
            List<Monster> monsters = new List<Monster>()
            {
                new Monster("Pride", 20, 1, 100),
                new Monster("Greed", 25, 2, 80),
                new Monster("Wrath", 15, 2, 100),
                new Monster("Envy", 18, 2, 70),
                new Monster("Lust", 30, 2, 90),
                new Monster("Gluttony", 15, 3, 140),
                new Monster("Sloth", 40, 3, 90)
            };
            
            // Return of the list and random selection of numbers for the objects.
            return monsters[new Random().Next(monsters.Count)];
        }
    }
}