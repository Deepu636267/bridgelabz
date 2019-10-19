// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Book.cs" company="Bridgelabz">
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
    /// Book is class which inherit the ItemElement interface 
    /// </summary>
    /// <seealso cref="DesignPattern.BehavioralDesignPattern.VisitorDesign.ItemElement" />
    public class Book : ItemElement
    {
        private int price;
        private string isbnNumber;
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="cost">The cost.</param>
        /// <param name="isbn">The isbn.</param>
        public Book(int cost, string isbn)
        {
            this.price = cost;
            this.isbnNumber = isbn;
        }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <returns></returns>
        public int GetPrice()
        {
            return price;
        }
        /// <summary>
        /// Gets the isbn number.
        /// </summary>
        /// <returns></returns>
        public string GetIsbnNumber()
        {
            return isbnNumber;
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