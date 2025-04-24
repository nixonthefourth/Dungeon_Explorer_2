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
        /// Shows the start of the story.
        /// </summary>
        ///
        /// <remarks>
        /// The input line is read, and the screen is cleared later.
        /// ConfirmationMessage() is applied.
        /// </remarks>
        public static void StoryStart()
        {
            IHelper.DisplayMessage("\nWelcome to Dungeon Explorer!\n");
            
            ConfirmationMessage();
            
            IHelper.DisplayMessage("\n***\n" +
                                   "Long time ago...\n" +
                                   "In a far-far galaxy...\n" +
                                   "Monsters out of Lincoln were born.\n \n" +
                                   "It's time for a hero to diabolically demolish them!\n" +
                                   "***\n");
            
            ConfirmationMessage();
        }
        
        /// <summary>
        /// Output Character's Name (Name Confirmation Pretty Much)
        /// </summary>
        /// 
        /// <param name="creature">
        /// Pushes the name of the character that the player defines.
        /// </param>
        ///
        /// <remarks>
        /// The input line is read, and the screen is cleared later.
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
            
            string roomMessage1 = "\nI would rather not go back to the old house.";
            string roomMessage2 = "\nSomething has creaked...";
            string roomMessage3 = "\nThis rooms smells like rats in the days of Isaac Newton";
            
            // Append An Array
            string[] roomMessage = new string[] { roomMessage1, roomMessage2, roomMessage3 };
                
            // Select The Displayed Message Randomly
            IHelper.DisplayMessage(roomMessage[IHelper.GenerateRandom() % 3]);
        }
        
        /// <summary>
        /// If the user loses the adventure.
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
    }
}