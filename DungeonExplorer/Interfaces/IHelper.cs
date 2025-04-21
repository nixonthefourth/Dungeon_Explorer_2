namespace DungeonExplorer
{
    public interface IHelper
    {
        private static Random Rand { get; } = new Random();

        /// <summary>
        /// Generates a random number from 1 seed.
        /// </summary>
        /// 
        /// <returns>
        /// Returns the random number generated from the interface's seed.
        /// </returns>
        ///
        /// <remarks>
        /// Game works within the probabilites divisible by 10. Hence, it goes from 10 to 100.
        /// The random number is unified within this method, which creates one way of generating numbers.
        /// Method is sealed as well, so it can't be modified.
        /// </remarks>
        public static sealed int GenerateRandom()
        {
            // Sets a random seed
            int rand = Rand.Next(1, 10);
            
            // Returns that random number.
            return rand;
        }
        
        /// <summary>
        /// Displays the chosen strings into the console using terminal visuals.
        /// </summary>
        /// 
        /// <param name="message">
        /// Message to be displayed.
        /// </param>
        ///
        /// <remarks>
        /// Sealed has been added in order to accomodate the nature of the method,
        /// which makes it uninheritable.
        ///
        /// Method works through displaying the string, by running a for loop.
        /// Then each inidvidual character of the array is displayed. The indexation happens through
        /// the array and loop's index as a pointer.
        /// Array is converted into a string, which is then turned into an upper-case letter.
        /// This makes code more modular and removes redundancies later.
        ///
        /// Then through the application of threading the loop is asleep, hence effect is created.
        /// </remarks>
        public static sealed void DisplayMessage(string message)
        {
            // Start of the loop
            for (int i = 0; i < message.Length; i++)
            {
                // Message output
                Console.Write(message[i].ToString().ToUpper());
                
                // Application of threading
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}