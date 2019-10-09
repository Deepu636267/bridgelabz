// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Quuadratic.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Quuadratic
    {
        /// <summary>
        /// Finds the root.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="c">The c.</param>
        public void FindRoot(int a, int b ,int c)
        {
            int d = (b * b - 4 * a * c);
            double root1 = 0.0;
            double root2 = 0.0;
            ////Checking the d value if its greater then zero then roots are real and differnt
            if (d>0)
            {
                root1 = (-b + Math.Sqrt(d)) / (2 * a);
                root2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("roots are real and differnt");
                Console.WriteLine("Root1: " + root1 + "Root2: " + root2);
            }
            ////Checking the d value if its less then zero then roots are Complex
            else if (d<0)
            {
                root1 = (-b / (2 * a));
                root2 = (-b / (2 * a));
                Console.WriteLine("roots are Complex");
                Console.WriteLine("Root1 :" + root1 + "+i" + Math.Sqrt(Math.Abs(d)));
                Console.WriteLine("Root2 :" + root2 + "+i" + Math.Sqrt(Math.Abs(d)));
            }
            ////Checking the d value if its equal to zero then roots are Equal
            else
            {
                root1 = (-b / (2 * a));
                root2 = (-b / (2 * a));
                Console.WriteLine("roots are Equal");
                Console.WriteLine("Root1: "+ root1 + "Root2: " + root2);
            }
        }
    }
}