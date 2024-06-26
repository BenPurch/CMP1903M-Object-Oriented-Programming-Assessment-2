﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {   
        private static readonly Random random = new Random();

        public string PlayerName(bool playerIsUser)
        {
            try
            {
                // Checking if the player is the winner
                if (playerIsUser == true)
                {
                    // Prompting the user for their name
                    Console.WriteLine("Please type your name and press ENTER to submit:");
                    string playerName = Console.ReadLine();

                    // Name choice confirmation
                    Console.WriteLine("Your name is: " + playerName + 
                                    "\nCorrect            [1]\n" +
                                      "Go Back            [2]");
                    string nameChoice = Console.ReadKey().KeyChar.ToString();

                    // Letting the user re-chose their name if chosen or less than 3 chars
                    Console.Clear();
                    if (nameChoice == "1" && playerName.Length >= 3)
                    {
                        return playerName;
                    }
                    else if (nameChoice == "2")
                    {
                        Console.WriteLine("Name Re-Entry");
                        return PlayerName(playerIsUser);
                    }
                    else if (nameChoice == "1" && playerName.Length < 3)
                    {
                        Console.WriteLine("Name must be three characters or more!\nName Re-Entry");
                        return PlayerName(playerIsUser);
                    }
                    else
                    {
                        Console.WriteLine("Please enter Either 1 or 2");
                        return PlayerName(playerIsUser);
                    }
                }
                // If user is the cpu it automatically returns CPU as the name
                else
                {
                    return "CPU";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("That is not a valid name!\nTry again..");
                Console.ReadKey();
                Console.Clear();
                PlayerName(playerIsUser);
            }
            return "error";
        }

        // Places scores and names together in the correct format for the history section of Statistics.txt
        public string[] ScoresForHistory(string playerOneName, string playerTwoName, string gameMode, int p1Score, int p2Score)
        {
            // making sure all array values are strings
            string playerOneScore = p1Score.ToString();
            string playerTwoScore = p2Score.ToString();
            // Adding all elements to the array
            string[] scoresForHistory = {"", gameMode, playerOneName, playerOneScore, "", gameMode, playerTwoName, playerTwoScore};
            return scoresForHistory;
        }

        // Nested SevensOut() class within Game class
        public class SevensOut
        {
            // Making the two dice objects
            private Die die1;
            private Die die2;

            public SevensOut()
            {
                // Initialising the dice
                die1 = new Die();
                die2 = new Die();
            }

            // Method for Player One
            public int PlayerOne()
            {
                // Setting the score to 0
                int p1Score = 0;
                bool roundEnd = false;

                while (!roundEnd)
                {

                    // Player One's turn with input for roll simulation
                    Console.WriteLine("Player 1 Roll: ");
                    Console.ReadKey();
                    Console.Clear();
                    // Rolling each dice
                    int p1Roll1 = die1.Roll();
                    int p1Roll2 = die2.Roll();
                    // Combining to get total of both rolls
                    int p1RollTotal = p1Roll1 + p1Roll2;
                    // Double score if doubles
                    if (p1Roll1 == p1Roll2)
                    {
                        p1RollTotal += p1RollTotal;
                    }
                    // Incrementing the score
                    p1Score += p1RollTotal;
                    // Presenting each die, their total, and the total score to the user
                    Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                      "\nDie 1: " + p1Roll1 +
                                      "\nDie 2: " + p1Roll2 +
                                      "\n\nRoll total: " + p1RollTotal +
                                      "\nPlayer 1 score: " + p1Score +
                                      "\n");
                    // Detecting the Game end
                    if (p1RollTotal == 7)
                    {
                        // Game end message and returning the players score
                        Console.Clear();
                        Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                          "\n\nPlayer One rolled a 7" +
                                          "\nPlayer Two's turn\n");
                        roundEnd = true;
                    }
                }
                return p1Score;
            }

            // Method for player Two
            public int PlayerTwo()
            {
                // Setting the score to 0
                int p2Score = 0;
                bool roundEnd = false;

                while (!roundEnd)
                {

                    // Player Two's turn with input for roll simulation
                    Console.WriteLine("Player 2 Roll: ");
                    Console.ReadKey();
                    Console.Clear();
                    // Rolling each dice
                    int p2Roll1 = die1.Roll();
                    int p2Roll2 = die2.Roll();
                    // Combining to get total of both rolls
                    int p2RollTotal = p2Roll1 + p2Roll2;
                    // Double score if doubles
                    if (p2Roll1 == p2Roll2)
                    {
                        p2RollTotal += p2RollTotal;
                    }
                    // Incrementing the score
                    p2Score += p2RollTotal;
                    // Presenting each die, their total, and the total score to the user
                    Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                      "\nDie 1: " + p2Roll1 +
                                      "\nDie 2: " + p2Roll2 +
                                      "\n\nRoll total: " + p2RollTotal +
                                      "\nPlayer 2 score: " + p2Score +
                                      "\n");
                    // Detecting the Game end
                    if (p2RollTotal == 7)
                    {
                        // Game end message and returning the players score
                        Console.Clear();
                        Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                          "\n\nPlayer Two rolled a 7" +
                                          "\nEnd of Game!\n");
                        roundEnd = true;
                    }
                }
                return p2Score;
            }

            // Method for CPU
            public int PlayerTwoCpu()
            {
                // Setting the score to 0
                int p2cScore = 0;
                bool roundEnd = false;

                while (!roundEnd)
                {



                    // CPU's turn
                    Console.WriteLine("Cpu Roll: ");
                    // Faking waiting to roll
                    Thread.Sleep(750);
                    Console.WriteLine("Rolling...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    // Rolling each dice
                    int p2cRoll1 = die1.Roll();
                    int p2cRoll2 = die2.Roll();
                    // Combining to get total of both rolls
                    int p2cRollTotal = p2cRoll1 + p2cRoll2;
                    // Double score if doubles
                    if (p2cRoll1 == p2cRoll2)
                    {
                        p2cRollTotal += p2cRollTotal;
                    }
                    // Incrementing the score
                    p2cScore += p2cRollTotal;
                    // Presenting each die, their total, and the total score to the user
                    Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                      "\nDie 1: " + p2cRoll1 +
                                      "\nDie 2: " + p2cRoll2 +
                                      "\n\nRoll total: " + p2cRollTotal +
                                      "\nCPU score: " + p2cScore +
                                      "\n");
                    // Detecting the Game end
                    if (p2cRollTotal == 7)
                    {
                        // Game end message and returning the players score
                        Console.Clear();
                        Console.WriteLine("~~~~~Sevens Out~~~~~~~" +
                                          "\n\nCPU rolled a 7" +
                                          "\nEnd of game!\n");
                        roundEnd = true;
                    }
                }
                return p2cScore;
            }
        }

        // Nested ThreeOrMore() class within Game class
        public class ThreeOrMore : Game
        {
            //Making the five dice objects
            private Die die1;
            private Die die2;
            private Die die3;
            private Die die4;
            private Die die5;
            
            public ThreeOrMore()
            {
                // Initialising the dice
                die1 = new Die();
                die2 = new Die();
                die3 = new Die();
                die4 = new Die();
                die5 = new Die();
            }

            // setting roundScore
            int roundScore = 0;

            // Method for the main element of the RollDisplayAndScore() method for self referral
            private int RollDisplayAndScoreMainElement(string cpu, string playerTurn, int playerScore, int otherPlayerScore, int roll1, int roll2, int roll3, int roll4, int roll5)
            {
                // Output for Player
                Console.Clear();
                Console.WriteLine("~~~Three or More~~~\n\n" +
                                "\nDie 1: " + roll1 +
                                "\nDie 2: " + roll2 +
                                "\nDie 3: " + roll3 +
                                "\nDie 4: " + roll4 +
                                "\nDie 5: " + roll5 +
                                "\n");
                // Adding rolls to a list
                List<int> rollList = new List<int>();
                rollList.Add(roll1);
                rollList.Add(roll2);
                rollList.Add(roll3);
                rollList.Add(roll4);
                rollList.Add(roll5);

                // Count occurrences of each roll
                Dictionary<int, int> counts = new Dictionary<int, int>();
                foreach (int roll in rollList)
                {
                    if (counts.ContainsKey(roll))
                        counts[roll]++;
                    else
                        counts[roll] = 1;
                }

                // Find the maximum count
                int maxCount = counts.Values.Max();

                // Find the rolls with the maximum count
                List<int> maxMatches = counts.Where(keyValue => keyValue.Value == maxCount).Select(keyValue => keyValue.Key).ToList();

                // Picking the first element of maxMatches to make sure that only one pair remains in a reroll
                int match = maxMatches[0];

                // Output the result
                switch (maxCount)
                {
                    // Result for no matching numbers
                    case 1:
                        Console.WriteLine("No Matches");
                        break;
                    // Result for two matching numbers
                    case 2:
                        // Prompting the user for a reroll and creating an integer reRollCheck for user prompt
                        Console.WriteLine("Pair!\nReroll remaining?  [1]\nReroll All?        [2]");
                        int reRollCheck = 0;
                        // If/else statement to detect if the CPU is playing
                        if (cpu == "n" || playerTurn == "y")
                        {
                            // Gathering user input and converting to an integer
                            Console.WriteLine("~~~Player Turn~~~~");
                            reRollCheck = int.Parse(Console.ReadKey().KeyChar.ToString());
                        }
                        else
                        {
                            // Choosing a random option for the CPU
                            reRollCheck = random.Next(1, 3);
                            // Simulating CPU roll time
                            Console.WriteLine("~~~~~CPU Turn~~~~~");
                            Thread.Sleep(750);
                            Console.WriteLine("Rolling...");
                            Thread.Sleep(1000);
                        }
                        Console.WriteLine();

                        // Cases for reroll with or without matching pair
                        switch (reRollCheck)
                        {
                            // Case of keeping matching pair
                            case 1:
                                // Rerolling each die if it doesnt match the chosen pair
                                if (match != roll1)
                                {
                                    roll1 = die1.Roll();
                                }
                                if (match != roll2)
                                {
                                    roll2 = die2.Roll();
                                }
                                if (match != roll3)
                                {
                                    roll3 = die3.Roll();
                                }
                                if (match != roll4)
                                {
                                    roll4 = die4.Roll();
                                }
                                if (match != roll5)
                                {
                                    roll5 = die5.Roll();
                                }

                                // Re running this method with the new dice values
                                RollDisplayAndScoreMainElement(cpu, playerTurn, playerScore, otherPlayerScore, roll1, roll2, roll3, roll4, roll5);
                                break;
                            // Case of rerolling all
                            case 2:
                                // Restarting the RollDisplayAndScore() method
                                RollDisplayAndScore(cpu, playerTurn, playerScore, otherPlayerScore);
                                break;
                        }
                        break;
                    // Result for 3 matching numbers
                    case 3:
                        Console.WriteLine("Three's Company!");
                        roundScore = 3;
                        break;
                    // Result for 4 matching numbers
                    case 4:
                        Console.WriteLine("Four's a Score!");
                        roundScore = 6;
                        break;
                    // Result for 5 matching numbers
                    case 5:
                        Console.WriteLine("Five is More!");
                        roundScore = 12;
                        break;
                }
                return roundScore;
            }

            // Function for rolling the dice and returning the score of the round
            private int RollDisplayAndScore(string cpu, string playerTurn, int playerScore, int otherPlayerScore)
            {
                try
                {
                    // Rolling individual dice
                    int roll1 = die1.Roll();
                    int roll2 = die2.Roll();
                    int roll3 = die3.Roll();
                    int roll4 = die4.Roll();
                    int roll5 = die5.Roll();

                    // Gathering the round score from the RollDisplayAndScoreMainElement() method
                    int roundScore = RollDisplayAndScoreMainElement(cpu, playerTurn, playerScore, otherPlayerScore, roll1, roll2, roll3, roll4, roll5);

                    // Returning the round score for use in the individual player methods, PlayerOne(), PlayerTwo(), PlayerTwoCpu()
                    return roundScore;
                }
                // Catching any exceptions and rerolling (exceptions come from reroll selection)
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    RollDisplayAndScore(cpu, playerTurn, playerScore, otherPlayerScore);
                    return roundScore;
                }
                
            }

            // Method for Player One
            public int PlayerOne(string cpu, int p1Score, int p2Score, int p1Rolls, int p2Rolls)
            {
                p1Rolls += 1;

                // Player One's turn with input for roll simulation
                Console.WriteLine("~~~Player Turn~~~~");
                Console.WriteLine("Player One Roll: ");
                Console.ReadKey();

                // Adding the resulting score of the round to the total score for player one and outputting the score
                p1Score += RollDisplayAndScore(cpu, "y", p1Score, p2Score);
                Console.WriteLine("Player One score: " + p1Score + "\nPlayer Two score: " + p2Score);

                // Checking the score for when the game is over
                if (p1Score >= 20)
                {
                    Thread.Sleep(2000);
                    Console.Clear();

                    // Gathering Player names
                    string playerOneName = PlayerName(true);
                    // Setting base value for playerTwoName
                    string playerTwoName = "Error";

                    switch (cpu)
                    {
                        case "y":
                            playerTwoName = PlayerName(false);
                            break;
                        case "n":
                            playerTwoName = PlayerName(true);
                            break;
                    }

                    Console.WriteLine("~~~Three or More~~~\n\n" +
                                      playerOneName + " wins" +
                                      "\nScore: " + p1Score + 
                                      "\n\n" + playerTwoName + " Score: " + p2Score);

                    string[] scoresForHistory = ScoresForHistory(playerOneName, playerTwoName, "Three or More", p1Rolls, p2Rolls);
                    Statistics statistics = new Statistics();
                    Statistics.AppendStatistics(scoresForHistory);

                    Console.ReadKey();
                    return p1Score;
                }

                // Checking for who player one is playing against and swapping goes accordingly
                if (cpu == "n")
                {
                    PlayerTwo(cpu, p2Score, p1Score, p1Rolls, p2Rolls);
                }
                else
                {
                    PlayerTwoCpu(cpu, p2Score, p1Score, p1Rolls, p2Rolls);
                }

                return p1Score;
            }

            // Method for Player Two
            public int PlayerTwo(string cpu, int p2Score, int p1Score, int p1Rolls, int p2Rolls)
            {
                p2Rolls += 1;

                // Player Two's turn with input for roll simulation
                Console.WriteLine("~~~Player Turn~~~~");
                Console.WriteLine("Player Two Roll: ");
                Console.ReadKey();

                // Adding the resulting score of the round to the total score for player two and outputting the score
                p2Score += RollDisplayAndScore(cpu, "y", p2Score, p1Score);
                Console.WriteLine("Player One score: " + p1Score + "\nPlayer Two score: " + p2Score);

                // Checking the score for when the game is over
                if (p2Score >= 20)
                {
                    Thread.Sleep(2000);
                    Console.Clear();

                    // Gathering Player names
                    string playerOneName = PlayerName(true);
                    string playerTwoName = PlayerName(true);

                    Console.WriteLine("~~~Three or More~~~\n\n" +
                                      playerTwoName + " wins" +
                                      "\nScore: " + p2Score + 
                                      "\n\n" + playerOneName + " Score: " + p1Score);

                    string[] scoresForHistory = ScoresForHistory(playerOneName, playerTwoName, "Three or More", p1Rolls, p2Rolls);
                    Statistics statistics = new Statistics();
                    Statistics.AppendStatistics(scoresForHistory);

                    Console.ReadKey();
                    return p1Score;
                }

                // Returning to player one
                return PlayerOne(cpu, p1Score, p2Score, p1Rolls, p2Rolls);
            }

            // Method for CPU
            public int PlayerTwoCpu(string cpu, int p2cScore, int p1Score, int p1Rolls, int p2Rolls)
            {
                p2Rolls += 1;

                // CPU's turn with input for roll simulation
                Console.WriteLine("~~~~~CPU Turn~~~~~");
                Console.WriteLine("Computer Roll: ");
                Thread.Sleep(750);
                Console.WriteLine("Rolling...");
                Thread.Sleep(1000);

                // Adding the resulting score of the round to the total score for the CPU and outputting the score
                p2cScore += RollDisplayAndScore(cpu, "n", p2cScore, p1Score);
                Console.WriteLine("Player One score: " + p1Score + "\nCPU score: " + p2cScore);

                // Checking the score for when the game is over
                if (p2cScore >= 20)
                {
                    Thread.Sleep(2000);
                    Console.Clear();

                    // Gathering Player names
                    string playerOneName = PlayerName(true);
                    string playerTwoName = PlayerName(false);

                    Console.WriteLine("~~~Three or More~~~\n\n" +
                                      playerTwoName + " wins" +
                                      "\nScore: " + p2cScore + 
                                      "\n\n" + playerOneName + " Score: " + p1Score);

                    string[] scoresForHistory = ScoresForHistory(playerOneName, playerTwoName, "Three or More", p1Rolls, p2Rolls);
                    Statistics statistics = new Statistics();
                    Statistics.AppendStatistics(scoresForHistory);

                    Console.ReadKey();
                    return p2cScore;
                }

                // Returning to player one
                return PlayerOne(cpu, p1Score, p2cScore, p1Rolls, p2Rolls);
            }

        }

        // Method for first menu
        public void MenuOne()
        {
            // Gathering user input for choice of Game
            Console.WriteLine("~~~~~~Game Menu~~~~~~~" +
                              "\n\nSevens Out         [1]" +
                              "\nThree Or More      [2]" +
                              "\nStatistics Data    [3]" +
                              "\nExit               [4]");
            string gameChoice = Console.ReadKey().KeyChar.ToString();
            Console.Clear();
            if (gameChoice.Equals("1", StringComparison.OrdinalIgnoreCase) || gameChoice.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                MenuTwo(gameChoice);
            }
            else if (gameChoice == "3")
            {
                try
                {
                    Stats();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    MenuOne();
                }
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
                    MenuOne();
                }
            }
            else
            {
                GameStart();
            }
        }

        // Method for second menu
        public void MenuTwo(string gameChoice)
        {
            // Gathering Player choice
            Console.WriteLine("~~~~~~Game Menu~~~~~~~" +
                              "\n\nPlayer Two join    [1]" +
                              "\nPlay against CPU   [2]" +
                              "\n\nBack               [4]");
            string playerChoice = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            // Exception handling
            try
            {
                // Setting the base score for the players of Three Or More
                int tomBaseScore = 0;


                // Playing Sevens Out with a second person
                if (gameChoice == "1" && playerChoice == "1")
                {
                    // Instantiating the game
                    SevensOut sevensOut = new SevensOut();
                    // Calling the game methods for each player and recieving their individual final scores
                    int p1Score = sevensOut.PlayerOne();
                    int p2Score = sevensOut.PlayerTwo();

                    // Gathering Player names
                    string playerOneName = PlayerName(true);
                    string playerTwoName = PlayerName(true);

                    // Final messages for each end-of-game event
                    if (p1Score > p2Score)
                    {
                        Console.WriteLine(playerOneName + " wins with " + p1Score + " points!" +
                                          "\n" + playerTwoName + " scored: " + p2Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (p1Score < p2Score)
                    {
                        Console.WriteLine(playerTwoName + " wins with " + p2Score + " points!" +
                                          "\n" + playerOneName + " scored: " + p1Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Both Players Tied!\n" + playerOneName + " Scored: " + p1Score +
                                          "\n" + playerTwoName + " Scored: " + p2Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    string[] scoresForHistory = ScoresForHistory(playerOneName, playerTwoName, "Sevens Out", p1Score, p2Score);
                    Statistics statistics = new Statistics();
                    Statistics.AppendStatistics(scoresForHistory);

                    // Returning to the game menu
                    GameStart();
                }
                // Playing Sevens Out with the CPU
                else if (gameChoice == "1" && playerChoice == "2")
                {
                    // Instantiating the game
                    SevensOut sevensOut = new SevensOut();
                    // Calling the game methods for each player and recieving their individual final scores
                    int p1Score = sevensOut.PlayerOne();
                    int p2Score = sevensOut.PlayerTwoCpu();

                    // Gathering Player names
                    string playerOneName = PlayerName(true);
                    string playerTwoName = PlayerName(false);

                    // Final messages for each end-of-game event
                    if (p1Score > p2Score)
                    {
                        Console.WriteLine(playerOneName + " wins with " + p1Score + " points!" +
                                          "\n" + playerTwoName + " score: " + p2Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (p1Score < p2Score)
                    {
                        Console.WriteLine(playerTwoName + " wins with " + p2Score + " points!" +
                                          "\n" + playerOneName + " score: " + p1Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Both Players Tied!\n" + playerOneName + " Score: " + p1Score +
                                          "\n" + playerTwoName + " Score: " + p2Score + "\n");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    string[] scoresForHistory = ScoresForHistory(playerOneName, playerTwoName, "Sevens Out", p1Score, p2Score);
                    Statistics statistics = new Statistics();
                    Statistics.AppendStatistics(scoresForHistory);

                    // Returning to the game menu
                    GameStart();
                }


                // Playing Three Or More with another person
                else if (gameChoice == "2" && playerChoice == "1")
                {
                    // Instantiating the game
                    ThreeOrMore threeOrMore = new ThreeOrMore();

                    // Passing "n" to indicate playing against another player
                    threeOrMore.PlayerOne("n", tomBaseScore, tomBaseScore, 0, 0);

                    // Sending the user back to the menu
                    Console.Clear();
                    GameStart();
                }
                // Playing Three Or More with the CPU
                else if (gameChoice == "2" && playerChoice == "2")
                {
                    // Instantiating the game
                    ThreeOrMore threeOrMore = new ThreeOrMore();

                    // Passing "y" to indicate playing against the CPU
                    threeOrMore.PlayerOne("y", tomBaseScore, tomBaseScore, 0, 0);

                    // Sending the user Back to the menu
                    Console.Clear();
                    GameStart();
                }
                // Go back to menu one
                else if (playerChoice == "4")
                {
                    Console.Clear();
                    GameStart();
                }
                // Wrong key press
                else
                {
                    Console.Clear();
                    MenuTwo(gameChoice);
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Please Input 1-4 in either option");
                Console.ReadKey();
                Console.Clear();
                GameStart();
            } 
        }

        // History menu inside the stats menu
        public void History()
        {
            string[] historyList = Statistics.History();
            // Lets the user pick what game's history they wish to view
            Console.Clear();
            Console.WriteLine("~~~~~~~History~~~~~~~" +
                              "\n" +
                              "\nSevens Out         [1]" +
                              "\nThree or More      [2]" +
                              "\n" +
                              "\nBack               [4]");

            int historyChoice = int.Parse(Console.ReadKey().KeyChar.ToString());

            try
            {
                switch (historyChoice)
                {
                    case 1: // Sevens Out history viewer
                        Console.Clear();
                        Console.WriteLine("~~~~~Sevens Out~~~~~~\n");
                        // Loop through every fourth line starting from index 1
                        for (int i = 0; i < historyList.Length; i += 4)
                        {
                             // Check if the index is within the bounds of the list and there's a corresponding line starting from index 2
                             if (historyList[i] == "Sevens Out")
                             {
                                // Print the lines adjacent to each other
                                Console.WriteLine(historyList[i + 1] + " " + historyList[i + 2]);
                             }
                        }

                        Console.WriteLine("\nBack         [Any Key]");
                        Console.ReadKey();
                        Console.Clear();
                        History();
                        break; 
                    case 2: // Three or More history viewer
                        Console.Clear();
                        Console.WriteLine("~~~~Three or More~~~~\n");
                        // Loop through every fourth line starting from index 1
                        for (int i = 0; i < historyList.Length; i += 4)
                        {
                            // Check if the index is within the bounds of the list and there's a corresponding line starting from index 2
                            if (historyList[i] == "Three or More")
                            {
                                // Print the lines adjacent to each other
                                Console.WriteLine(historyList[i + 1] + " " + historyList[i + 2]);
                            }
                        }

                        Console.WriteLine("\nBack         [Any Key]");
                        Console.ReadKey();
                        Console.Clear();
                        History();
                        break;
                    case 4: // Go Back
                        Console.Clear();
                        Stats();
                        break;
                }
            }
            catch (Exception p)
            {
                History();
            }

            
        }

        // Method for Statistic selection in the menu
        public void Stats()
        {
            Console.WriteLine("~~~~~~Stats Menu~~~~~~" +
                            "\n" +
                            "\nHigh Scores        [1]" +
                            "\nPlay Count         [2]" +
                            "\nScore History      [3]" +
                            "\nBack               [4]");
            int statisticsChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            try
            {
                switch (statisticsChoice)
                {
                    case 1: // Presents high scores from Statistics.txt

                        int sevensOutTopScore = int.Parse(Statistics.LineSelector("sevensOutTopScore"));
                        string sevensOutTopPlayer = Statistics.LineSelector("sevensOutTopPlayer");

                        int threeOrMoreTopScore = int.Parse(Statistics.LineSelector("threeOrMoreTopScore"));
                        string threeOrMoreTopPlayer = Statistics.LineSelector("threeOrMoreTopPlayer");

                        Console.Clear();
                        Console.WriteLine("~~~~~High Scores~~~~~" +
                                       "\n" +
                                       "\n     Sevens Out:" + 
                                       "\n" +
                                       "\nScore:  " + sevensOutTopScore + 
                                       "\nPlayer: " + sevensOutTopPlayer +
                                       "\n" +
                                       "\n" +
                                       "\n    Three or More:" +
                                       "\n" +
                                       "\nScore:  " + threeOrMoreTopScore +
                                       "\nPlayer: " + threeOrMoreTopPlayer + 
                                       "\n" +
                                       "\nBack         [Any Key]");
                        
                        // Exits when key pressed
                        Console.ReadKey();
                        Console.Clear();
                        Stats();
                        break;
                    case 2: // Presents play count from Statistics.txt

                        int sevensOutPlayCount = int.Parse(Statistics.LineSelector("sevensOutPlayCount"));
                        int threeOrMorePlayCount = int.Parse(Statistics.LineSelector("threeOrMorePlayCount"));

                        Console.Clear();
                        Console.WriteLine("~~~~~Play Count~~~~~~" +
                                       "\n" +
                                       "\n  Sevens Out:     " + sevensOutPlayCount +
                                       "\n  Three or More:  " + threeOrMorePlayCount +
                                       "\n" +
                                       "\nBack         [Any Key]");

                        // Exits when key pressed
                        Console.ReadKey();
                        Console.Clear();
                        Stats();
                        break;
                    case 3: // Presents History

                        // Redirects to the History menu
                        History();
                        
                        break;
                    case 4: // Goes Back
                        Console.Clear();
                        GameStart();
                        break;
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("Please Input either 1-4");
                Console.ReadKey();
                Console.Clear();
                GameStart();
            }
        }

        // Method for game start
        public void GameStart()
        {
            // Calls the first menu
            MenuOne();
        }

        // Closes the window
        static void CloseWindow()
        {
            // Prompts user to confirm choice
            Console.WriteLine("Press the X key to confirm closing the window" +
                              "\nOr any other key to stay");
            string stayOrClose = Console.ReadKey().KeyChar.ToString();
            if (stayOrClose.ToLower() == "x")
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.Clear();
                Game game = new Game();
                game.GameStart();
                Program program = new Program();
                program.CloseWindow();
            }
        }

    }

}
