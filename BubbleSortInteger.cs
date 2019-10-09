// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BubbleSortInteger.cs" company="Bridgelabz">
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
    /// BubbleSortInteger is class holds the Bubble method for sort the integer type value connect with the utility class.
    /// </summary>
    class BubbleSortInteger
    {
        Utility util = new Utility();
        public void Bubble()
        {
            Console.WriteLine("Enter the Size Of Array");
            int n4 = util.InputInteger();
            Console.WriteLine("Enter the Array Element in integer type");
            int[] ar4 = new int[n4];
            for (int i = 0; i < n4; i++)
            {
                ar4[i] = util.InputInteger();
            }
            int[] find4 = util.BubbleSortInteger(ar4);
            Console.WriteLine("After Soting");
            for (int i = 0; i < find4.Length; i++)
            {
                Console.Write(find4[i] + " ");
            }
        }
    }
}