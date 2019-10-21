// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IBM.cs" company="Bridgelabz">
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
    /// IBM is class which overirde the Abstract class Stock
    /// </summary>
    /// <seealso cref="DesignPattern.ObserverDesignPattern.Stock" />
    class IBM :Stock
    {
        public IBM(string symbol,double price):base(symbol,price)
        {

        }
    }
}