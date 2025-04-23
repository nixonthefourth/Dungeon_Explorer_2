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

        /// <summary>
        /// Generates item in the room.
        /// </summary>
        /// 
        /// <returns>
        /// Returns either a generated item or null, in case no items have been created.
        /// </returns>
        public Item GenerateRoomItems()
        {
            // Case where, generation is successful
            if (IHelper.GenerateRandom() <= 7) return Item.SelectItem();
            
            // Unsuccessful case
            else return null;
        }
    }
}