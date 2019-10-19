// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LazyKeywordUses.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.CreationalDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// LazyKeywordUses is a class 
    /// </summary>
    class LazyKeywordUses
    {
        private static int counter = 0;
        /// <summary>
        /// Prevents a default instance of the <see cref="LazyKeywordUses"/> class from being created.
        /// </summary>
        private LazyKeywordUses()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        private static readonly Lazy<LazyKeywordUses> instance =
        new Lazy<LazyKeywordUses>(() => new LazyKeywordUses());
        /// <summary>
        /// Gets the get instance.
        /// </summary>
        /// <value>
        /// The get instance.
        /// </value>
        public static LazyKeywordUses GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        /// <summary>
        /// Prints the details.
        /// </summary>
        /// <param name="message">The message.</param>
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}