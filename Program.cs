// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DataStructure
{
    using System;
    /// <summary>
    /// Program is a class to hold all the opreation and main functon 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Utility util = new Utility();
            Console.WriteLine("List Of Programs....................");
            Console.WriteLine("1. Unordered List Handling With file" + "\n2. Ordered List Handling With File" + "\n3. Balanced Parenthesis" 
                + "\n4. For Banking Operation" + "\n5. Pallindrome Checker" + "\n6. For Hasing Function" + "\n7. Find the Number of Nodes In BST"
                + "\n8. Printing calender in 2DArray"+ "\n11. Find Prime Number And store in 2D array" + "\n12. Finding Anagram that are prime(0 to 1000) Store in 2DArray"
                + "\n13. Finding Anagram that are prime(0 to 1000) Using Stack Operation(LinkedList)" + "\n14. Finding Anagram that are prime(0 to 1000) Using Queue(LinkedList)");
            Console.WriteLine("Enter your Choice");
            try
            {
                int choice = util.InputInteger();
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("1. Unordered List Handling With file");
                        UnorderedLIst unordered = new UnorderedLIst();
                        unordered.OperationFile();
                        break;
                    case 2:
                        Console.WriteLine("\n2. Ordered List Handling With File");
                        OrderedList or = new OrderedList();
                        or.OperationOrderedFile();
                        break;
                    case 3:
                        Console.WriteLine("\n3. Balanced Parenthesis");
                        BalancedParenthesis balanced = new BalancedParenthesis();
                        Console.WriteLine("Enter the Expresiion");
                        string s = util.InputString();
                        char[] arr = s.ToCharArray();
                        if (balanced.Balanced(arr) == true)
                        {
                            Console.WriteLine("TRUE");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\n4. For Banking Operation");
                        BankingCashCounter banking = new BankingCashCounter();
                        banking.CashCounter();
                        break;
                    case 5:
                        Console.WriteLine("\n5. Pallindrome Checker");
                        PallindromeChecker checker = new PallindromeChecker();
                        checker.Pallindrome();
                        break;
                    case 6:
                        Console.WriteLine("\n6. For Hasing Function");
                        NewHash hash = new NewHash();
                        hash.HashingFunction();
                        break;
                    case 7:
                        Console.WriteLine("\n7. Find the Number of Nodes In BST");
                        NumberOfBST BST = new NumberOfBST();
                        Console.WriteLine("Enter that how Many Elment you Want to Calculate BST");
                        int n = util.InputInteger();
                        Console.WriteLine("Enter the Element");
                        int[] arr1 = new int[n];
                        for(int i=0;i<n;i++)
                        {
                            arr1[i] = util.InputInteger();
                        }
                        BST.CalculationBST(arr1);
                        break;
                    case 8:
                        Console.WriteLine("\n8. Printing calender in 2DArray");
                        Console.WriteLine("Enter the Month OF that Calender You Want to Print");
                        int m = util.InputInteger();
                        Console.WriteLine("Enter the Year Of that Calender You Want to Print");
                        int y = util.InputInteger();
                        int temp = y;
                        int count = 0;
                        while(temp!=0)
                        {
                            count++;
                            temp = temp / 10;
                        }
                        Calender calender = new Calender();
                        if (m > 0 && count == 4)
                            calender.DisplayCalender(m, y);
                        else
                            Console.WriteLine("Check your inputs");
                        break;
                    case 11:
                        Console.WriteLine("\n11. Find Prime Number And store in 2D array");
                        Prime2DArray array = new Prime2DArray();
                        array.Add();
                        break;
                    case 12:
                        Console.WriteLine("\n12. Finding Anagram that are prime(0 to 1000) Store in 2DArray");
                        PA2DArray pA = new PA2DArray();
                        pA.AddAngaram();
                        break;
                    case 13:
                        Console.WriteLine("\n13. Finding Anagram that are prime(0 to 1000) Using Stack Operation(LinkedList)");
                        PAStack pA1 = new PAStack();
                        pA1.PrimeStack();
                        break;
                    case 14:
                        Console.WriteLine("\n14. Finding Anagram that are prime(0 to 1000) Using Queue(LinkedList)");
                        PrimeAnaQueue primeAna = new PrimeAnaQueue();
                        primeAna.FindingPA();
                        break;
                   
               }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}