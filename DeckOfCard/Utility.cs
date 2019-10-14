// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.DeckOfCard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Utility is a class For the Code Reuseability.
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Merges the sort.
        /// </summary>
        /// <param name="Arr">The arr.</param>
        /// <param name="p">The p.</param>
        /// <param name="r">The r.</param>
        /// <param name="rank">The rank.</param>
        public static void mergeSort(string[] Arr, int p, int r, string[] rank)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                mergeSort(Arr, p, q, rank);
                mergeSort(Arr, q + 1, r, rank);
                mergeProcess(Arr, p, q, r, rank);
            }
        }
        /// <summary>
        /// Merges the process.
        /// </summary>
        /// <param name="Arr">The arr.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <param name="r">The r.</param>
        /// <param name="rank">The rank.</param>
        private static void mergeProcess(string[] Arr, int p, int q, int r, string[] rank)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            string[] list1 = new string[n1];
            string[] list2 = new string[n2];
            for (int y = 0; y < n1; y++)
            {
                list1[y] = Arr[p + y];
            }

            for (int h = 0; h < n2; h++)
            {
                list2[h] = Arr[q + 1 + h];
            }
            int k = p;
            int i = 0;
            int j = 0;
            while (i < n1 && j < n2)
            {
                int a = linearSearch(rank, list1[i].Substring(list1[i].IndexOf("-") + 1));
                int b = linearSearch(rank, list2[j].Substring(list2[j].IndexOf("-") + 1));
                if (a - b < 0)
                {
                    Arr[k++] = list1[i++];
                }
                else
                {
                    Arr[k++] = list2[j++];
                }
            }
            while (i < n1)
            {
                Arr[k++] = list1[i++];
            }
            while (j < n2)
            {
                Arr[k++] = list2[j++];
            }
        }
        /// <summary>
        /// Linears the search.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static int linearSearch(string[] arr, string word)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(word))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}