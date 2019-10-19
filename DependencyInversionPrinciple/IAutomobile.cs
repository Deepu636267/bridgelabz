// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
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
    /// IAutomobile is an interface
    /// </summary>
    public interface IAutomobile
    {
        void Ignition();
        void Stop();
    }
}
