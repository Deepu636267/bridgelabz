// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PAStack.cs" company="Bridgelabz">
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
    /// PAStack is class to find  prime number through Stack using Linked List
    /// </summary>
    class PAStack
    {
        Utility util = new Utility();
        StackLinkedList<int> Stack = new StackLinkedList<int>();
        /// <summary>
        /// find Prime number and store in the stack.
        /// </summary>
        public void PrimeStack()
        {
            for(int i=2;i<=1000;i++)
            {
                if(util.Prime(i))
                {
                    Stack.Push(i);
                }
            }
            /////poping element one by one and pint in Linked List Class
            while(!Stack.IsEmpty())
            {
               Stack.Pop();
            }
        }
    }
}