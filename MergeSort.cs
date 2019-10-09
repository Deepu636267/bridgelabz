// --------------------------------------------------------------------------------------------------------------------
// <copyright file=MergeSort.cs" company="Bridgelabz">
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
    /// Merge is class Holds the Sort and Print method which has perform sorting for String
    /// </summary>
    class MergeSort
    {
        Utility util = new Utility();
        /// <summary>
        /// Sorts the specified arr  which has perform sorting for String.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="l">The l.</param>
        /// <param name="r">The r.</param>
        /// <returns></returns>
        public string[] Sort(string[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                util.Merge(arr, l, m, r);
            }
            return arr;
        }
        /// <summary>
        /// Prints the  sorted array.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public void PrintArray(string[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}