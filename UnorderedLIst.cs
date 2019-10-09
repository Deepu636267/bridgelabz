// --------------------------------------------------------------------------------------------------------------------
// <copyright file=UnorderedLIst.cs" company="Bridgelabz">
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
    /// UnorderedLIst is class for reading hte data from file
    /// and performed operation on it through LinkedList
    /// </summary>
    class UnorderedLIst
    {
        Utility util = new Utility();
        LinkedList<string> link = new LinkedList<string>();
        /// <summary>
        /// Operations the file.
        /// </summary>
        public void OperationFile()
        {

            string st = util.ReadFile("C://Users//Bridgelabz//source//repos//DataStructure//Node.txt");
            //// split the string line with space and put in the array
            string[] data = st.Split(" ");
             for(int i=0;i<data.Length;i++)
            {
                link.AddLast(data[i]);
            }
            link.ReadAll();
            Console.WriteLine("Enter the Element YOu want to search");
            string element = util.InputString();
            ////Searching element and if found then delete and add all data in file
            ////,if not found then add in to the list and then all data add in to the file
            bool find = link.Search(element);
            if (find==true)
            {
                link.Delete(element);
                Console.WriteLine(element + "Deleted");
                bool f = util.WriteInFile("C://Users//Bridgelabz//source//repos//DataStructure//Node.txt", link.GetLinkLis());
                if(f==true)
                {
                    Console.WriteLine("Write all Element in File");
                }
                else
                {
                    Console.WriteLine("Not Write in File");
                }
                
            }
            else
            {
                link.AddLast(element);
                Console.WriteLine(element + "Added");
                bool f = util.WriteInFile("C://Users//Bridgelabz//source//repos//DataStructure//Node.txt", link.GetLinkLis());
                if (f == true)
                {
                    Console.WriteLine("Write all Element in file");
                }
                else
                {
                    Console.WriteLine("Not Write in File");
                }
            }
        }
    }
}