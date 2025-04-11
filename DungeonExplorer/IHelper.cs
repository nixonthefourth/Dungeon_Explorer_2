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
        public static int GenerateRandom()
        {
            int rand = Rand.Next(0, 10);
            
            return rand;
        }
    }
}