// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PowerOf2.cs" company="Bridgelabz">
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
    /// PowerOf2 is a class where we have taken input as num and power is the method name for calucalte
    /// </summary>
    class PowerOf2
    {
        Utility util = new Utility();
        /// <summary>
        /// Powers this instance.
        /// </summary>
        public void Power()
        {
            Console.WriteLine("Enter the number To find the 2's  power of that number");
            int num = util.InputInteger();
            int pow = 1;
            ////its has check that the num value which is send if it has finding power of two 
            ////then it wil give result in the range of Integer or not.
            if(num>=0  && num<31)
            {
                if (num == 0)
                {
                    Console.WriteLine("The Power OF 2^" + num + "is :" + "1");
                }
                else
                {
                    for (int i = 1; i <= num; i++)
                    {
                        pow = pow*2;
                    }
                    Console.WriteLine("The Power OF 2^" + num + "is :" + pow);
                }
            }
            else
            {
                Console.WriteLine("Enter the number between 0 to 30");
            }
        }
    }
}