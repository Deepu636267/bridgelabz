// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Jeep.cs" company="Bridgelabz">
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
    /// Jeep is class which inherited the IAutomobile interface
    /// </summary>
    /// <seealso cref="DesignPattern.DependencyInversionPrinciple.IAutomobile" />
    public class Jeep : IAutomobile
    {
        #region IAutomobile Members        
        /// <summary>
        /// Ignitions this instance.
        /// </summary>
        public void Ignition()
        {
            Console.WriteLine("Jeep start");
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("Jeep stopped.");
        }
        #endregion
    }
}