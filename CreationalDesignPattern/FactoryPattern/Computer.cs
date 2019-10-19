// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Computer.cs" company="Bridgelabz">
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
    /// Computer is an abstract type class where all method will be define
    /// </summary>
    public abstract class Computer
    {
        public abstract string GetRAM();
        public abstract string GetHDD();
        public abstract string GetCPU();
        /// <summary>
        /// To the string.
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "RAM= " + this.GetRAM() + ", HDD=" + this.GetHDD() + ", CPU=" + this.GetCPU();
        }
    }
}