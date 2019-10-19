// --------------------------------------------------------------------------------------------------------------------
// <copyright file=RealClient.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPattern.ProxyDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// RealClient is a classs which inherit an inteface IClient
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPattern.ProxyDesign.IClient" />
    public class RealClient : IClient
    {
        string Data;
        /// <summary>
        /// Initializes a new instance of the <see cref="RealClient"/> class.
        /// </summary>
        public RealClient()
        {
            Console.WriteLine("Real Client: Initialized");
            Data = "Dot Net Tricks";
        }
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return Data;
        }
    }
}