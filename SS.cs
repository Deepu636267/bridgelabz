// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SS.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// SS class holds all the searching and sorting operation
    /// </summary>
    class SS
    {
        Utility util = new Utility();
        /// <summary>
        /// Operations this instance holds all case to be performed with user choice.
        /// </summary>
        public void Operation()
        {
            Console.WriteLine("List Of the Program.................");
            Console.WriteLine("1.binarySearch method for integer" + " \n2.binarySearch method for String" + "\n 3.insertionSort method for integer"
                + "\n 4.insertionSort method for String" + " \n 5.bubbleSort method for integer" + "\n 6.bubbleSort method for String");
                Console.WriteLine("Enter choice For above Operation");
            try
            {
                int choice = util.InputInteger();
                ////switch() is used for operation performed by choice of user
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("binarySearch method for integer Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in integer type");
                        int[] ar = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            ar[i] = util.InputInteger();
                        }
                        Console.WriteLine("Enter the Value to Search");
                        int item = util.InputInteger();
                        util.Start();
                        int find = util.BinarySearchInteger(ar, item);
                        if (find == -1)
                            Console.WriteLine(item + " not Found");
                        else
                            Console.WriteLine(item + " Found at " + find);
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    case 2:
                        Console.WriteLine("binarySearch method for String Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n1 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in String type");
                        string[] ar1 = new string[n1];
                        for (int i = 0; i < n1; i++)
                        {
                            ar1[i] = util.InputString();
                        }
                        Console.WriteLine("Enter the Value to Search");
                        string item1 = util.InputString();
                        util.Start();
                        int find1 = util.BinarySearchString(ar1, item1);
                        if (find1 == -1)
                            Console.WriteLine(item1 + " not Found");
                        else
                            Console.WriteLine(item1 + " Found at " + find1);
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    case 3:
                        Console.WriteLine("Insertion sort method for Integer Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n2 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in integer type");
                        int[] ar2 = new int[n2];
                        for (int i = 0; i < n2; i++)
                        {
                            ar2[i] = util.InputInteger();
                        }
                        util.Start();
                        int[] find2 = util.InsertionSortInt(ar2);
                        Console.WriteLine("After Soting");
                        for (int i = 0; i < find2.Length; i++)
                        {
                            Console.Write(find2[i] + " ");
                        }
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    case 4:
                        Console.WriteLine("Insertion sort method for String Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n3 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in String type");
                        string[] ar3 = new string[n3];
                        for (int i = 0; i < n3; i++)
                        {
                            ar3[i] = util.InputString();
                        }
                        util.Start();
                        string[] find3 = util.InsertionSortString(ar3);
                        Console.WriteLine("After Soting");
                        for (int i = 0; i < find3.Length; i++)
                        {
                            Console.Write(find3[i] + " ");
                        }
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    case 5:
                        Console.WriteLine("Bubble sort method for Integer Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n4 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in integer type");
                        int[] ar4 = new int[n4];
                        for (int i = 0; i < n4; i++)
                        {
                            ar4[i] = util.InputInteger();
                        }
                        util.Start();
                        int[] find4 = util.BubbleSortInteger(ar4);
                        Console.WriteLine("After Soting");
                        for (int i = 0; i < find4.Length; i++)
                        {
                            Console.Write(find4[i] + " ");
                        }
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    case 6:
                        Console.WriteLine("Bubble sort method for String Operation to be Performed");
                        Console.WriteLine("Enter the Size Of Array");
                        int n5 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in String type");
                        string[] ar5 = new string[n5];
                        for (int i = 0; i < n5; i++)
                        {
                            ar5[i] = util.InputString();
                        }
                        util.Start();
                        string[] find5 = util.BubbleSort(ar5);
                        Console.WriteLine("After Soting");
                        for (int i = 0; i < find5.Length; i++)
                        {
                            Console.Write(find5[i] + " ");
                        }
                        util.Stop();
                        util.GetElapsedTime();
                        break;
                    default:
                        Console.WriteLine("Enter valid Input");
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}