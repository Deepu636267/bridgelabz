// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Queue.cs" company="Bridgelabz">
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
    /// Queue is a class for all the Queue Operation 
    /// </summary>
    class Queue
    {
        char[] queue = new char[20];
        int front = -1;
        int rear = -1;
        int size = 0;
        /// <summary>
        /// Adds the element from  rear.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddRear(char item)
        {
            ////chck the queue array is full
            if(IsFull())
            {
                Console.WriteLine("Queue is Full");
                return;
            }
            else if(IsEmpty())
            {
                
                rear = 0;
                queue[rear] = item;
                size++;
            }
            else
            {
                queue[++rear] = item;
                size++;
            }
        }
        /// <summary>
        /// Adds the element from  front.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddFront(char item)
        {
            if (front==20)
            {
                Console.WriteLine("Queue is Full");
                return;
            }
            else if (IsEmpty())
            {
                front = rear = 0;
                queue[front] = item;
                size++;
            }
            else
            {
                queue[++front] = item;
                size++;
            }
        }
        /// <summary>
        /// Removes the element from  rear.
        /// </summary>
        /// <returns></returns>
        public char RemoveRear()
        {
            char it = queue[rear];
          //   Console.WriteLine(item);
            rear--;
            size--;
            return it;
            
         }
        /// <summary>
        /// Removes the element from front.
        /// </summary>
        /// <returns></returns>
        public char RemoveFront()
        {

            front++;
            char item = queue[front];
           // Console.WriteLine(item);
               
                size--;
                return item;
        }
        /// <summary>
        /// Peeks this instance for finding the top element in queue.
        /// </summary>
        public void Peek()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                Console.WriteLine("Front Element is : " + queue[front]);
            }
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            if(IsEmpty())
            {
                return;
            }
            else
            {
                for(int i=0;i<rear+1;i++)
                Console.WriteLine(queue[i]);
            }
        }
        /// <summary>
        /// Determines whether this instance is full.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is full; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFull()
        {
            if(rear==20)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmpty()
        {
            if(front==-1 && rear==-1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Totals this instance gives the total size of Queue.
        /// </summary>
        /// <returns></returns>
        public int Total()
        {
            return size;
        }
    }
}