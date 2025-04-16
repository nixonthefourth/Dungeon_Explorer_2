namespace DungeonExplorer
{
    public class Player : Creature
    {
        /// <summary>
        /// Constructor for the player.
        /// </summary>
        /// 
        /// <param name="playerName">
        /// Player's name.
        /// </param>
        /// 
        /// <param name="playerDamage">
        /// Damage that player is dealing.
        /// </param>
        /// 
        /// <param name="playerLuck">
        /// Player's luck multiplier.
        /// </param>
        /// 
        /// <param name="playerHealth">
        /// Player's health parameter.
        /// </param>
        public Player(string playerName, int playerDamage, int playerLuck, int playerHealth) : base()
        {
            CreatureName = playerName;
            CreatureDamage = playerDamage;
            CreatureLuck = playerLuck;
            CreatureHealth = playerHealth;
        }

        /// <summary>
        /// Gets the player's name. Overrides the abstract method in Creature.
        /// </summary>
        /// 
        /// <returns>
        /// Name that player has defined.
        /// </returns>
        ///
        /// <remarks>
        /// Puts the game into the infinite loop, until the input is valid.
        /// Input is checked on the length, and whether the string is an empty character or a space.
        /// </remarks>
        public override string GetCreatureName()
        {
            while (true)
            {
                // Name input
                IHelper.DisplayMessage("Enter your name, mighty warrior: ");
                CreatureName = Console.ReadLine();
                
                // Input validation
                if (CreatureName.Length == 0 || CreatureName == "" || CreatureName == " ")
                {
                    IHelper.DisplayMessage("Invalid name.\n");
                } 
                
                // Successfull case
                else break;
            }
            
            // Returns the name of the player.
            return CreatureName;
        }
    }
}