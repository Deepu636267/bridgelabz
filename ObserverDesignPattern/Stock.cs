// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Stock.cs" company="Bridgelabz">
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
    /// Stock is an abstract class where define the Attach,deatch,Notify
    /// </summary>
    public abstract class Stock
    {
        private string _symbol;
        private double _price;
        private List<IInvestor> _investor = new List<IInvestor>();
        /// <summary>
        /// Initializes a new instance of the <see cref="Stock"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="price">The price.</param>
        public Stock(string symbol,double price)
        {
            this._symbol = symbol;
            this._price = price;
        }
        /// <summary>
        /// Attaches the specified investor.
        /// </summary>
        /// <param name="investor">The investor.</param>
        public void Attach(IInvestor investor)
        {
            _investor.Add(investor);
        }
        /// <summary>
        /// Detaches the specified investor.
        /// </summary>
        /// <param name="investor">The investor.</param>
        public void Detach(IInvestor investor)
        {
            _investor.Remove(investor);
        }
        /// <summary>
        /// Notifies this instance.
        /// </summary>
        public void Notify()
        {
            foreach(IInvestor investor in _investor)
            {
                investor.Update(this);
            }
            Console.WriteLine(" ");
        }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public double Price
        {
            get { return _price; }
            set
            {
                if(_price!=value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
        }

    }
}