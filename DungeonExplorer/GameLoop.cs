using System.IO.MemoryMappedFiles;

namespace DungeonExplorer

{
    public class GameLoop
    {
        /// <summary>
        /// Running sequence, which will be passed later into entry point of the program.
        /// </summary>
        public static void Run()
        {
            // Initialising new story line
            Story story = new Story();
            
            // Initialising new player in the game
            Player player = new Player(null, 10, 1, 100);
            
            // Runtime
            // Starting story
            story.StoryStart();
            player.GetCreatureName();
        }

        private static void FightSystem(Creature creatureDamages, Creature creatureReceives)
        {
            
        }
    }
}