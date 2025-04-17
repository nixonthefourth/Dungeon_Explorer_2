namespace DungeonExplorer
{
    public class Rooms : IHelper
    {
        /// <summary>
        /// Generates enemy in the room.
        /// </summary>
        public Monsters GenerateRoomEnemy()
        {
            // Case where, generation is successful
            if (IHelper.GenerateRandom() <= 7)
            {
                return Monsters.SelectMonster();
            }
            
            // Unsuccessful case
            else
            {
                return null;
            }
        }
    }
}