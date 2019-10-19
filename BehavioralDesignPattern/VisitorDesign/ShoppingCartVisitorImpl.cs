// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ShoppingCartVisitorImpl.cs" company="Bridgelabz">
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
    /// ShoppingCartVisitorImpl is a class which inherit that ShoppingCartVisitor
    /// </summary>
    public class ShoppingCartVisitorImpl : ShoppingCartVisitor
    {
        /// <summary>
        /// Visit is method for Book type and it do all the operation regarding that 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int Visit(Book book)
        {
            int cost = 0;
            //apply 5$ discount if book price is greater than 50
            if (book.GetPrice() > 50)
            {
                cost = book.GetPrice() - 5;
            }
            else cost = book.GetPrice();
            Console.WriteLine("Book ISBN::" + book.GetIsbnNumber() + " cost =" + cost);
            return cost;
        }
        /// <summary>
        /// visit is method which Fruit as argument
        /// </summary>
        /// <param name="fruit"></param>
        /// <returns></returns>
        public int Visit(Fruit fruit)
        {
            int cost = fruit.GetPricePerKg() * fruit.GetWeight();
            Console.WriteLine(fruit.GetName() + " cost = " + cost);
            return cost;
        }
    }
}