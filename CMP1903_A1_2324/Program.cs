//#define TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {

        public void CloseWindow()
        {
            // Initialising Game
            Game game = new Game();

            // Confirming if the user really wants to close the window
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
                game.GameStart();
                CloseWindow();
            }
            
        }

        static void Main(string[] args)
        {
#if TEST
            //Create a Testing object and call its methods
            Testing testing = new Testing();
            Testing.GameTester();
#else
            //Create a Game object and call its methods.
            Game game = new Game();
            game.GameStart();
#endif
        }
        
    }
}
