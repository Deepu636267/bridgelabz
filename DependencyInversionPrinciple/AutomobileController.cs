// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AutomobileController.cs" company="Bridgelabz">
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
    /// AutomobileController is class 
    /// </summary>
    public class AutomobileController
    {
        IAutomobile m_Automobile;
        /// <summary>
        /// Initializes a new instance of the <see cref="AutomobileController"/> class.
        /// </summary>
        /// <param name="automobile">The automobile.</param>
        public AutomobileController(IAutomobile automobile)
        {
            this.m_Automobile = automobile;
        }
        /// <summary>
        /// Ignitions this instance.
        /// </summary>
        public void Ignition()
        {
            m_Automobile.Ignition();
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            m_Automobile.Stop();
        }
    }
}