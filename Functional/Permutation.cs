// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Permutation.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Permutation
    {
        string result = "";
        Utility util = new Utility();
        public void PermutateString()
        {
          string str = util.InputString();
          string ar= Permutation1(str.ToCharArray(), 0);
          string[] ar1 = ar.Split(" ");
          Console.WriteLine(ar1.Length);
          for(int i=0;i<ar.Length;i++)
          {
            Console.Write(ar[i]);
          }
        }
        public string Permutation1(char[] ch, int current)
        {
            
            if (current == ch.Length - 1)
            {
                string s = new string(ch);
                result = result + s + " ";
                // Console.WriteLine(ch);
            }
            for (int i = current; i < ch.Length; i++)
            {
                Swap(ch, current, i);
                Permutation1(ch, current + 1);
                Swap(ch, current, i);
            }
            return result;
        }
        /// <summary>
        /// Swaps the specified ch.
        /// </summary>
        /// <param name="ch">The ch.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        public static void Swap(char[] ch, int i, int j)
        {
            char temp = ch[i];
            ch[i] = ch[j];
            ch[j] = temp;
        }
    }
}