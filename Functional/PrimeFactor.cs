// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PrimeFactor.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// PrimeFactor is a class where i declared Factor as a method
    /// </summary>
    class PrimeFactor
    {
        /// <summary>
        /// Factors this instance.
        /// </summary>

       Utility util = new Utility();
       public void Factor()
        {
            Console.WriteLine("Enter the Number To find The Prime Factor");
            int Num = util.InputInteger();
            ////while is used to find factor with 2
            while (Num % 2 == 0)
            {
                Console.Write(2 + " ");
                Num /= 2;
            }
            for (int i = 3; i <=Num; i += 2)
            {
                while (Num % i == 0)
                {
                    Console.Write(i + " ");
                    Num /= i;
                }
            }
            ////At last if the last value is left that which gretaer then two and not divisible in loop then directly print it
            if (Num > 2)
                Console.Write(Num);
        }
    }
}