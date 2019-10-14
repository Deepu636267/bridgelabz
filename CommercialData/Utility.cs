// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.CommercialData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// Utility is class for the code reuseability
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Determines whether the specified username contains character.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <c>true</c> if the specified username contains character; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsCharacter(string username)
        {
            try
            {
                char[] typeCharacter = username.ToCharArray();
                for (int i = 0; i < typeCharacter.Length; i++)
                {
                    if (!char.IsLetterOrDigit(typeCharacter[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception(ex.Message);
            }
            return true;
        }
        /// <summary>
        /// Conatainses the digit.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static bool ConatainsDigit(string username)
        {
            try
            {
                char[] nameDigit = username.ToCharArray();
                for (int i = 0; i < nameDigit.Length;i++)
                {
                    if (char.IsDigit(nameDigit[i]))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Checks the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static bool CheckString(string name)
        {
            try
            {
                //// Removing all  white space character from the current string object. 
                name = name.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        /// <summary>
        /// Determines whether the specified input is number.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
       ///   <c>true</c> if the specified input is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(string input)
        {
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input[i]) == false)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// Pathes the data.
        /// </summary>
        /// <returns></returns>
        public static string pathData()
        {
            string path = (@"C:\Users\Bridgelabz\source\repos\OOPS\CommercialData\CommercialList.json");
            return path;
        }
    }
}