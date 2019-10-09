// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Calender.cs" company="Bridgelabz">
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
    /// Calender is a class For taking user inputprint that month year of the calender infront of them
    /// </summary>
    class Calender
    {
        /// <summary>
        /// Display the Calender
        /// </summary>
        /// <param name="m"></param>
        /// <param name="y"></param>
        public void DisplayCalender(int m, int y)
        {
            int d = Day(m, 1, y);
            int[,] cal = Cal2DArray(d,m,y);
            Display(cal,m,y);
        }
        /// <summary>
        /// day(int month, int day, int year) method to calculate the first day of the month.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int Day(int month, int day, int year)
        {
            int y = year - (14 - month) / 12;
            int x = y + y / 4 - y / 100 + y / 400;
            int m = month + 12 * ((14 - month) / 12) - 2;
            int d = (day + x + (31 * m) / 12) % 7;
            return d;
        }
        // return true if the given year is a leap year
        public static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0) && (year % 100 != 0)) return true;
            if (year % 400 == 0) return true;
            return false;
        }
        /// <summary>
        /// Cal2DArray(int d,int month,int year) in this method storing the calender in 2D array and return
        /// </summary>
        /// <param name="d"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int[,] Cal2DArray(int d,int month,int year)
        {
            // days[i] = number of days in month i
            int[] days = {
                    0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
                };
           // check for leap year
            if (month == 2 && IsLeapYear(year)) days[month] = 29;
           int[,] mycalendar= new int[6,7];
           int firstday =1;
       
           for (int i = 0; i< 6; i++)
           {
              for (int j = 0; j< 7; j++)
              {
                 if(d-- > 0)
                 { // fixing first day of month's weekday to start counting from tuesday for example
                   continue;
                 }
                 mycalendar[i,j] = firstday++;
        	     if (firstday > days[month]) {
        	          goto End;                   // its come out from the outer loop.
        	     }
              }
           }
           End:;
           return mycalendar;
        }
        /// <summary>
        /// Finally its display in calender format
        /// </summary>
        /// <param name="Calender"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public void Display(int[,] Calender,int month, int year)
        {
            string[] months = {
                    "",                               // leave empty so that months[1] = "January"
                    "January", "February", "March",
                    "April", "May", "June",
                    "July", "August", "September",
                    "October", "November", "December"
                };
            // print calendar header
            Console.WriteLine("\t\t\t" + months[month] + " " + year);
            Console.WriteLine();
            Console.WriteLine("su\tM\tTu\tW\tTh\tF\tSa");
            for (int i=0;i<Calender.GetLength(0);i++)
            {
                for(int j=0;j<Calender.GetLength(1);j++)
                {
                    if(Calender[i,j]==0)
                    {
                        Console.Write("\t");
                        continue;
                    }
                    Console.Write(Calender[i,j]+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}