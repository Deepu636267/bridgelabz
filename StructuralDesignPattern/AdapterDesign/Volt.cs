// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Volt.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPattern.AdapterDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Volt is a class for getting and setting the volt
    /// </summary>
    public class Volt
    {
        private int volts;
        /// <summary>
        /// Initializes a new instance of the <see cref="Volt"/> class.
        /// </summary>
        /// <param name="v">The v.</param>
        public Volt(int v)
        {
            this.volts = v;
        }
        /// <summary>
        /// Gets the volts.
        /// </summary>
        /// <returns></returns>
        public int getVolts()
        {
            return volts;
        }
        /// <summary>
        /// Sets the volts.
        /// </summary>
        /// <param name="volts">The volts.</param>
        public void setVolts(int volts)
        {
            this.volts = volts;
        }
    }
}