// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AddressBookMain.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.AddressBookModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// AddressBookMain is a class Which has responsible for all operation Can perform Thorugh this class 
    /// </summary>
    class AddressBookMain
    {
        /// <summary>
        /// Operations this instance.to opreate according to the user choice
        /// </summary>
        public void Operation()
        {
            AddressBookOperation address = new AddressBookOperation();
            Console.WriteLine("Enter your choice what You Perform");
            Console.WriteLine("1.Update the Data" + "\n2.Add the New Data" + "\n3.Delete the data");
            int choice = Convert.ToInt32(Console.ReadLine());
            ////For the User choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Updation Going On......");
                    address.Operation();
                    break;
                case 2:
                    Console.WriteLine("New Data Addition is running.....");
                    address.Add();
                    break;
                case 3:
                    Console.WriteLine("Deletion Operation is Running......");
                    address.Delete();
                    break;
            }
        }
    }
}