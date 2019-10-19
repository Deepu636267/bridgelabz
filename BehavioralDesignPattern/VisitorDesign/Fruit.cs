// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Fruit.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.BehavioralDesignPattern.VisitorDesign
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Fruit is class which inherit ItemElement inteface
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.VisitorDesign.ItemElement" />
    public class Fruit : ItemElement
    {
        private int pricePerKg;
        private int weight;
        private string name;
        /// <summary>
        /// Initializes a new instance of the <see cref="Fruit"/> class.
        /// </summary>
        /// <param name="priceKg">The price kg.</param>
        /// <param name="wt">The wt.</param>
        /// <param name="nm">The nm.</param>
        public Fruit(int priceKg, int wt, String nm)
        {
            this.pricePerKg = priceKg;
            this.weight = wt;
            this.name = nm;
        }
        /// <summary>
        /// Gets the price per kg.
        /// </summary>
        /// <returns></returns>
        public int GetPricePerKg()
        {
            return pricePerKg;
        }
        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <returns></returns>
        public int GetWeight()
        {
            return weight;
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        public String GetName()
        {
            return this.name;
        }
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        /// <returns></returns>
        public int Accept(ShoppingCartVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}