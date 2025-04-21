namespace DungeonExplorer
{
    public abstract class Creature : IDamagable
    {
        /// <summary>
        /// Returns the health parameter.
        /// 
        /// Checks whether the input for Creature's name has been provided.
        /// In case there is none, a nameplate is provided. Otherwise, the correct input is assigned.
        /// </summary>
        public string CreatureName
        {
            get { return CreatureName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    IHelper.DisplayMessage("\nNo input has been provided.");
                    CreatureName = "Jon Doe";
                }

                else CreatureName = value;
            }
        }

        /// <summary>
        /// Returns the damage parameter.
        ///
        /// Damage is being set within 3 cases, which ensures that a creature has the damage value.
        /// </summary>
        public int CreatureDamage
        {
            get { return CreatureDamage; }
            set
            {
                // Sets damage to 20 if no input has been provided
                if (string.IsNullOrEmpty(value.ToString())) CreatureDamage = 20;
                
                // Sets damage to 20 if it's lower than 0
                else if (value < 0) CreatureDamage = 20;
                
                // Otherwise, the value is simply passed
                else CreatureDamage = value;
            }
        }

        /// <summary>
        /// Returns the value of the luck parameter.
        ///
        /// Luck is set either to 1 or whatever is set with an instance of the Creature.
        /// </summary>
        public int CreatureLuck
        {
            get { return CreatureLuck; }
            set
            {
                // Sets the default value for the luck parameter to 1
                if (string.IsNullOrEmpty(value.ToString())) CreatureLuck = 1;
                
                // Otherwise, passes the value
                else CreatureLuck = value;
            }
        }
        
        /// <summary>
        /// Returns the health parameter.
        /// 
        /// The health parameter is checked within 2 cases.
        /// The first one is set to full health if there is no input provided.
        /// The second one simply sets whatever is passed.
        /// </summary>
        public int CreatureHealth
        {
            get { return CreatureHealth; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    IHelper.DisplayMessage("\nHealth has been set to 100 due to lack of an input");
                    CreatureHealth = 100;
                }
                
                else CreatureHealth = value;
            }
        }
    }
}