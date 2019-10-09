// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SumOfArray.cs" company="Bridgelabz">
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
    /// SumOfArray is class To hol the function ArraySum()
    /// </summary>
    class SumOfArray
    {
        /// <summary>
        /// ArraySum() is method with Parameter int n
        /// </summary>
        Utility util = new Utility(); 
        public void ArraySum(int n)
        {
            Console.WriteLine("Enter The Numbers in Array");
            int[] arr = new int[n];
            for(int i=0;i<n;i++)
            {
                arr[i] = util.InputInteger();
            }
            Sum(arr);
        }
        /// <summary>
        /// Sums the specified To find the Triplet OF Array.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public void Sum(int[] arr)
        {
            bool found = false;
            int[] arr1 = util.BubbleSort(arr);
            int n = arr1.Length;
            Console.WriteLine("Triplet Sum Zero is: ");
            for (int i = 0; i<n; i++)
            {
                ////holding the first element in X And moving with its Next And LAst Elment
                int l = i+1;
                int r = n-1;
                int x = arr1[i];
                ////it has Checking that to hold one value and moving with forward and Backward to find Zero 
                while (l<r)
                {
                    if (x+arr1[l]+arr1[r]==0)
                    {
                        Console.Write(x + ",");
                        Console.Write(arr1[l] + ",");
                        Console.Write(arr1[r] + ",");
                        l++;
                        r--;
                        found = true;
                    }
                    if (x+arr1[l]+arr1[r]<0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                    Console.WriteLine();
                }
            }
            if (found == false)
            {
                Console.WriteLine("No triplet found");
            }
        }
    }
}