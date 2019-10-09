// --------------------------------------------------------------------------------------------------------------------
// <copyright file=OrderedList.cs" company="Bridgelabz">
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
    /// OrderedList is a class with OperationOrderedFile() method
    /// to read data from file and operate on him
    /// </summary>
    class OrderedList
    {
        LinkedList<int> list = new LinkedList<int>();
        Utility util = new Utility();
        /// <summary>
        /// Operations the ordered file.
        /// </summary>
        public void OperationOrderedFile()
        {
          ////Reading the file  
            string st = util.ReadFile("C://Users//Bridgelabz//source//repos//DataStructure//Node1.txt");
            string[] str = st.Split(" ");
            for (int i=0;i<str.Length-1;i++)
            {
                ////adding in too list 
                list.AddLast(Convert.ToInt32(str[i]));
            }
            Console.WriteLine("Enter the Element That You Want To Search");
            int element = util.InputInteger();
            ////Searching element and if found then delete and add all data in file
            ////,if not found then add in to the list and then all data add in to the file
            bool b=list.Search(element);
            if(b==true)
            {
                Console.WriteLine(" Element Found And Element Deleted");
                list.Delete(element);
                bool f=util.WriteInFile("C://Users//Bridgelabz//source//repos//DataStructure//Node1.txt", list.GetLinkLis());
                list.ReadAll();
                if (f == true)
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
                Console.WriteLine("Element Not Found And Element added");
                list.SortedInsert(element);
                bool f = util.WriteInFile("C://Users//Bridgelabz//source//repos//DataStructure//Node1.txt", list.GetLinkLis());
                list.ReadAll();
                if (f == true)
                {
                    Console.WriteLine("Write all Element in File");
                }
                else
                {
                    Console.WriteLine("Not Write in File");
                }
            }
        }
    }
}