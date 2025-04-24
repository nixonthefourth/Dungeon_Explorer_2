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
        public Player(string playerName, int playerDamage, int playerLuck, int playerHealth) 
            : base(playerName, playerDamage, playerLuck, playerHealth)
        {
            CreatureName = playerName;
            CreatureDamage = playerDamage;
            CreatureLuck = playerLuck;
            CreatureHealth = playerHealth;
        }

        /// <summary>
        /// Gets the player's name. Unique method for the creature.
        /// </summary>
        /// 
        /// <returns>
        /// Name that player has defined.
        /// </returns>
        ///
        /// <remarks>
        /// Puts the game into the infinite loop until the input is valid.
        /// Input is checked on the length and whether the string is an empty character or a space.
        /// </remarks>
        public string GetCreatureName()
        {
            while (true)
            {
                // Name input
                IHelper.DisplayMessage("\nEnter your name, mighty warrior: ");
                CreatureName = Console.ReadLine();
                
                // Input validation
                if (CreatureName.Length == 0 || CreatureName == "" || CreatureName == " ")
                {
                    IHelper.DisplayMessage("Invalid name.\n");
                } 
                
                // Successful case
                else break;
            }
            
            // Returns the name of the player.
            return CreatureName;
        }
        
        /// <summary>
        /// Upgrades the stats of the specified player, potentially enhancing attributes such as damage, luck, or health.
        /// </summary>
        /// 
        /// <param name="player">
        /// The player object whose stats will be upgraded.
        /// </param>
        public void PlayerStatsUpgrade(Player player)
        {
            Console.Clear();

            // Statistics
            int healthUp = 10;
            int damageUp = 5;
            int[] statsUp = { healthUp, damageUp };
            
            // Message
            IHelper.DisplayMessage("\nStats upgrade complete!");

            // Application of the parameters
            if (IHelper.GenerateRandom() + player.CreatureLuck >= 6) player.CreatureHealth += statsUp[0];
            else player.CreatureDamage += statsUp[1];
        }
    }
}