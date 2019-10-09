// --------------------------------------------------------------------------------------------------------------------
// <copyright file=InsertionString.cs" company="Bridgelabz">
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
    /// InsertionString holds the sort() method for sorting the string type value
    /// </summary>
    class InsertionString
    {
        Utility util = new Utility();
        /// <summary>
        /// Sorts this instance  method for sorting the string type value.
        /// </summary>
        public void Sort()
        {
            Console.WriteLine("Enter the Size Of Array");
            int n3 = util.InputInteger();
            Console.WriteLine("Enter the Array Element in integer type");
            string[] ar3 = new string[n3];
            for (int i = 0; i < n3; i++)
            {
                ar3[i] = util.InputString();
            }
            string[] find3 = util.InsertionSortString(ar3);
            Console.WriteLine("After Soting");
            for (int i = 0; i < find3.Length; i++)
            {
                Console.Write(find3[i] + " ");
            }
        }
    }
}