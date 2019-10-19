// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ShoppingCartClient.cs" company="Bridgelabz">
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
    /// ShoppingCartClient is class for handling the client properties
    /// </summary>
    public class ShoppingCartClient
    {
        public  void ClientMain()
        {
            ItemElement[] items = new ItemElement[]{new Book(20, "1234"),new Book(100, "5678"),
                                  new Fruit(10, 2, "Banana"), new Fruit(5, 5, "Apple")};
            int total = calculatePrice(items);
            Console.WriteLine("Total Cost = " + total);
        }
        /// <summary>
        /// Calculates the price.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        private static int calculatePrice(ItemElement[] items)
        {
            ShoppingCartVisitor visitor = new ShoppingCartVisitorImpl();
            int sum = 0;
            foreach (ItemElement item in items)
            {
                sum = sum + item.Accept(visitor);
            }
            return sum;
        }
    }
}