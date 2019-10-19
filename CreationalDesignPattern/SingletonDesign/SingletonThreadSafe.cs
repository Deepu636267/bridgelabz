// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SingletonThreadSafe.cs" company="Bridgelabz">
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
    /// SingletonThreadSafe is a class 
    /// </summary>
    public sealed class SingletonThreadSafe
    {
        private static int counter = 0;
        private static readonly object obj = new object();
        ////*
        ////* Private constructor ensures that object is not
        ////* instantiated other than with in the class itself
        private SingletonThreadSafe()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        private static SingletonThreadSafe instance = null;
        ////
        ////* public property is used to return only one instance of the class
        ////* leveraging on the private property
        public static SingletonThreadSafe GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new SingletonThreadSafe();
                    }
                }
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