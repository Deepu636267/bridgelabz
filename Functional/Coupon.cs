// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Coupon.cs" company="Bridgelabz">
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
    /// Coupon is Class Where Collect() is method to find the count;
    /// </summary>
    class Coupon
    {
        /// <summary>
        /// Gets the coupon number.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public int GetCoupon(int n)
        {
            Random random = new Random();
            return (int)(random.NextDouble() * n);
        }
        public int Collect(int n)
        {
            int distinct = 0;
            int count = 0;
            bool[] Collected = new bool[n];
            while (distinct < n)
            {
                int value = GetCoupon(n);
                count++;
                if (!Collected[value])
                {
                    distinct++;
                    Collected[value] = true;
                }
            }
            return count;
        }
   }
}