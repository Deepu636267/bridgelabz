// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ComputerClient.cs" company="Bridgelabz">
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
    /// ComputerClient is classs to test our design pattern
    /// </summary>
    class ComputerClient
    {
        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void test()
        {
            Computer pc = ComputerFactory.getComputer("pc", "2 GB", "500 GB", "2.4 GHz");
            Computer server = ComputerFactory.getComputer("server", "16 GB", "1 TB", "2.9 GHz");
            Console.WriteLine("Factory PC Config::" + pc.toString());
            Console.WriteLine("Factory Server Config::" + server.toString());
        }
    }
}