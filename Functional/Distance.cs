// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Distance.cs" company="Bridgelabz">
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
    /// Distance IS class Where EcludianDistance() Method To find the Ditance Between Two Cordinates.
    /// </summary>
    class Distance
    {  
        /// <summary>
    /// Ecludian Distance() is method 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
        public  void EcludianDistance(int x, int y)
        {
            ////calculate thePOwer Of cordinate
            double a = Math.Pow(x, x);
            double b = Math.Pow(y, y);
            double distance = Math.Sqrt(a + b);
           Console.WriteLine("distance:" + distance);
        }
    }
}