// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Node.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Node is a genric type class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public T data;
        public  Node<T> next;
    }
}
