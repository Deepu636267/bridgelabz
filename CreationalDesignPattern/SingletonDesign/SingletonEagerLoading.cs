// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SingletonEagerLoading.cs" company="Bridgelabz">
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
    /// SingletonEagerLoading is a class for Eager LOAding Example
    /// </summary>
    class SingletonEagerLoading
    {
        private static int counter = 0;
        /// <summary>
        /// Prevents a default instance of the <see cref="SingletonEagerLoading"/> class from being created.
        /// </summary>
        private SingletonEagerLoading()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        private static readonly SingletonEagerLoading instance =new SingletonEagerLoading();
        /// <summary>
        /// Gets the get instance.
        /// </summary>
        /// <value>
        /// The get instance.
        /// </value>
        public static SingletonEagerLoading GetInstance
        {
            get
            {
                return instance;
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