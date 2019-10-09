// --------------------------------------------------------------------------------------------------------------------
// <copyright file=PA2DArray.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;
    /// <summary>
    /// PA2DArray is class for finding the anagram which are peime number between 0 to 1000.
    /// </summary>
    class PA2DArray
    {
        Utility util = new Utility();
        public void AddAngaram()
        {
                ArrayList ar = new ArrayList();
                int count = 0;
            ////adding the prime number in list by using inbuilt method ArrayList()
                for (int i = 2; i <= 1000; i++)
                {
                   if (util.Prime(i))
                        ar.Add(i);
                }
                ////Taking out from the list and check for anagram by holding one value and search in all list
                for (int i = 0; i < ar.Count; i++)
                {
                ////(int)ar[i]=type casting because ar[i] is a objct type so we are not give object type refrenceto instance of object
                int f = (int)ar[i];
                    for (int j = i + 1; j < ar.Count; j++)
                    {
                    ////Count the anagram for the rowsize of array
                        int f1 = (int)ar[j];
                        if (util.Anagram(f,f1))
                        {
                            count++;
                        }
                    }
                }
                ////Now taking two D array for storing an dprinting anagram which are are prime number
            int[,] array =new int[count,2];
		    int k = 0;
		    for (int i = 0; i<ar.Count; i++)
            {
                ////(int)ar[i]=type casting because ar[i] is a objct type so we are not give object type refrenceto instance of object
                int f = (int)ar[i];
                for (int j = i + 1; j<ar.Count; j++) 
                {
                    int f1 = (int)ar[j];
                    if (util.Anagram(f, f1))
                    {
                       Console.Write(array[k,0]= f);
                       Console.Write(" ");
                       Console.Write(array[k,1]=f1);
                       Console.WriteLine();
                        k++;
				    }
                }
    		}
        }
    }
}