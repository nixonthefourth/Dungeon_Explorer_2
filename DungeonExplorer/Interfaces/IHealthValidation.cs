namespace DungeonExplorer
{
    public interface IHealthValidation
    {
        /// <summary>
        /// We are validating the health of the player to check whether the player is dead or alive.
        /// In case of going below 0 health-wise, we are making it equal to 0, so bugs are prevented.
        /// And then the player is killed.
        /// </summary>
        ///
        /// <param name="player">
        /// Player's entity that is passed to the method to link player's data.
        /// </param>
        public static void HealthValidation(Creature player)
        {
            if (player.CreatureHealth <= 0)
            {
                player.CreatureHealth = 0;
                Story.LoseAdventure();
            }
        }

        /// <summary>
        /// Validates the health of a monster to ensure it does not drop below 0.
        /// Prevents errors related to negative health values.
        /// </summary>
        /// 
        /// <param name="monster">
        /// Monster entity whose health is being validated and updated if required.
        /// </param>
        public static void EnemyHealthValidation(Creature monster)
        {
            if (monster.CreatureHealth <= 0) monster.CreatureHealth = 0;
        }
    }
}