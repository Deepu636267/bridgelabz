// --------------------------------------------------------------------------------------------------------------------
// <copyright file=HarmonicNumber.cs" company="Bridgelabz">
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
    /// HarmonicNumber is class where Harmonic() is a Method
    /// </summary>
    class HarmonicNumber
    {
        /// <summary>
        /// Harmonics this instance.
        /// </summary>
        Utility util = new Utility();
        public void Harmonic()
        {
            Console.WriteLine("Enter the Nth Number Which you find the Harmonic Value");
            int N = util.InputInteger();
            float Harmonic = 1;
            ////for finding Harmonic With its Formula h1=1,h2=h1+1/2,h3=h2+1/3.....hn=hn-1+1/n;
            for(int i=2;i<=N;i++)
            {
                Harmonic = Harmonic + (float)1 / i;
            }
            Console.WriteLine("The"+N+"th Harmonic Value is:" + Harmonic);
        }
    }
}