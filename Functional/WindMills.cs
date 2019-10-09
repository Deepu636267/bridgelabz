// --------------------------------------------------------------------------------------------------------------------
// <copyright file=WindMills.cs" company="Bridgelabz">
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
    /// Wind mills is Class Hold The Method Wind To calculate Wind
    /// </summary>
    class WindMills
    {
        /// <summary>
        /// Winds the specified t.
        /// </summary>
        /// <param name="t">t. is Temprature which is double Type in Farenhite</param>
        /// <param name="v"> v. is Wind Speed in MIles/Hour</param>
        public void Wind(double t,double v)
        {
            ////to check the condition that t is not more then 50 for  the formula is not valid if t is larger than 50
            if (t <= 50)
            {
                ////the formula is not valid if v is larger than 120 or less than 3
                if (v >= 3 && v <= 120)
                {
                    ////Formula to Calculate
                    double w = 35.74 + 0.6215 * t + (0.4275 * t - 35.75) * Math.Pow(v, 0.16);
                    Console.WriteLine("Wind mills :" + w);
                }
                else
                {
                    Console.WriteLine("enter valid wind speed");
                }
            }
            else
            {
                Console.WriteLine("enter valid temperatue");
            }
        }
    }
}