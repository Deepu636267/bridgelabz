// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Socket.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPattern.AdapterDesign
{
    using System;
    /// <summary>
    /// Socket is class for create Volt object
    /// </summary>
    public class Socket
    {
        /// <summary>
        /// Gets the volt.
        /// </summary>
        /// <returns></returns>
        public Volt getVolt()
        {
            return new Volt(120);
        }
    }
}