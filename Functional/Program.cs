// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Functional
{
    using System;
    /// <summary>
    /// Program is a class its take main method
    /// </summary>
    class Program
    {
        /// <summary>
        /// main method is a entry point
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Utility util = new Utility();
            Console.WriteLine("List Of Programs....");
            Console.WriteLine("1. To Find the ReplaceString" + "\n2. To Find the Flip Coin" + "\n3. To Find theLeap year"
                              + "\n4. To find the Power Of 2" +"\n5. To find the Nth Harmonic Value" + "\n6. To Find the Prime Factor"
                              + "\n7. To Play the Gambler Game" + "\n8. To Genrate the Coupon Number" + "\n9. 2D Array"
                              + "\n10. Sum of Triplet In Array" + "\n11. Find the Euclidean Distance" + "\n13. Get Elapsed Time In Stop Watch" + "\n15. Find the Root Of Quadratic Equation"
                              + "\n16. To calculate the WindChill");
            Console.WriteLine("Enter Your Choice");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                ////here switch is used to operate the program through user choice and for them making raltive object class 
                ///and call their method to perform the operation
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nReplace String Operation to be Performed :");
                        ReplaceString replaceString = new ReplaceString();
                        replaceString.Replace();
                        break;
                    case 2:
                        Console.WriteLine("\nFlip coin Operation to be Performed :");
                        FlipCoin flipCoin = new FlipCoin();
                        flipCoin.Flip();
                        break;
                    case 3:
                        Console.WriteLine("\nLeap Year Operation to be Performed :");
                        LeapYear leapy = new LeapYear();
                        leapy.Leap();
                        break;
                    case 4:
                        Console.WriteLine("\nFinding Power of 2 Operation to be Performed :");
                        PowerOf2 power2 = new PowerOf2();
                        power2.Power();
                        break;
                    case 5:
                        Console.WriteLine("\nFinding Harmonic Number Operation to be Performed :");
                        HarmonicNumber number = new HarmonicNumber();
                        number.Harmonic();
                        break;
                    case 6:
                        Console.WriteLine("\nFinding Prime Number Operation to be Performed :");
                        PrimeFactor prime = new PrimeFactor();
                        prime.Factor();
                        break;
                    case 7:
                        Console.WriteLine("\nPlay the Gambler game:");
                        Gambler gambler = new Gambler();
                        gambler.Play();
                        break;
                    case 8:
                        Console.WriteLine("\nFinding Distinct Coupon Number Operation to be Performed :");
                        Coupon coupon = new Coupon();
                        Console.WriteLine("Enter the Number to genrate Distinct Coupon Number");
                        int n = util.InputInteger();
                        int count = coupon.Collect(n);
                        Console.WriteLine("Total count of distinct coupon Number is :" + count);
                        break;
                    case 9:
                        Console.WriteLine("\n2D Array Operation to be Performed :");
                        Console.WriteLine("Enter the Number of Rows");
                        int r = util.InputInteger();
                        Console.WriteLine("Enter the Number of Columns");
                        int co = util.InputInteger();
                        TwoDArray dArray = new TwoDArray();
                        int[,] arrInt1 = dArray.ArrayInteger(r, co);
                        double[,] arrDouble1 = dArray.Arraydouble(r, co);
                        bool[,] arrBool1 = dArray.ArrayBoolean(r, co);
                        dArray.Display(arrInt1, arrDouble1, arrBool1, r, co);
                        break;
                    case 10:
                        Console.WriteLine("\nFinding Triplet sum will be Zero In Array Operation to be Performed :");
                        Console.WriteLine("Enter the Number in how many Element you want to check");
                        int num = util.InputInteger();
                        SumOfArray sum = new SumOfArray();
                        sum.ArraySum(num);
                        break;
                    case 11:
                        Console.WriteLine("\nFinding Ecludian Distance Operation to be Performed :");
                        Console.WriteLine("Enter the first cordinate of distance");
                        int x = util.InputInteger();
                        Console.WriteLine("Enter the Second Cordinate of distance");
                        int y = util.InputInteger();
                        Distance distance = new Distance();
                        distance.EcludianDistance(x, y);
                        break;
                    case 12:
                        Console.WriteLine("\nFinding Permutation of String Operation to be Performed :");
                        Console.WriteLine("Enter the string Which you want to Find the Permutation");
                        Permutation permute = new Permutation();
                        permute.PermutateString();
                        break;
                    case 13:
                        Console.WriteLine("\nFinding Elapsed time in stop watch Operation to be Performed :");
                        StopWatch stop = new StopWatch();
                        Console.WriteLine("Enter 1 for start the Timer");
                        int h = util.InputInteger();
                        stop.Start();
                        Console.WriteLine("Enter 2 for stop the Timer");
                        int h1 = util.InputInteger();
                        stop.Stop();
                        long l = stop.GetElapsedTime();
                        Console.WriteLine("Elapsed time in milliSecond is: " + l);
                        break;
                    case 14:
                        TicTacToe tic = new TicTacToe();
                        tic.play();
                        break;
                    case 15:
                        Console.WriteLine("\nFinding Quadratic Roots  Operation to be Performed :");
                        Console.WriteLine("Enter Value of a To finding the Roots");
                        int a = util.InputInteger();
                        Console.WriteLine("Enter Value of b To finding the Roots");
                        int b = util.InputInteger();
                        Console.WriteLine("Enter Value of c To finding the Roots");
                        int c = util.InputInteger();
                        Quuadratic Root = new Quuadratic();
                        Root.FindRoot(a, b, c);
                        break;
                    case 16:
                        Console.WriteLine("\nConverting Temperature in Degree Celsicius to Farenhite And Vice Versa Operation to be Performed :");
                        Console.WriteLine("Enter the temperature in Farenhite");
                        double t = util.InputDouble();
                        Console.WriteLine("Enter the Wind Speed In Miles Per Hour");
                        double v = util.InputDouble();
                        WindMills wind1 = new WindMills();
                        wind1.Wind(t, v);
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}