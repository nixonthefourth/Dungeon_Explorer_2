namespace DungeonExplorer
{
    public class Room : IHelper
    {
        /// <summary>
        /// Generates enemy in the room.
        /// </summary>
        ///
        /// <returns>
        /// Returns either a generated monster or null, in case no monsters have been created.
        /// </returns>
        public Monster GenerateRoomEnemy()
        {
            // Case where, generation is successful
            if (IHelper.GenerateRandom() <= 7) return Monster.SelectMonster();
            
            // Unsuccessful case
            else return null;
        }
    }
}