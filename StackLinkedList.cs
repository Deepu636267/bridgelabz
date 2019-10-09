// --------------------------------------------------------------------------------------------------------------------
// <copyright file=StackLinkedList.cs" company="Bridgelabz">
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
    /// StackLinkedList is a class of genrick type to opreate all
    /// stack operation by using Linkedlist
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class StackLinkedList<T>
    {
        Node<T> top = null;
        /// <summary>
        /// Pushes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Push(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.data = item;
            newNode.next = top;
            top = newNode;
        }
        /// <summary>
        /// Pops the data+.
        /// </summary>
        public void Pop()
        {
            if(top==null)
            {
                return;
            }
            else
            {
                Console.Write(top.data+",");
                top = top.next;
            }
        }
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            if(top==null)
            {
                return true;
            }
            return false;
        }
    }
}