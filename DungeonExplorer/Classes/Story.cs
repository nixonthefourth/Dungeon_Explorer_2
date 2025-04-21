namespace DungeonExplorer
{
    public class Story : IHelper
    {
        /// <summary>
        /// Confirmation sequence (Press enter to continue.)
        /// </summary>
        public static void ConfirmationMessage()
        {
            IHelper.DisplayMessage("\nPress Enter to continue...");
            Console.ReadLine();
            
            Console.Clear();
        }

        /// <summary>
        /// Shows start of the story.
        /// </summary>
        ///
        /// <remarks>
        /// Input line is read and the the screen is cleared later.
        /// ConfirmationMessage() is applied.
        /// </remarks>
        public static void StoryStart()
        {
            IHelper.DisplayMessage("\nWelcome to Dungeon Explorer!\n");
            
            ConfirmationMessage();
            
            IHelper.DisplayMessage("\n***\n" +
                                   "Long time ago...\n" +
                                   "In a far-far galaxy...\n" +
                                   "Monsters out of Biggleswade were born.\n \n" +
                                   "It's time for a hero to diabolically demolish them!\n" +
                                   "***\n");
            
            ConfirmationMessage();
        }
        
        /// <summary>
        /// Output Character's Name (Name Confirmation Pretty Much)
        /// </summary>
        /// 
        /// <param name="creature">
        /// Pushes the name of the character that player defines.
        /// </param>
        ///
        /// <remarks>
        /// Input line is read and the the screen is cleared later.
        /// ConfirmationMessage() is applied.
        /// </remarks>
        public static void CharacterNameConfirmation(Creature creature)
        {
            IHelper.DisplayMessage($"\nWelcome, {creature.CreatureName}!\n");
            
            ConfirmationMessage();
        }
        
        /// <summary>
        /// Shows the description of the room with randomly selected values
        /// </summary>
        public static void GetRoomDescription()
        {
            Console.Clear();
            
            IHelper.DisplayMessage("\nWould you like to get room description? Y/N ");

            while (true)
            {
                string userResponse = Console.ReadLine().ToLower();
            
                if (userResponse is "y")
                {
                    IHelper.DisplayMessage("\nI would rather not go back to the old house.");
                    break;
                }
                else if (userResponse is "n") break;
                else IHelper.DisplayMessage("\nInvalid response. Please try again: ");
            }
        }
        
        /// <summary>
        /// If user loses the adventure.
        /// </summary>
        public static void LoseAdventure()
        {
            Console.Clear();
            
            IHelper.DisplayMessage("You are dead, lol");
            
            ConfirmationMessage();
            
            Environment.Exit(0);
        }
        
        /// <summary>
        /// User wins the adventure.
        /// </summary>
        public static void WinAdventure()
        {
            IHelper.DisplayMessage("You have completed the adventure!");
        }

        public static void FightMessage()
        {
            IHelper.DisplayMessage("You have entered the fight!");
            
            ConfirmationMessage();
        }
    }
}