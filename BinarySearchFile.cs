// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BinarySearchFile.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    /// <summary>
    /// BinarySearchFile is class 
    /// </summary>
    class BinarySearchFile
    {
        Utility util = new Utility();
        /// <summary>
        /// Files this instance to read the string from file.
        /// </summary>
        public void File()
        {
            // Takinga a new input stream i.e.  
            // geeksforgeeks.txt and opens it 
            StreamReader sr = new StreamReader("C://Users//Bridgelabz//source//repos//Algorithm//Data.txt");
            string str = sr.ReadLine();
            string st = "";
            // To read the whole file line by line 
            while (str != null)
            {
                st = str + st;
                str = sr.ReadLine();
            }
            //// split the string line with space and put in the array
            string[] data = st.Split(" ");
            string[] data1 = util.BubbleSort(data);
            for(int i=0;i<data1.Length;i++)
            {
                Console.WriteLine(data1[i]);
            }
            Console.WriteLine("Enter the String Do you Want To search");
            string item=util.InputString();
            int found = util.BinarySearchString(data1,item);
            if(found==-1)
            {
                Console.WriteLine(item + " are Not Found.");
            }
            else
            {
                Console.WriteLine(item + " Found At " + found+1 + " index");
            }
            // to close the stream 
            sr.Close();
        }
    }
}