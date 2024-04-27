using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
	public class Statistics
	{


		public static string LineSelector(string stat)
		{
            // Get the directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
			// Get the directory where the files reside (CMP1903_A1_2324)
			string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            // Combine the directory path with the file name
            string filePath = Path.Combine(projectDirectory, "Statistics.txt");

			// Parse the file and pass each line as a string into a new array "StatisticsTxt"
			string[] StatisticsTxt = File.ReadLines(Path.Combine(filePath)).ToArray();

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

		public static string[] History()
		{
            // Get the directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Get the directory where the files reside (CMP1903_A1_2324)
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            // Combine the directory path with the file name
            string filePath = Path.Combine(projectDirectory, "Statistics.txt");

            string[] StatisticsTxt = File.ReadLines(Path.Combine(filePath)).ToArray();
			// Skipping the first 28 lines
			string[] historyList = StatisticsTxt.Skip(28).ToArray();

            return historyList;
        }
	}
}


