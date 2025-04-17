namespace DungeonExplorer
{
    public class Story : IHelper
    {
        /// <summary>
        /// Confirmation sequence (Press enter to continue.)
        /// </summary>
        public static void ConfirmationMessage()
        {
            IHelper.DisplayMessage("\n\nPress Enter to continue...");
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
            IHelper.DisplayMessage("Welcome to Dungeon Explorer!");
            
            ConfirmationMessage();
            
            IHelper.DisplayMessage("***\n" +
                                   "Long time ago...\n" +
                                   "In a far-far galaxy...\n" +
                                   "Monsters out of Biggleswade were born.\n \n" +
                                   "It's time for a hero to diabolically demolish them!\n" +
                                   "***");
            
            ConfirmationMessage();
        }
        
        /// <summary>
        /// Output Character's Name (Name Confirmation Pretty Much)
        /// </summary>
        /// 
        /// <param name="characterName">
        /// Pushes the name of the character that player defines.
        /// </param>
        ///
        /// <remarks>
        /// Input line is read and the the screen is cleared later.
        /// ConfirmationMessage() is applied.
        /// </remarks>
        public static void CharacterNameConfirmation(string characterName)
        {
            IHelper.DisplayMessage($"Welcome, {characterName}!");
            
            ConfirmationMessage();
        }
        
        /// <summary>
        /// Shows the description of the room with randomly selected values
        /// </summary>
        public static void GetRoomDescription()
        {
            Console.Clear();
            
            IHelper.DisplayMessage("Would you like to get room description? Y/N ");

            while (true)
            {
                string userResponse = Console.ReadLine().ToLower();
            
                if (userResponse is "y")
                {
                    IHelper.DisplayMessage("I would rather not go back to the old house.");
                    break;
                }
                else if (userResponse is "n") break;
                else IHelper.DisplayMessage("Invalid response. Please try again: ");
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