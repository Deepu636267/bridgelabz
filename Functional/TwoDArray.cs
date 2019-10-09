// --------------------------------------------------------------------------------------------------------------------
// <copyright file=TwoDArray.cs" company="Bridgelabz">
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
    /// TwoDArray is class which hold TwoDArray in Integer Double  Boolean Array
    /// </summary>
    class TwoDArray
    {
        Utility util = new Utility();
        /// <summary>
        ///ArrayInteger the specified for taking the Integer Type value..
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public int[,] ArrayInteger(int m, int n)
        {
            int[,] arrInt = new int[m,n];
            Console.WriteLine("Enter the Array element In Integer");
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    arrInt[i, j] = util.InputInteger();
                }
            }
            return arrInt;
        }
        /// <summary>
        /// Arraydoubles the specified for taking the Double Type value.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public double[,] Arraydouble(int m, int n)
        {
            double[,] arrDouble = new double[m, n];
            Console.WriteLine("Enter the Array element In Integer");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    arrDouble[i, j] = util.InputDouble();
                }
            }
            return arrDouble;
        }
        /// <summary>
        /// ArrayBoolean the specified for taking the bool Type value.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool[,] ArrayBoolean(int m, int n)
        {
            Console.WriteLine("Enter the Array Element in Bool");
            bool[,] arrBool = new bool[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    arrBool[i, j] = util.InputBool();
                }
            }
            return arrBool;
        }
         /// <summary>
        /// Displays the specified arr int arr double arr bool.
        /// </summary>
        /// <param name="arrInt">The arr int.</param>
        /// <param name="arrDouble">The arr double.</param>
        /// <param name="arrBool">The arr bool.</param>
        /// <param name="m">The m.</param>
        /// <param name="n">The n.</param>
        public void Display(int[,] arrInt, double[,] arrDouble, bool[,] arrBool, int m, int n)
        {
            Console.WriteLine("\nArray Element in Integer");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arrInt[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nArray Element in Double");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arrDouble[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nArray Element in  Bool");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arrBool[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}