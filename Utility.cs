// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Utility.cs" company="Bridgelabz">
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
    /// Utility is a class Which holds All The logical method of Some Program For Code ReuseAbility
    /// </summary>
    class Utility
    {
        /// <summary>
        /// These VAriables are for calculating the Stop watch Elapsed time
        /// </summary>
        long startTimer;
        long stopTimer;
        long elapsed;
        /// <summary>
        /// Inputs the integer.
        /// </summary>
        /// <returns></returns>
        public int InputInteger()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        /// <summary>
        /// Inputs the string.
        /// </summary>
        /// <returns></returns>
        public string InputString()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Inputs the double.
        /// </summary>
        /// <returns></returns>
        public double InputDouble()
        {
            return Convert.ToDouble(Console.ReadLine());
        }
        /// <summary>
        /// Anagrams Method to check BEtween Two string the Two String.
        /// </summary>
        /// <param name="str1">The STR1.</param>
        /// <param name="str2">The STR2.</param>
        /// <returns></returns>
        public bool AnagramString(string str1, string str2)
        {
            ////To check the Both String length if they then its follow the Anagram process other wise its quit
            if (str1.Length == str2.Length)
            {
                char[] str = str1.ToCharArray();
                char[] st = str2.ToCharArray();
                str = BubbleSortString(str);
                st = BubbleSortString(st);
                for (int i = 0; i < str1.Length; i++)
                    if (str[i] != st[i])
                        return false;
            }
            else
            {
                Console.WriteLine("Both String Re not smae Length");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Bubbles the sort string.
        /// </summary>
        /// <param name="str3">The STR3.</param>
        /// <returns></returns>
        public char[] BubbleSortString(char[] str3)
        {
            for(int i=0;i<str3.Length;i++)
            {
                for(int j=0;j<str3.Length-i-1;j++)
                {
                    ////it has comparing the value with next one
                    if(str3[j].CompareTo(str3[j+1])>0)
                    {
                        char temp = str3[j];
                        str3[j] = str3[j + 1];
                        str3[j + 1] = temp;
                    }                                    
                }
            }
            return str3;
        }
        /// <summary>
        /// Determines whether the specified n is prime.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        ///   <c>true</c> if the specified n is prime; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPrime(int n)
        {
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Determines whether the specified n is pallindrome.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns>
        ///   <c>true</c> if the specified n is pallindrome; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPallindrome(int n)
        {
            int temp = n;
            int sum = 0;
            while (temp != 0)
            {
                int r = temp % 10;
                sum = sum * 10 + r;
                temp = temp / 10;
            }
            if (sum == n)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check the two Integer angram or not Anagrams the int uses when find the prime number and then anagram.
        /// </summary>
        /// <param name="n1">The n1.</param>
        /// <param name="n2">The n2.</param>
        /// <returns></returns>
        public bool AnagramInt(int n1, int n2)
        {
            int[] n1count = Count(n1);
            int[] n2count = Count(n2);
            for (int i = 0; i < n2count.Length; i++)
            {
                if (n1count[i] != n2count[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Counts the specified n and return in array thedigit has how many times repeat uses in finding angram b/w two Digit.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public int[] Count(int n)
        {
            int[] count = new int[10];
            int temp = n;
            while (temp != 0)
            {
                int r = temp % 10;
                count[r]++;
                temp = temp / 10;
            }
            return count;
        }
        /// <summary>
        /// Bubbles the sort integer.
        /// </summary>
        /// <param name="str3">The STR3.</param>
        /// <returns></returns>
        public int[] BubbleSortInteger(int[] str3)
        {
            for (int i = 0; i < str3.Length; i++)
            {
                for (int j = 0; j < str3.Length - i - 1; j++)
                {
                    if (str3[j] > str3[j + 1])
                    {
                        int temp = str3[j];
                        str3[j] = str3[j + 1];
                        str3[j + 1] = temp;
                    }
                }
            }
            return str3;
        }
        /// <summary>
        /// Binary the search integer.
        /// </summary>
        /// <param name="ar">The ar.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int BinarySearchInteger(int[] ar, int item)
        {
            BubbleSortInteger(ar);
            int low = 0;
            int high = ar.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (ar[mid] == item)
                    return mid;
                else if (ar[mid] < item)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
        /// <summary>
        /// Binaries the search string.
        /// </summary>
        /// <param name="ar">The ar.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public int BinarySearchString(string[] ar, String item)
        {
            //bubbleSort(ar);
            int low = 0;
            int high = ar.Length;
            Console.WriteLine(high);
            while (low <= high)
            {
                int mid = (low + high) / 2;
                int r = ar[mid].CompareTo(item);
                if (r == 0)
                    return mid;
                else if (r < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return -1;
        }
        /// <summary>
        /// Bubbles the sort String type value.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns></returns>
        public string[] BubbleSort(string[] arr)
        {
            string temp = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                    }
                }
            }
            return arr;
        }/// <summary>
        /// Insertion Sort For Integer type Value
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertionSortInt(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = temp;
            }
            return arr;
        }
        /// <summary>
        /// Insertions the sort string.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns></returns>
        public string[] InsertionSortString(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                String temp = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].CompareTo(temp) > 0)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = temp;
            }
            return arr;
        }
        /// <summary>
        /// Start() method is used for start the stop watch.
        /// </summary>
        public void Start()
        {
            startTimer = DateTime.Now.Millisecond;
        }
        /// <summary>
        /// Stop() method is used for stop the stop watch..
        /// </summary>
        public void Stop()
        {
            stopTimer = DateTime.Now.Millisecond;
        }
        /// <summary>
        /// Gets the elapsed time.
        /// </summary>
        public void GetElapsedTime()
        {
            elapsed = stopTimer - startTimer;
            Console.WriteLine("Elapsed Time is: " + elapsed);
        }
        /// <summary>
        /// Merges the specified arr for the string.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <param name="l">The l.</param>
        /// <param name="m">The m.</param>
        /// <param name="r">The r.</param>
        public void Merge(string[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            string[] L = new string[n1];
            string[] R = new string[n2];
            for (int v = 0; v < n1; ++v)
            {
                L[v] = arr[l + v];
            }
            for (int u = 0; u < n2; ++u)
            {
                R[u] = arr[m + 1 + u];
            }
            int i = 0, j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        /// <summary>
        /// Finds the day.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="m">The m.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public int FindDay(int d, int m, int y)
        {
            int y0 = y - (14 - m) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = m + 12 * ((14 - m) / 12) - 2;
            int d0 = (d + x + (31 * m0) / 12) % 7;
            return d0;
        }
        /// <summary>
        /// Temprature conversion from degre celcius to Farenhite
        /// </summary>
        /// <param name="C">The c.</param>
        public void DC2F(int C)
        {
            int F = (C * 9 / 5) + 32;
            Console.WriteLine("After Converting " + "°" + C + " temprature in Farenhite is " + "°" + F);
        }
        ////  Temprature conversion from Farenhite to degre celcius 
        public void F2C(int F)
        {
            int C = (F-32)*9/5;
            Console.WriteLine("After Converting " + "°" + F + " temprature in Farenhite is " + "°" + C);
        }
        /// <summary>
        /// Calculates the monthly payment.
        /// </summary>
        /// <param name="P">The p.</param>
        /// <param name="n">The n.</param>
        /// <param name="r">The r.</param>
        public void CalculatePayment(double P, double n, double r)
        {
            double payment = (P * r) / (1 - Math.Pow((1 + r), (-n)));
            Console.WriteLine("The Monthly Payment is: " + payment);
        }
        /// <summary>
        /// Newtonses the method.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        public double NewtonsMethod(double c)
        {
            double t = c;
            double epsilon = 1e-15;
            while (Math.Abs(t - c / t) > epsilon * t)
            {
                t = (c / t + t) / 2;
            }
            return t;
        }
        /// <summary>
        /// Converts the decimal to binary.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public int[] ConvertBinary(int n)
        {
            string bin = "";
            while (n != 0)
            {
                int d = n % 2;
                bin = d + bin;
                n = n / 2;
            }
            while (bin.Length % 4 != 0)
            {
                bin = 0 + bin;
            }
            Console.WriteLine("Binary Number is " + bin);
            return StringToIntArray(bin);
        }
        /// <summary>
        /// Strings to int array.
        /// </summary>
        /// <param name="bin">The bin.</param>
        /// <returns></returns>
        public int[] StringToIntArray(string bin)
        {
            int i = Convert.ToInt32(bin);
            int[] a = new int[bin.Length];
            int k = 0;
            while (i != 0)
            {
                a[k++] = i % 10;
                i = i / 10;
            }
            return a;
        }
        /// <summary>
        /// Swaps the nibbles.
        /// </summary>
        /// <param name="arr">The arr.</param>
        /// <returns></returns>
        public int[] SwapNibbles(int[] arr)
        {
            // swap nibbles at first and last of the array
            // j is used for saving last 4 index of the array
            int temp, j = arr.Length / 2;
            for (int i = 0; i < arr.Length / 2; i++)
            { // loop runs 4 times and swap first four element to last four elements
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                j++;
            }
            return arr;
        }
        /// <summary>
        /// Powers the of2.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public bool PowerOf2(int n)
        {
            //// calculate power of 2 using math.pow
            //// check if is equal to given no
            //// stops if pow is greater than given number
            int i = 0, temp = (int)Math.Pow(2, i);
            while (temp <= n)
            {
                if (temp == n)
                {
                    return true;
                }
                i++;
                temp = (int)Math.Pow(2, i);
            }
            return false;
        }
    }
}