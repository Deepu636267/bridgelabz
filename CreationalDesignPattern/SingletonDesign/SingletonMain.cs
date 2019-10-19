// --------------------------------------------------------------------------------------------------------------------
// <copyright file=SingletonMain.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern.CreationalDesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    class SingletonMain
    {
        public void TestSingleton()
        {
            Console.WriteLine("Enter which Type of Test you Want through Singleton Design Pattern");
            Console.WriteLine("1.Singleton" +"\n2 Singleton with lazy Keyword"+"\n3.Thread Safe Singleton"+"\n4.Eager Loading in SingleTon");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    /* Assuming Singleton is created from employee class
                     * we refer to the GetInstance property from the Singleton class
                     */
                     Singleton fromEmployee = Singleton.GetInstance;
                    fromEmployee.PrintDetails("From Employee");
                    /* Assuming Singleton is created from student class
                    * we refer to the GetInstance property from the Singleton class
                    */
                    Singleton fromStudent = Singleton.GetInstance;
                    fromStudent.PrintDetails("From Student");
                    break;
                case 2:
                    Parallel.Invoke(
                                     () => PrintStudentdetails(),
                                     () => PrintEmployeeDetails()
                                         );
                    break;
                case 3:
                    Parallel.Invoke(
                                     () => PrintStudentdetails1(),
                                     () => PrintEmployeeDetails1()
                                         );
                    break;
                case 4:
                    Parallel.Invoke(
                                     () => PrintStudentdetails2(),
                                     () => PrintEmployeeDetails2()
                                         );
                    break;
            }

        }
        /// <summary>
        /// Prints the employee details.
        /// </summary>
        private static void PrintEmployeeDetails()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class
            LazyKeywordUses fromEmployee = LazyKeywordUses.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }
        /// <summary>
        /// Prints the studentdetails.
        /// </summary>
        private static void PrintStudentdetails()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class
            LazyKeywordUses fromStudent =LazyKeywordUses.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
        /// <summary>
        /// Prints the employee details1.
        /// </summary>
        private static void PrintEmployeeDetails1()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class
            CreationalDesignPattern.SingletonThreadSafe  fromEmployee = CreationalDesignPattern.SingletonThreadSafe.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }
        /// <summary>
        /// Prints the studentdetails1.
        /// </summary>
        private static void PrintStudentdetails1()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class
            SingletonThreadSafe fromStudent = SingletonThreadSafe.GetInstance;
             fromStudent.PrintDetails("From Student");
        }
        /// <summary>
        /// Prints the employee details2.
        /// </summary>
        private static void PrintEmployeeDetails2()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class   
            SingletonEagerLoading  fromEmployee = SingletonEagerLoading.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }
        /// <summary>
        /// Prints the studentdetails2.
        /// </summary>
        private static void PrintStudentdetails2()
        {
            //// Assuming Singleton is created from student class
            //// we refer to the GetInstance property from the Singleton class
            SingletonEagerLoading fromStudent = SingletonEagerLoading.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
    }
}