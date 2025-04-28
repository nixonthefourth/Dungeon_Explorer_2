namespace DungeonExplorer
{
    public abstract class Monster : Creature
    {
        /// <summary>
        /// Constructor for the monster parameter.
        /// </summary>
        ///
        /// <param name="monsterName">
        /// Name of the monster.
        /// </param>
        /// 
        /// <param name="monsterDamage">
        /// Damage of the monster.
        /// </param>
        /// 
        /// <param name="monsterLuck">
        /// Luck of the monster.
        /// </param>
        /// 
        /// <param name="monsterHealth">
        /// Health of the monster.
        /// </param>
        public Monster(string monsterName, int monsterDamage, int monsterLuck, int monsterHealth) 
            : base(monsterName, monsterDamage, monsterLuck, monsterHealth) { }

        /// <summary>
        /// Prepares for the dynamic polymorphic behaviour.
        /// Responsible for the damage dealing.
        /// </summary>
        /// 
        /// <param name="target">
        /// Target creature, player in this case.
        /// </param>
        public virtual void UniqueAttackBehavior(Creature target)
        {
            // Default implementation
            IDamagable.Damage(this, target); // Default behavior
        }

        /// <summary>
        /// Monster selector.
        /// </summary>
        /// 
        /// <returns>
        /// Returns the object of the individual monster using random unique numbers.
        /// </returns>
        ///
        /// <remarks>
        /// Objects of the individual monsters are created and added to the list.
        /// </remarks>
        public static Monster SelectMonster()
        {
            // List expansion
            List<Monster> monsters = new List<Monster>()
            {
                new Pride(),
                new Greed(),
                new Wrath(),
                new Envy(),
                new Lust(),
                new Gluttony(),
                new Sloth()
            };

            // Returns the object
            return monsters[new Random().Next(monsters.Count)];
        }
    }

}