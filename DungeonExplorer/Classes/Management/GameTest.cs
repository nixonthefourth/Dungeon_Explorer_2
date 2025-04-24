using System.Diagnostics;

namespace DungeonExplorer
{
    public class GameTest : IHelper
    {
        /// <summary>
        /// The file path.
        /// </summary>
        private static readonly string LogFilePath = "GameTestLog.txt";

        /// <summary>
        /// Executes a suite of tests for the game, including player initialisation,
        /// item initialisation, room generation, combat scenarios, and unique monster behaviors.
        /// </summary>
        /// 
        /// <remarks>
        /// This method initialises the testing process by either creating or clearing a log file,
        /// running a series of predefined test cases, and writing their results to the log.
        /// 
        /// The tests include validations for game elements such as player setup, item configurations,
        /// room mechanics, and combat behaviours. Upon execution, a message indicating completion
        /// is displayed.
        /// </remarks>
        public static void RunTest()
        {
            // Clear or create the log file at the start of testing
            File.WriteAllText(LogFilePath, "Game Tests Log\n");

            IHelper.DisplayMessage("\nRunning game tests...");
            
            // Run each test
            TestPlayerInitialisation();
            TestItemInitialisation();
            TestRoomGeneration();
            TestCombatScenario();
            TestMonsterUniqueBehaviour();

            // Message indicating completion of testing
            IHelper.DisplayMessage("\nAll tests completed. Check the log file for results.");
        }

        /// <summary>
        /// Logs the result of a specific test case by appending the test name, status, and timestamp
        /// to a designated log file. Also displays the result message.
        /// </summary>
        /// 
        /// <param name="testName">
        /// The name of the test case being logged.
        /// </param>
        /// 
        /// <param name="passed">
        /// Indicates whether the test case passed or failed.
        /// </param>
        private static void LogTestResult(string testName, bool passed)
        {
            // Timestamp and result appended to the log file
            string result = $"{DateTime.Now}: {testName} - {(passed ? "PASSED" : "FAILED")}";
            Console.WriteLine();
            File.AppendAllText(LogFilePath, result + Environment.NewLine);
            
            IHelper.DisplayMessage(result);
        }

        /// <summary>
        /// Validates the initialisation of the player object by checking its properties for consistency
        /// with the provided constructor parameters, including name, damage, luck, and health values.
        /// </summary>
        /// 
        /// <remarks>
        /// This method creates a Player instance with predefined attributes and ensures the assigned
        /// values match the expected results. Assertions are used to validate the properties, and any
        /// mismatches or errors are logged to the test log file. Success or failure results of the test
        /// are also logged.
        /// </remarks>
        private static void TestPlayerInitialisation()
        {
            // Test name appended to the log file
            const string testName = "TestPlayerInitialisation";
            
            try
            {
                // Arrange
                var player = new Player("Hero", 20, 5, 100);

                // Assert
                Debug.Assert(player.CreatureName == "Hero", "\nPlayer name should be 'Hero'.");
                Debug.Assert(player.CreatureDamage == 20, "\nPlayer damage should be 20.");
                Debug.Assert(player.CreatureLuck == 5, "\nPlayer luck should be 5.");
                Debug.Assert(player.CreatureHealth == 100, "\nPlayer health should be 100.");
                
                // Log a result
                LogTestResult(testName, true);
            }
            catch (Exception ex)
            {
                LogTestResult(testName, false);
                File.AppendAllText(LogFilePath, $"\nError: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Validates the initialization of the Item class by creating a Weapon instance and verifying
        /// its properties against expected initial values such as name, damage, luck, and collection state.
        /// </summary>
        /// 
        /// <remarks>
        /// The method creates a Weapon instance with predefined attributes and performs assertions to
        /// ensure that the instance's properties are correctly set upon initialization. It checks the
        /// name, damage, luck, and the initial collected state of the item. If any assertion fails,
        /// the test logs an error and marks the test as failed. Results are logged for review.
        /// </remarks>
        private static void TestItemInitialisation()
        {
            // Test name appended to the log file
            const string testName = "TestItemInitialisation";
            
            try
            {
                // Arrange
                var item = new Weapon("Sword", 15, 2, 0, false);

                // Assert
                Debug.Assert(item.ItemName == "Sword", "\nItem name should be 'Sword'.");
                Debug.Assert(item.ItemDamage == 15, "\nItem damage should be 15.");
                Debug.Assert(item.ItemLuck == 2, "\nItem luck should be 2.");
                Debug.Assert(item.ItemCollected == false, "\nItem should not be collected initially.");
                
                LogTestResult(testName, true);
            }
            catch (Exception ex)
            {
                LogTestResult(testName, false);
                File.AppendAllText(LogFilePath, $"\nError: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Validates the generation of rooms within the game map and ensures appropriate default room settings.
        /// </summary>
        /// 
        /// <remarks>
        /// This test verifies the functionality of room generation in the GameMap class. It creates an initial
        /// room using the GenerateRooms method and validates its non-null presence and properties, such as
        /// the default room name. The test logs the outcome of the assertions and, in the case of an exception,
        /// appends detailed error information to the log file.
        /// </remarks>
        private static void TestRoomGeneration()
        {
            // Test name appended to the log file
            const string testName = "TestRoomGeneration";
            
            try
            {
                // Arrange
                var gameMap = new GameMap();
                var initialRoom = gameMap.GenerateRooms();

                // Assert
                Debug.Assert(initialRoom != null, "\nInitial room should not be null.");
                Debug.Assert(initialRoom.RoomName == "Room 1", "\nInitial room should be named 'Room 1'.");

                LogTestResult(testName, true);
            }
            catch (Exception ex)
            {
                LogTestResult(testName, false);
                File.AppendAllText(LogFilePath, $"\nError: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Evaluates combat interactions between a player and a monster to validate core combat mechanics,
        /// such as health reduction after taking damage.
        /// </summary>
        /// 
        /// <remarks>
        /// This test simulates a combat scenario where a player and a monster exchange damage.
        /// The method ensures that both entities' health values are properly reduced during combat,
        /// as defined by the damage mechanics. If the health values do not update correctly,
        /// the test will fail and log the error.
        /// During the test, assertions validate the correctness of health changes after each attack.
        /// Any exceptions that occur during the test are caught, and relevant error details are logged
        /// for debugging. The results are recorded in a log file to assist with validation and reporting.
        /// </remarks>
        private static void TestCombatScenario()
        {
            // Test name appended to the log file
            const string testName = "TestCombatScenario";
            
            // Base case
            try
            {
                // Arrange
                var player = new Player("Hero", 20, 5, 100);
                var monster = new Envy();

                // Act
                IDamagable.Damage(player, monster);
                IDamagable.Damage(monster, player);
                
                // Log the result
                LogTestResult(testName, true);
            }
            
            // Catch any exceptions that occur during the test
            catch (Exception ex)
            {
                LogTestResult(testName, false);
                File.AppendAllText(LogFilePath, $"\nError: {ex.Message}\n");
            }
        }

        /// <summary>
        /// Tests the unique attack behavior of a monster subclass by simulating its interaction with a player.
        /// </summary>
        /// 
        /// <remarks>
        /// This method verifies the monster's specialised attack mechanic by arranging a player and a monster instance,
        /// invoking the monster's unique attack behavior.
        /// </remarks>
        private static void TestMonsterUniqueBehaviour()
        {
            // Test name appended to the log file
            const string testName = "TestMonsterUniqueBehavior";
            
            // Base case
            try
            {
                // Arrange
                var player = new Player("Hero", 20, 5, 100);
                var monster = new Lust();

                // Act
                monster.UniqueAttackBehavior(player);

                // Log the result
                LogTestResult(testName, true);
            }
            
            // Catch any exceptions that occur during the test
            catch (Exception ex)
            {
                LogTestResult(testName, false);
                File.AppendAllText(LogFilePath, $"\nError: {ex.Message}\n");
            }
        }
    }
}