// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LeapYear.cs" company="Bridgelabz">
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
    /// Leap  year is a class where Leap is a Method 
    /// </summary>
    class LeapYear
    {
        /// <summary>
        /// Leaps this instance.
        /// </summary>
        Utility util = new Utility();
        public void Leap()
        {
            Console.WriteLine("Enter the Year which you want to check the leap year?");
            int year = util.InputInteger();
            int n = year;
            int count = 0;
            ////Counting the Digit
            while (n != 0)
            {
                count++;
                n = n / 10;
            }
           //// Checking the Digit because if digit is not 4 then the yaer has always be in a Four Digit
            if (count == 4)
            {
                if ((year % 4 == 0 || year % 100 == 0) && year % 400 == 0)
                {
                    Console.WriteLine(year + " is a Leap year");
                }
                else
                {
                    Console.WriteLine(year + " is not a leap year");
                }
            }
            else
            {
                Console.WriteLine("Enter the  4 Digit");
            }
        }
    }
}