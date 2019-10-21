// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Investor.cs" company="Bridgelabz">
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
    /// Investor is class which Inherit the IInvestor interface
    /// </summary>
    /// <seealso cref="DesignPattern.ObserverDesignPattern.IInvestor" />
    class Investor : IInvestor
    {
        private string _name;
        private Stock _stock;
        /// <summary>
        /// Initializes a new instance of the <see cref="Investor"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Investor(string name)
        {
            this._name = name;
        }
        /// <summary>
        /// Updates the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        public void Update(Stock stock)
        {
            Console.WriteLine( "Notified {0} of {1}'s "+"change to {2:C}",_name,stock.Symbol,stock.Price);
        }
        /// <summary>
        /// Gets or sets the stock.
        /// </summary>
        /// <value>
        /// The stock.
        /// </value>
        public Stock stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}