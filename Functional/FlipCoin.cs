// --------------------------------------------------------------------------------------------------------------------
// <copyright file=FlipCoin.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// FlipCoin is class where flip() is a method
    /// </summary>
    class FlipCoin
    {
        /// <summary>
        /// Flips this instance.
        /// </summary>
        Utility util = new Utility();
        public void Flip()
        {
            Console.WriteLine("Enter the Number How Many Times Do You Want To Flip");
            int n = util.InputInteger();
            double head_p, tails_p;
            int T_count = 0, H_Count = 0;
            double val = 0;
            if (n >= 1)
            {
                for (int i = 0; i < n; i++)
                {
                    Random random = new Random();
                    val = random.NextDouble();
                    Console.WriteLine(val);
                    if (val < 0.5)
                    {
                        T_count++;
                    }
                    else
                    {
                        H_Count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter the Positive Number");
            }
            head_p = H_Count* 100/n;
            tails_p = T_count* 100/n;
            Console.WriteLine("The Percentage Of Head is: " + head_p);
            Console.WriteLine("The Percentage Of Tail is: " + tails_p);
        }
    }
}