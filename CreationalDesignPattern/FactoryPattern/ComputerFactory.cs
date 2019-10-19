// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ComputerFactory.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.CreationalDesignPattern.FactoryPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// ComputerFactory is class which test the design pattern 
    /// </summary>
    class ComputerFactory
    {
        /// <summary>
        /// Gets the computer.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="ram">The ram.</param>
        /// <param name="hdd">The HDD.</param>
        /// <param name="cpu">The cpu.</param>
        /// <returns></returns>
        public static Computer getComputer(String type, String ram, String hdd, String cpu)
        {
            if (type.ToLower().Equals("pc")) return new PC(ram, hdd, cpu);
            else if (type.ToLower().Equals("server")) return new Server(ram, hdd, cpu);
            return null;
        }
    }
}