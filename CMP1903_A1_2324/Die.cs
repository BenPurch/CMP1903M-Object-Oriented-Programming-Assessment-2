﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Die
    {
        /*
         * The Die class should contain one property to hold the current die value,
         * and one method that rolls the die, returns and integer and takes no parameters.
         */
        private static readonly Random random = new Random();

        //Property
        public int RollNumber {  get; private set; }

        //Method
        public int Roll()
        {
            //Generating the random number 1-6 and returning that number
            RollNumber = random.Next(1, 7);
            return RollNumber;
        }

    }
}