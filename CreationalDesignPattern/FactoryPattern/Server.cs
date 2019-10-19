﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Server.cs" company="Bridgelabz">
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
    /// Server is class to define the type  
    /// </summary>
    /// <seealso cref="DesignPattern.CreationalDesignPattern.FactoryPattern.Computer" />
    class Server :Computer
    {
        private string ram;
        private string hdd;
        private string cpu;
        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="ram">The ram.</param>
        /// <param name="hdd">The HDD.</param>
        /// <param name="cpu">The cpu.</param>
        public Server(string ram, string hdd, string cpu)
        {
            this.ram = ram;
            this.hdd = hdd;
            this.cpu = cpu;
        }
        /// <summary>
        /// Gets the ram.
        /// </summary>
        /// <returns></returns>
        public override string GetRAM()
        {
            return this.ram;
        }
        /// <summary>
        /// Gets the HDD.
        /// </summary>
        /// <returns></returns>
        public override string GetHDD()
        {
            return this.hdd;
        }
        /// <summary>
        /// Gets the cpu.
        /// </summary>
        /// <returns></returns>
        public override string GetCPU()
        {
            return this.cpu;
        }
    }
}