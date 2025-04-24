namespace DungeonExplorer
{
    public class GameData
    {
        // Player's data
        public int PlayerHealth { get; set; }
        public int PlayerLuck { get; set; }
        public int PlayerDamage { get; set; }
        public string PlayerName { get; set; }
        
        // Map data
        public Room currentRoom { get; set; }
    }
}