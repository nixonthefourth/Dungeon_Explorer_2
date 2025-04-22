namespace DungeonExplorer
{
    public abstract class Creature : IDamagable, IHealable
    {
        // Private Variables
        private string _creatureName;
        private int _creatureDamage;
        private int _creatureLuck;
        private int _creatureHealth;
        
        // Public Variables
        
        /// <summary>
        /// Returns and sets the health parameter.
        /// </summary>
        public string CreatureName
        {
            get { return _creatureName; }
            set
            {
                // Sets default values
                if (string.IsNullOrEmpty(value))
                {
                    _creatureName = "Default Name";
                }
                
                // Sets proper value
                else _creatureName = value;
            }
        }

        /// <summary>
        /// Returns and sets the damage parameter.
        /// </summary>
        public int CreatureDamage
        {
            get { return _creatureDamage; }
            set
            {
                // If there is no valid input
                if (string.IsNullOrWhiteSpace(value.ToString())) _creatureDamage = 10;
                
                // If value is less then 0
                else if (value < 0) _creatureDamage = 10;
                
                // Assigns the proper value
                else _creatureDamage = value;
            }
        }

        /// <summary>
        /// Returns and sets the value of the luck parameter.
        /// </summary>
        public int CreatureLuck
        {
            get { return _creatureLuck; }
            set
            {
                // If there is no valid input
                if (string.IsNullOrWhiteSpace(value.ToString())) _creatureLuck = 1;
                
                // No valid input either
                else if (value < 0) _creatureLuck = 1;
                
                // Assigns the proper value
                else _creatureLuck = value;
            }
        }

        /// <summary>
        /// Returns and sets the health parameter.
        /// </summary>
        public int CreatureHealth
        {
            get { return _creatureHealth; }
            set
            {
                // Sets default values
                // Empty case
                if (string.IsNullOrWhiteSpace(value.ToString())) _creatureHealth = 100;
                
                // Sets the value
                else _creatureHealth = value;
            }
        }
        
        /// <summary>
        /// Constructor for the creature.
        /// </summary>
        /// 
        /// <param name="creatureName">
        /// Name of the creature.
        /// </param>
        /// 
        /// <param name="creatureDamage">
        /// Damage creature deals.
        /// </param>
        ///
        /// <param name="creatureLuck">
        /// The luck parameter of the creature.
        /// </param>
        /// 
        /// <param name="creatureHealth">
        /// Health parameter of the creature.
        /// </param>
        public Creature(string creatureName, int creatureDamage, int creatureLuck, int creatureHealth) 
        {
            CreatureName = creatureName;
            CreatureDamage = creatureDamage;
            CreatureLuck = creatureLuck;
            CreatureHealth = creatureHealth;
        }
    }
}