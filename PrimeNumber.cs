// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PrimeNumber.cs" company="Bridgelabz">
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
    /// PrimeNumber is class which holds the prime() method for finding prime numbers
    /// </summary>
    class PrimeNumber
    {
        Utility util = new Utility();
        public void Prime()
        {
            bool b = false;
            for (int i = 2; i <= 1000; i++)
            {
                b = util.IsPrime(i);
                if (b == true)
                    Console.Write(i + ",");
            }
        }
    }
}