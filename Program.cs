// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Algorithm
{
    using System;
    /// <summary>
    /// Program class holds the Main class from where we excute our Program with (.exe)file
    /// </summary>
    class Program
    {
        /// <summary>
        /// main method is a entry point
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            ////Utility is predefine some method for reuse
                Utility util = new Utility();
                Console.WriteLine("List Of Programs....");
                Console.WriteLine("1. Check Angram Between Two String" + "\n2. Prime Number Between 0 to 1000" + "\n3. Find the Prime Number and Pallindrome and Anagram of intger between 0 to 1000"
                                    + "\n4. Searchin And Sorting Method Of Integer And String" + "\n5. Guess The Number" + "\n6. Binary Search From File" + "\n7. Insertion Sort For String" + "\n8. Bubble Sort For Integer"
                                    + "\n9. Merge Sort For Integer" + "\n10. For Note Change" + "\n11. Find the Day" + "\n12. Temperature Conversion" + "\n13. Monthly Payment"
                                   + "\n14. Square Root Of Non Negative Number" + "\n15. Convert Decimal Number to Binary Number" + "\n16. Swap Nibbles in Binary Number");                
                Console.WriteLine("Enter Your Choice");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                ////here switch is used to operate the program through user choice with its choice to make object of that class and call thier Method
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nFinding the Angaram between two string Operation To be Performed:");
                        Angaram ana = new Angaram();
                        ana.CheckAnagram();
                        break;
                    case 2:
                        Console.WriteLine("\nFinding the Prime Number Between 0 to 1000 Operation To be Performed:");
                        PrimeNumber prime = new PrimeNumber();
                        prime.Prime();
                        break;
                    case 3:
                        Console.WriteLine("\nFinding the Prime Number Between 0 to 1000  and then find pallindrome an then Anagram Operation To be Performed:");
                        PAP aP = new PAP();
                        aP.CheckPAP();
                        break;
                    case 4:
                        Console.WriteLine("\nAll Searching and Sorting Operation To be Performed:");
                        SS s = new SS();
                        s.Operation();
                        break;
                    case 5:
                        Console.WriteLine("\nPlay the Guess Game Number:");
                        Console.WriteLine("guess a no between 0 to 1000");
                        int d6 = util.InputInteger();
                        GuessGame game = new GuessGame();
                        game.Find();
                        break;
                    case 6:
                        Console.WriteLine("\nBinary Search From file Operation To be Performed:");
                        BinarySearchFile fileHandle = new BinarySearchFile();
                        fileHandle.File();
                        break;
                    case 7:
                        Console.WriteLine("\nInsertion Sort for String Operation To be Performed:");
                        InsertionString insertion = new InsertionString();
                        insertion.Sort();
                        break;
                    case 8:
                        Console.WriteLine("\nBubbleSort for Integer Operation To be Performed:");
                        BubbleSortInteger integer = new BubbleSortInteger();
                        integer.Bubble();
                        break;
                    case 9:
                        Console.WriteLine("\nMerge Sort for String Operation To be Performed:");
                        Console.WriteLine("Enter the Size Of Array");
                        int n4 = util.InputInteger();
                        Console.WriteLine("Enter the Array Element in String type");
                        string[] ar4 = new string[n4];
                        for (int i = 0; i < n4; i++)
                        {
                            ar4[i] = util.InputString();
                        }
                        MergeSort merge = new MergeSort();
                        string[] find4 = merge.Sort(ar4, 0, ar4.Length - 1);
                        Console.WriteLine("After Soting");
                        merge.PrintArray(find4);
                        break;
                    case 10:
                        Console.WriteLine("\nVending Machine Operation To be Performed:");
                        Console.WriteLine("Enter the amount do you want change");
                        int amount = util.InputInteger();
                        Notes notes = new Notes();
                        notes.CountCurrency(amount);
                        break;
                    case 11:
                        Console.WriteLine("\nFor calculating the day Operation To be Performed:");
                        Day day = new Day();
                        day.CalculateDay();
                        break;
                    case 12:
                        Console.WriteLine("\nTemperature Conversion Operation To be Performed:");
                        TemperatureConversion temp = new TemperatureConversion();
                        temp.Converter();
                        break;
                    case 13:
                        Console.WriteLine("\nCalculating the Monthly PAyment Operation To be Performed:");
                        MonthlyPayment monthly = new MonthlyPayment();
                        monthly.Payment();
                        break;
                    case 14:
                        Console.WriteLine("\nFinding the Square Root of Non negative Number Operation To be Performed:");
                        SqrtNonNegative sqr = new SqrtNonNegative();
                        sqr.Sqrt();
                        break;
                    case 15:
                        Console.WriteLine("\nConversion From Deimal To binary Operation To be Performed:");
                        DecimalToBinary binary = new DecimalToBinary();
                        binary.Binary();
                        break;
                    case 16:
                        Console.WriteLine("\nConver sion From Decimal to binary then Swa nibbles And then check the power of two Operation To be Performed:");
                        SwapNibbles swap = new SwapNibbles();
                        swap.Swap();
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}