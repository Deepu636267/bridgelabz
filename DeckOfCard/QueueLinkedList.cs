// --------------------------------------------------------------------------------------------------------------------
// <copyright file=QueueLinkedList.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.DeckOfCard
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// QueueLinkedList is class for stroring the data in Queue through Linked List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class QueueLinkedList<T>
    {
        class Node
        {
            public T data;
           public Node link;
            public Node()
            {
                this.link = null;
            }
            public T getData()
            {
                return data;
            }
            public Node getLink()
            {
                return link;
            }
        }
        Node rear, front;
        /// <summary>
        /// Add the data in to the queue.
        /// </summary>
        /// <param name="data">The data.</param>
        public void enQueue(T data)
        {
            Node temp = new Node();
            temp.data = data;
            if (rear == null)
            {
                front = temp;
                rear = temp;
                return;
            }
            rear.link = temp;
            rear = temp;
        }
        /// <summary>
        /// remove the data from queue.
        /// </summary>
        /// <returns></returns>
        public T deQueue()
        {
            T data=default(T);
            if (front == null)
            {
                Console.WriteLine("Queue Underflow");
            }
            else if (front == rear)
            {
                data = front.data;
                front = null;
                rear = null;
               
            }
            else
            {
                data=front.data;
                front = front.link;
               
            }
            return data;
        }
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool isEmpty()
        {
            if (front == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void display()
        {
            Node node = front;
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.link;
            }
        }
    }
}