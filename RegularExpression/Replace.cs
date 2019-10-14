// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Replace.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.RegularExpression
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.IO;
    /// <summary>
    /// Replace is class for replacing the string by use of regex
    /// </summary>
    class Replace
    {
        /// <summary>
        /// Regexes the exp.
        /// </summary>
        public void RegexExp()
        {
            try
            {
                //// Ask user to input name
                Console.WriteLine("Enter your name");
                string name = Console.ReadLine();
                //// string name in regex form
                if (!Regex.IsMatch(name, @"[a-zA-Z]"))
                {
                    Console.WriteLine("Enter wrong input");
                }
                Console.WriteLine("Enter your full name");
                string fullname = Console.ReadLine();
                //// condition to avoid number in the name
                if (!Regex.IsMatch(fullname, @"[a-zA-Z]"))
                {
                    Console.WriteLine("Enter wrong input");
                }
                Console.WriteLine("Enter mobile no.");
                string num = Console.ReadLine();
                //// condition to avoid name and should contain 10 digit no.
                if (!Regex.IsMatch(num, @"^[0-9]{10}$"))
                {
                    Console.WriteLine("Enter wrong input");
                }
                check(name, fullname, num);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Checks the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fullname">The fullname.</param>
        /// <param name="num">The number.</param>
        public void check(string name, string fullname, string num)
        {
            ////path which hold text message
            string text = File.ReadAllText(@"C:\Users\Bridgelabz\source\repos\OOPS\RegularExpression\readFile.txt");
            //// pattern of changing name
            string patternname = "<<name>>";
            //// pattern of changing fullname
            string patternfullname = "<<full name>>";
            ////pattern of changing mobile no.
            string patternnum = "xxxxxxxxxx";
            //// pattern of fullname of changing current date.
            string patterndate = "01/01/2016";
            //// regular expression class to replace the pattern with valid data.
            text = Display(text, name, patternname);
            text = Display(text, fullname, patternfullname);
            text = Display(text, num, patternnum);
            string date = DateTime.Now.ToString();
            //Console.WriteLine(date);
            text = Display(text, date, patterndate);
            Console.WriteLine();
            Console.WriteLine(text);
        }
        /// <summary>
        /// Display the match.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="exp"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string Display(string text, string exp, string pattern)
        {
            //// creating regex class object for passing pattern
            Regex rxg = new Regex(pattern);
            string newString = rxg.Replace(text, exp);
            return newString;
        }
    }
}