// --------------------------------------------------------------------------------------------------------------------
// <copyright file=DecimalToBinary.cs" company="Bridgelabz">
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
    /// DecimalToBinary is class to convert decimal to binary
    /// </summary>
    class DecimalToBinary
    {
        Utility util = new Utility();
        /// <summary>
        /// Binaries this instance.
        /// </summary>
        public void Binary()
        {
            Console.WriteLine("Enter the Decimal number to convert in binary");
            int Num = util.InputInteger();
            int[] bin = util.ConvertBinary(Num);
            Console.WriteLine("Representation in 4 byte: ");
            for (int i = bin.Length - 1; i >= 0; i--)
            {
                if (bin[i] == 1)
                {
                    Console.Write(Math.Pow(2,i) + "+");
                }
            }
        }
    }
}