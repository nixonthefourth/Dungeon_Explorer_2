namespace DungeonExplorer
{
    public class Program
    {
        /// <summary>
        /// Entry point of the application. Initializes the game loop and begins execution.
        /// </summary>
        /// 
        /// <param name="args">
        /// Array of command-line arguments passed to the program.
        /// </param>
        public static void Main(string[] args)
        {
            GameTest.RunTest();
            GameLoop.Run();
        }
    }
}
