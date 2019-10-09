// --------------------------------------------------------------------------------------------------------------------
// <copyright file=    class ReplaceString.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    /// <summary>
    /// ReplaceString is class where Replace is Method for Replceing String
    /// </summary>
    class ReplaceString
    {
        /// <summary>
        /// The utility
        /// </summary>
        Utility util = new Utility();
        /// <summary>
        /// Replaces this instance for replacing String.
        /// </summary>
        public void Replace()
        {
            string str1 = "Hello!";
            Console.WriteLine("Enter the String Do you want Place : Min 3 char");
            string str2 = util.InputString();
            String str3 = "How Are You?";
            ////here if is to check the character length
            if (str2.Length<3)
            {
                Console.WriteLine("Enter min 3 char");
            }
            ////Printing the string line after replacing
            else
            {
                Console.WriteLine(str1 +" " + str2 + "  "+ str3);
            }
        }
    }
}