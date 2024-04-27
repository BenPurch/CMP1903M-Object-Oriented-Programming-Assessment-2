using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        // Method for testing the Sevens Out game
        public static void SevensOutTest(string player)
        {
            // Create a SevensOut object
            Game.SevensOut sevensOut = new Game.SevensOut();

            if (player == "1")
            {
                // Call the PlayerOne method
                int p1Score = sevensOut.PlayerOne();
                // Use Debug.Assert to check if p1Score is 7
                Debug.Assert(p1Score == 7, "Test Successful\nPlayer One rolled a total of 7.");
                // Message for conclusion of player test
                Console.Clear();
                Console.WriteLine("~~~~~~Player One~~~~~~\n" +
                                  "~~~~Test Concluded~~~~\n\n" +
                                  "Press any key to continue..");
            }
            else if (player == "2")
            {
                // Call the PlayerTwo method
                int p2Score = sevensOut.PlayerTwo();
                // Use Debug.Assert to check if p2Score is 7
                Debug.Assert(p2Score == 7, "Test Successful\nPlayer Two rolled a total of 7.");
                // Message for conclusion of player test
                Console.Clear();
                Console.WriteLine("~~~~~~Player Two~~~~~~\n" +
                                  "~~~~Test Concluded~~~~\n\n" +
                                  "Press any key to continue..");
            }
            else
            {
                // Call the PlayerTwoCpu method to
                int p2cScore = sevensOut.PlayerTwoCpu();
                // Use Debug.Assert to check if p2cScore is 7
                Debug.Assert(p2cScore == 7, "Test Successful\nCPU rolled a total of 7.");
                // Message for conclusion of player test
                Console.Clear();
                Console.WriteLine("~~~~~~~~~CPU~~~~~~~~~~\n" +
                                  "~~~~Test Concluded~~~~\n\n" +
                                  "Press any key to continue..");
            }
                
        }

        // Method for testing the Three or More Game
        public static void ThreeOrMoreTest(string cpu)
        {
            // Create a ThreeOrMore object
            Game.ThreeOrMore threeOrMore = new Game.ThreeOrMore();

            // Call the PlayerOne method to simulate a game
            int playerScore = threeOrMore.PlayerOne(cpu, 0, 0);
            // Use Debug.Assert to check if p1Score is greater than or equal to 20
            Debug.Assert(playerScore >= 20, "Test Successful\nGame has ended with a score of greater than 20");
            // Message for conclusion of game test
            Console.WriteLine("~~~~~Three or More~~~~\n" +
                              "~~~~Test Concluded~~~~\n\n" +
                              "Press any key to continue..");
            Console.ReadKey();
        }

        // Method for presenting the first menu to the user
        public static void TestMenuOne()
        {
            // Gathering user input for choice of Game
            Console.WriteLine("~~~~~~Test Menu~~~~~~~" +
                              "\n\nSevens Out         [1]" +
                              "\nThree Or More      [2]" +
                              "\nStatistics Data Unavailable" +
                              "\nExit               [4]");
            string gameChoice = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            if (gameChoice.Equals("1", StringComparison.OrdinalIgnoreCase) || gameChoice.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                TestMenuTwo(gameChoice);
            }
            else if (gameChoice == "4")
            {
                try
                {
                    Program program = new Program();
                    program.CloseWindow();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    TestMenuOne();
                }
            }
            else
            {
                GameTester();
            }
        }

        // Method for presentng the second menu to the user
        public static void TestMenuTwo(string gameChoice) 
        {
            // Gathering Player choice
            Console.WriteLine("~~~~~~Test Menu~~~~~~~" +
                              "\n\nPlayer Two join    [1]" +
                              "\nPlay against CPU   [2]" +
                              "\n\nBack               [4]");
            string playerChoice = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            // Exception handling
            try
            {

                // Playing Sevens Out with a second person
                if (gameChoice == "1" && playerChoice == "1")
                {
                    SevensOutTest("1");
                    Console.ReadKey();
                    SevensOutTest("2");
                    Console.ReadKey();

                    // Returning to the game menu
                    Console.Clear();
                    GameTester();
                }
                // Playing Sevens Out with the CPU
                else if (gameChoice == "1" && playerChoice == "2")
                {
                    SevensOutTest("1");
                    Console.ReadKey();
                    SevensOutTest("cpu");
                    Console.ReadKey();

                    // Returning to the game menu
                    Console.Clear();
                    GameTester();
                }
                // Playing Three Or More with another person
                else if (gameChoice == "2" && playerChoice == "1")
                {
                    ThreeOrMoreTest("n");

                    // Sending the user back to the menu
                    Console.Clear();
                    GameTester();
                }
                // Playing Three Or More with the CPU
                else if (gameChoice == "2" && playerChoice == "2")
                {
                    ThreeOrMoreTest("y");

                    // Sending the user Back to the menu
                    Console.Clear();
                    GameTester();
                }
                // Go back to menu one
                else if (playerChoice == "4")
                {
                    Console.Clear();
                    GameTester();
                }
                // Wrong key press
                else
                {
                    Console.Clear();
                    TestMenuTwo(gameChoice);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Please Input 1 - 4 in either option");
                Console.ReadKey();
                Console.Clear();
                GameTester();
            }

        }

        // Method for test start
        public static void GameTester()
        {
            TestMenuOne();
        }
    }
}
