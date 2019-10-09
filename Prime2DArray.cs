// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Prime2DArray.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Prime2DArray is class for finding prime number and store in the 2D array
    /// </summary>
    class Prime2DArray
    {
        Utility util = new Utility();
        /// <summary>
        /// Adds the prime number in Array with in the range.
        /// </summary>
        public void Add()
        {
            int[][] pnum = new int[10][];
            int k = 0, count = 0; ;
            int ub = 100;
            for (int i = 2; i <= 1000; i++)
            {
                ////it has checking that the i value will not be the greater then ub so we make new array 
                ////here using the jagged array concept
                if (i != ub)
                {
                    if (util.Prime(i))
                    {
                        count++;
                    }
                }
                else
                {
                    ub = ub + 100;
                    pnum[k] = new int[count];
                    k++;
                    count = 0;
                }
            }
            k = 0;int l = 0;
            ub = 100;
            ////Storing the prime number in 2DArray
            for (int i = 2; i <= 1000; i++)
            {
                ////if i become ub then we have increse the row and column will again start with zero index
                if (i == ub)
                {
                    k++;
                    l = 0;
                    ub = ub + 100;
                }
                if (util.Prime(i))
                {
                    pnum[k][l++] = i;
                }
               
            }
            ////printing the 2D array
            for (int i=0;i<10;i++)
            {
                ////here pnum[i].Length it has given the length of particular row
                for(int j=0;j<pnum[i].Length;j++)
                {
                   Console.Write(pnum[i][j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}