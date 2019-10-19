// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ProxyClient.cs" company="Bridgelabz">
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
    /// ProxyClient is class which inherit an interface IClient
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPattern.ProxyDesign.IClient" />
    public class ProxyClient : IClient
    {
        RealClient client = new RealClient();
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyClient"/> class.
        /// </summary>
        public ProxyClient()
        {
            Console.WriteLine("ProxyClient: Initialized");
        }
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            return client.GetData();
        }
    }
}