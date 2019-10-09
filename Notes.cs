// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Notes.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Notes is class where we find the changes of amount
    /// </summary>
    class Notes
    {
        /// <summary>
        /// Counts the currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public void CountCurrency(int amount)
        {
            int[] notes = new int[] { 2000, 500, 200, 100, 50, 10, 5, 1 };
            int[] noteCounter = new int[8];
            for (int i = 0; i < 8; i++)
            {
                if (amount >= notes[i])
                {
                    noteCounter[i] = amount / notes[i];
                    amount = amount - noteCounter[i] * notes[i];
                }
            }
            Console.WriteLine("Currency Count ->");
            for (int i = 0; i < 8; i++)
            {
                if (noteCounter[i] != 0)
                {
                   Console.WriteLine(notes[i] + " : "
                        + noteCounter[i]);
                }
            }
        }
    }
}