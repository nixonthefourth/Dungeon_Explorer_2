using System.Text.Json;


namespace DungeonExplorer
{
    public class SaveSystem
    {
        /// <summary>
        /// The file path where the saved data is stored to and retrieved from.
        /// </summary>
        private protected static string filePath = "gameSaveFile.json";

        /// <summary>
        /// Saves the current game state to the designated save file.
        /// </summary>
        /// <param name="data">
        /// 
        /// The object representing the current state of the game to be saved.
        /// </param>
        public static void Save(GameData data)
        {
            /*
             * Turns data into the JSON format string.
             * Adds readability to the file using the 'WriteIndented' statement.
             */
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            IHelper.DisplayMessage("Game saved.");
        }

        /// <summary>
        /// Loads the game state from the save file.
        /// </summary>
        /// 
        /// <returns>
        /// An object containing the loaded game state if the save file exists;
        /// otherwise, returns null if no save file is found.
        /// </returns>
        public static GameData Load()
        {
            // If the file exists, load the data from it.
            if (File.Exists(filePath))
            {
                // Read the file and create it into a GameData object through 'Deserialize'.
                string json = File.ReadAllText(filePath);
                GameData data = JsonSerializer.Deserialize<GameData>(json);
                
                // Message
                IHelper.DisplayMessage("Game loaded.");
                return data;
            }
            
            // If no file was found, return null.
            else
            {
                IHelper.DisplayMessage("No save file found.");
                return null;
            }
        }
    }
}