// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Day.cs" company="Bridgelabz">
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
    /// Day is class to holds CalculateDay() method for finding the day with formula is define in utility class
    /// </summary>
    class Day
    {
        Utility util = new Utility();
        /// <summary>
        /// Calculates the day.
        /// </summary>
        public void CalculateDay()
        {
            Console.WriteLine("Enter the date.");
            int d = util.InputInteger();
            Console.WriteLine("Enter the Month As... For Jan press 01,\nFor Feb press 02,\nFor March press 03,\nFor April press 04,\nFor May press 05"
                 +"\nFor Jun press 06,\nFor July press 07,\nFor Aug press 08,\nFor Sept press 09,\nFor October press 10,\nFor Nov press 11,\nFor Dec press 12");
            int m = util.InputInteger();
            Console.WriteLine("Enter the year");
            int y = util.InputInteger();
            int day = util.FindDay(d,m,y);
            switch(day)
            {
                case 0:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Sunday");
                    break;
                case 1:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Monday");
                    break;
                case 2:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Tuesday");
                    break;
                case 3:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Wednesday");
                    break;
                case 4:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Thursday");
                    break;
                case 5:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Friday");
                    break;
                case 6:
                    Console.WriteLine(" This " + d + "/" + m + "/" + y + " is Saturday");
                    break;
            }
        }
    }
}