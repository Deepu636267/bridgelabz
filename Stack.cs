// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Stack.cs" company="Bridgelabz">
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
    /// Stack is a class for all the operation of stack
    /// </summary>
    class Stack
    {
        int top = -1;
        char[] stack = new char[50];
        /// <summary>
        /// Pushes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Push(char item)
        {
            if (top == 49)
            {
               Console.WriteLine("Stack is full");
                return false;
            }
            else
            {
                stack[++top] = item;
                return true;
            }
        }
        /// <summary>
        /// Pops the element .
        /// </summary>
        /// <returns></returns>
        public char Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return '\0';
            }
            else
            {
                char item = stack[top];
                top--;
                return item;
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
            return (top == -1) ? true : false;
        }
        // <summary>
        /// Determines whether [is matching parenthesis] [the specified CH1].
        /// </summary>
        /// <param name="ch1">The CH1.</param>
        /// <param name="ch2">The CH2.</param>
        /// <returns>
        ///   <c>true</c> if [is matching parenthesis] [the specified CH1]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatchingParenthesis(char ch1, char ch2)
        {
            if (ch1 == '(' && ch2 == ')')
                return true;
            else if (ch1 == '[' && ch2 == ']')
                return true;
            else if (ch1 == '{' && ch2 == '}')
                return true;
            else
                return false;
        }
    }
}