// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Angaram.cs" company="Bridgelabz">
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
    /// Angaram is class
    /// </summary>
    class Angaram
    {
        Utility util = new Utility();
        /// <summary>
        /// Checks the anagram between the two string.
        /// </summary>
        public void CheckAnagram()
        {
            Console.WriteLine("Enter the first String To check Angram");
            string s1 = util.InputString();
            Console.WriteLine("Enter the Second String To check Angram");
            string s2 = util.InputString();
            bool b = util.AnagramString(s1, s2);
            if (b == true)
                Console.WriteLine(s1 + " and " + s2 + " Both String Are Angaram.");
            else
                Console.WriteLine(s1 + " and " + s2 + " Both String Are Not Angaram.");
        }
    }
}