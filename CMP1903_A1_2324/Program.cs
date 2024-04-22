using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {

        public void CloseWindow()
        {
            Game game = new Game();

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

            //Create a Game object and call its methods.
            Game game = new Game();
            Program program = new Program();
            game.GameStart();

        }
        
    }
}
