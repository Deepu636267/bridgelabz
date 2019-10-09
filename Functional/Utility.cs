
// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" company="Bridgelabz">
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
    /// Utility is class for code Reuseability
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Inputs the integer.
        /// </summary>
        /// <returns></returns>
        public int InputInteger()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Inputs the string.
        /// </summary>
        /// <returns></returns>
        public string InputString()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Inputs the double.
        /// </summary>
        /// <returns></returns>
        public double InputDouble()
        {
            return Convert.ToDouble(Console.ReadLine());
        }
        /// <summary>
        /// Inputs the bool.
        /// </summary>
        /// <returns></returns>
       public bool InputBool()
        {
            return Convert.ToBoolean(Console.ReadLine());
        }
        /// <summary>
        /// BubbleSort() method for Sorting the Integer type value
        /// holds integer type as argument
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns></returns>
        public int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
    }
}