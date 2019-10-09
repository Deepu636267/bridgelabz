// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BalancedParenthesis.cs" company="Bridgelabz">
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
    /// BalancedParenthesis is a class to check that given parenthesis in equation have balanced or not
    /// By using this Balanced(char[] arr) method
    /// </summary>
    class BalancedParenthesis
    {
        /// <summary>
        /// Balanceds the specified arr.
        /// if(we found open parenthises then push in the stack if close then its pop it and compare both are same or not        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns></returns>
        public bool Balanced(char[] arr)
        {
            Stack st = new Stack();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '{' || arr[i] == '[' || arr[i] == '(')
                {
                    st.Push(arr[i]);
                }
                else if (arr[i] == '}' || arr[i] == ']' || arr[i] == ')')
                {
                    if (st.IsEmpty())
                    {
                        return false;
                    }
                    else if (!st.IsMatchingParenthesis(st.Pop(), arr[i]))
                    {
                        return false;
                    }

                }
            }
            ////if whole stack is empty then it is balanced
            if (st.IsEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
