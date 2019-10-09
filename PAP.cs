// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PAP.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Algorithm
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// PAP is class For Finding the Prime Number and pallindrome and anagram
    /// </summary>
    class PAP
    {
        /// <summary>
        /// Checks the pap.
        /// </summary>
       //// <summary>
        Utility util = new Utility();
        public void CheckPAP()
        {
            bool b = false;
            int k = 0;
            int[] a = new int[168];
            Console.WriteLine("Prime Numbers: ");
            for (int i = 2; i <= 1000; i++)
            {
                b = util.IsPrime(i);
                if (b == true)
                {
                    Console.Write(i + ",");
                    a[k++] = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Prime Numbers and Pallendrome are :");
            for (int i = 0; i <a.Length; i++)
            {
                if (util.IsPallindrome(a[i]))
                {
                    Console.Write(a[i] + ",");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Prime Numbers and Anagram are :");
            for (int i = 0; i <a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (util.AnagramInt(a[i],a[j]))
                    {
                        Console.WriteLine(a[i] + "->" + a[j]);
                    }
                }
            }
        }
    }
}