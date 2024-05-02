using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        private static readonly Random random = new Random();

        //Property
        protected int RollNumber {  get; private set; }

        //Method
        public int Roll()
        {
            //Generating the random number 1-6 and returning that number
            RollNumber = random.Next(1, 7);
            return RollNumber;
        }

    }
}