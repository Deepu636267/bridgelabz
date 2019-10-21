// --------------------------------------------------------------------------------------------------------------------
// <copyright file=MainApp.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.ObserverDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// MainApp is class for test the design Pattern
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void Test()
        {
            ////Creating the share Of IBM 
            IBM iBM = new IBM("IBM", 120.00);
            ////Adding New Share
            iBM.Attach(new Investor("Sorroj"));
            iBM.Attach(new Investor("BrekShire"));
            ////Changing the Share Price
            iBM.Price = 120.10;
            iBM.Price = 121.00;
            iBM.Price = 122.10;
            iBM.Price = 125.10;
            iBM.Price = 127.10;
            iBM.Price = 121.20;
        }
    }
}