// --------------------------------------------------------------------------------------------------------------------
// <copyright file=QueueLInkedList.cs" company="Bridgelabz">
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
    /// QueueLInkedList is class of Genric Type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class QueueLInkedList<T>
    {
        Node<T> front = null;
        Node<T> rear = null;
        int size = 0;
        /// <summary>
        /// add the item in queue.
        /// </summary>
        /// <param name="item">The item.</param>
        public void EnQueue(T item)
        {
            Node<T> newNode = new Node<T>();
            newNode.data = item;
            newNode.next = null;
            if(front==null && rear==null)
            {
                front = rear = newNode;
                size++;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
                size++;
            }
        }
        /// <summary>
        /// Displays all the data.
        /// </summary>
        public void Display()
        {
            if (front == null && rear == null)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                Node<T> temp = front;
                while(temp!=null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
            }
        }
        /// <summary>
        /// Dequeues the people who are in the line of bank.
        /// </summary>
        public void DequeueBank()
        {
            if (front == null && rear == null)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
              front = front.next;
            }
        }
        /// <summary>
        /// Dequeues this instance.
        /// </summary>
        public T Dequeue()
        {
            if (front == null && rear == null)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                
                Console.Write(front.data);
                Console.Write(" ");
                front = front.next;
                Console.WriteLine(front.data);
                front = front.next;
                size--;
            }
            return front.data;
        }
        /// <summary>
        /// Totals this instance find the total size of people in queue.
        /// </summary>
        /// <returns></returns>
        public int Total()
        {
            return size;
        }
    }
}