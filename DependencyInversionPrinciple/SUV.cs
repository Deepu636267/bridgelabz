// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SUV.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.DependencyInversionPrinciple
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// SUV is a class which inherit an interface IAutomobile
    /// </summary>
    /// <seealso cref="DesignPattern.DependencyInversionPrinciple.IAutomobile" />
    public class SUV : IAutomobile
    {
        #region IAutomobile Members        
        /// <summary>
        /// Ignitions this instance.
        /// </summary>
        public void Ignition()
        {
            Console.WriteLine("SUV start");
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("SUV stopped.");
        }
        #endregion
    }
}