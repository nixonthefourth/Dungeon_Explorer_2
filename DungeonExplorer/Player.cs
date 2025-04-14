namespace DungeonExplorer
{
    public class Player : Creature
    {
        public Player(string playerName, int playerDamage, int playerLuck, int playerHealth) : base()
        {
            CreatureName = playerName;
            CreatureDamage = playerDamage;
            CreatureLuck = playerLuck;
            CreatureHealth = playerHealth;
        }

        public override string GetCreatureName()
        {
            while (true)
            {
                IHelper.DisplayMessage("Enter your name, mighty warrior: ".ToUpper());
                CreatureName = Console.ReadLine();

                if (CreatureName.Length == 0 || CreatureName == "" || CreatureName == " ")
                {
                    IHelper.DisplayMessage("Invalid name. \n \n".ToUpper());
                } else break;
            }
            
            return CreatureName;
        }
    }
}