namespace DungeonExplorer

{
    public class GameLoop
    {
        /// <summary>
        /// Running sequence, which will be passed later into entry point of the program.
        /// </summary>
        public static void Run()
        {
            // Initialising the new player in the game
            Player player = new Player(null, 10, 1, 100);
            
            // Runtime
            // Starting story
            Story.StoryStart();
            player.GetCreatureName();
            Story.CharacterNameConfirmation(player);
            
            // Testing Room
            Rooms room1 = new Rooms();
            Fight.FightEncounter(player, room1);
        }
    }
}