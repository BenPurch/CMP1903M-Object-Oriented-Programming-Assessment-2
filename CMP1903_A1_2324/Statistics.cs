using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
	public class Statistics
	{
		public static string[] StatisticsFile()
		{
			// Get the directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			// Get the directory where the files reside (CMP1903_A1_2324)
			string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            // Combine the directory path with the file name
            string filePath = Path.Combine(projectDirectory, "Statistics.txt");

			// Parse the file and pass each line as a string into a new array "StatisticsTxt"
			string[] StatisticsTxt = File.ReadLines(Path.Combine(filePath)).ToArray();

			return StatisticsTxt;
		}

        public static void OverwriteFile(string[] StatisticsTxtNew)
        {
            // Get the directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Get the directory where the files reside (CMP1903_A1_2324)
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            // Combine the directory path with the file name
            string filePath = Path.Combine(projectDirectory, "Statistics.txt");

            // Overwrite old file with new details
            string StatisticsTxtOver = string.Join(Environment.NewLine, StatisticsTxtNew);

            File.WriteAllText(filePath, StatisticsTxtOver);
        }

        public static string LineSelector(string stat)
		{
			string[] StatisticsTxt = StatisticsFile();

            // Sevens Out
            string sevensOutTopScore = StatisticsTxt[7];
			string sevensOutTopPlayer = StatisticsTxt[8];
			string sevensOutPlayCount = StatisticsTxt[18];
			// Three or More
			string threeOrMoreTopScore = StatisticsTxt[11];
			string threeOrMoreTopPlayer = StatisticsTxt[12];
			string threeOrMorePlayCount = StatisticsTxt[22];

			// High Scores
			if (stat == "sevensOutTopScore") { return sevensOutTopScore; }
			else if (stat == "sevensOutTopPlayer") { return sevensOutTopPlayer; }
			else if (stat == "threeOrMoreTopScore") { return threeOrMoreTopScore; }
			else if (stat == "threeOrMoreTopPlayer") { return threeOrMoreTopPlayer; }
			// Number of Plays
			else if (stat == "sevensOutPlayCount") { return sevensOutPlayCount; }
            else if (stat == "threeOrMorePlayCount") { return threeOrMorePlayCount; }

            return stat;
        }

        // Gathers the games history
		public static string[] History()
		{
            string[] StatisticsTxt = StatisticsFile();

            // Skipping the first 28 lines
            string[] historyList = StatisticsTxt.Skip(28).ToArray();

            return historyList;
        }

        // Appends the new scores to Statistics.txt
		public static void AppendStatistics(string[] gameScores)
		{
            string[] StatisticsTxt = StatisticsFile();

            // Adds the two players scores to the end of the StatisticsTxt array
            StatisticsTxt = StatisticsTxt.Concat(gameScores).ToArray();

            if (gameScores[1] == "Sevens Out")
            {
                // Gathering scores for comparrisons
                int playerOneScore = int.Parse(gameScores[3]);
                int playerTwoScore = int.Parse(gameScores[7]);

                int highScore = int.Parse(StatisticsTxt[7]);

                // Checking if player one has the new high score
                if (playerOneScore > highScore)
                {
                    StatisticsTxt[7] = gameScores[3];
                    StatisticsTxt[8] = gameScores[2];
                }
                // Checking if player two has the new high score
                if (playerTwoScore > highScore)
                {
                    StatisticsTxt[7] = gameScores[7];
                    StatisticsTxt[8] = gameScores[6];
                }

                // Adding +1 to the playcount for Sevens Out
                int playCount = int.Parse(StatisticsTxt[18]) + 1;
                StatisticsTxt[18] = playCount.ToString();

            }
            else if (gameScores[1] == "Three or More")
            {
                // Gathering scores for comparrisons
                int playerOneScore = int.Parse(gameScores[3]);
                int playerTwoScore = int.Parse(gameScores[7]);

                int highScore = int.Parse(StatisticsTxt[7]);

                // Checking if player one has the new 'least amount of rolls'
                if (playerOneScore < highScore)
                {
                    StatisticsTxt[11] = gameScores[3];
                    StatisticsTxt[12] = gameScores[2];
                }
                // Checking if player two has the new 'least amount of rolls' 
                if (playerTwoScore < highScore)
                {
                    StatisticsTxt[11] = gameScores[7];
                    StatisticsTxt[12] = gameScores[6];
                }

                // Adding +1 to the playcount for Three or More
                int playCount = int.Parse(StatisticsTxt[22]) + 1;
                StatisticsTxt[22] = playCount.ToString();

            }
            else
            {
                Console.WriteLine("ERROR - Statistics.txt has been tampered with!");
                return;
            }
            OverwriteFile(StatisticsTxt);
			/*
			foreach (string line in StatisticsTxt)
			{
				Console.WriteLine(line);
			} */
			Console.ReadKey();
        }
	}
}


