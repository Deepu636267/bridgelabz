// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AddressBookOperation.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS.AddressBookModel
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    /// <summary>
    /// BookMethod is a inteface which declare the method in it which is used in class
    /// </summary>
    interface BookMethod
    {
        void Add();
        void Opertaion();
        void Delete();
    }
    /// <summary>
    /// AddressBookOperation  is class which inherit the property of inteface BookMethod
    /// </summary>
    /// <seealso cref="OOPS.AddressBookModel.BookMethod" />
    class AddressBookOperation :BookMethod
    {
        /// <summary>
        /// Operations this instance.
        /// </summary>
        public void Operation()
        {
             string message = null;
            ////Read the json file
            NewAddress newAccount = JsonRead.JsonReadFile();
            List<BookModel> accounts = newAccount.AddressList;
            try
            {
                ////Printing the data from read.
                int i = 1;
                foreach (BookModel item in accounts)
                {
                    Console.WriteLine("Number" + i++);
                    Console.WriteLine();
                    Console.WriteLine("FirstName is: " + item.FirstName);
                    Console.WriteLine("LastName is: " + item.LastName);
                    Console.WriteLine("Phone Number is: " + item.PhoneNumber);
                    Console.WriteLine("City is : " + item.City);
                    Console.WriteLine("State is: " + item.State);
                    Console.WriteLine("Zip is: " + item.Zip);
                }
                Console.WriteLine("Enter the Firstname you want to update");
                string Firstname = Console.ReadLine();
                ////For updation in the data which we will read
                foreach (BookModel item in accounts)
                {
                    if (item.FirstName.Equals(Firstname))
                    {
                        Console.WriteLine("What Do you Want To Change.... ");
                        Console.WriteLine("1.For Last Name"+"\n2.For Phone Number"+"\n3.For City"+"\n 4.For State" +"\n5.For Zip");
                        int Choice = Convert.ToInt32(Console.ReadLine());
                        switch(Choice)
                        {
                            case 1:
                                Console.WriteLine("Enter the Last Name..");
                                string lastname=Console.ReadLine();
                                item.LastName = lastname;
                                break;
                            case 2:
                                Console.WriteLine("Enter the New Phone Number");
                                long number = Convert.ToInt64(Console.ReadLine());
                                item.PhoneNumber = number;
                                break;
                            case 3:
                                Console.WriteLine("Enter the New City name");
                                string NewCity = Console.ReadLine();
                                item.City = NewCity;
                                break;
                            case 4:
                                Console.WriteLine("Enter the New State");
                                string NewState = Console.ReadLine();
                                item.State = NewState;
                                break;
                            case 5:
                                Console.WriteLine("Enter the New Zip Code");
                                long NewZip = Convert.ToInt64(Console.ReadLine());
                                item.Zip = NewZip;
                                break;
                        }
                        FileWrite.WriteInToFile(newAccount);
                        Console.WriteLine(Firstname + "Address Book has Been Succefully Updated");
                    }
                    else
                    {
                        message = ("you cannot update");
                    }
                }
                Console.WriteLine(message);
                Console.WriteLine("do you wanty to continue (y/n)");
                string repeat = Console.ReadLine();
                if (repeat == "y" || repeat == "Y")
                {
                    AddressBookOperation addressBook = new AddressBookOperation();
                    addressBook.Operation();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Adds the specified book.
        /// </summary>
        /// <param name="book">The book.</param>
        public void Add()
        {
            try
            {
                Console.WriteLine("Enter the Name..");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter the Last Name");
                string lastname = Console.ReadLine();
                Console.WriteLine("Enter the Phone Number..");
                long number = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter the City name..");
                string city = Console.ReadLine();
                Console.WriteLine("Enter the State Name");
                string state = Console.ReadLine();
                Console.WriteLine("Enter the Zip Code");
                long zip = Convert.ToInt64(Console.ReadLine());
                BookModel.CreateAccountObject(firstname,lastname, number, city, state, zip);
                Console.WriteLine("New Data Will be Added SuccesFully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Deletes this instance or specific data.
        /// </summary>
        public void Delete()
        {
            Console.WriteLine("Enter the Name Which Data You Want to delete:");
            string name = Console.ReadLine();
            NewAddress newAccount = JsonRead.JsonReadFile();
            List<BookModel> account = newAccount.AddressList;
            ////Searching and delting the data which have been enter by user.
            foreach (BookModel item in account)
            {
                if (item.FirstName.Equals(name))
                {
                    account.Remove(item);
                    break;
                }
             
            }
            /////Write in the file
            FileWrite.WriteInToFile(newAccount);
            Console.WriteLine(name + "Address Book has Been Succefully Deleted");
        }
        public void Opertaion()
        {
            throw new NotImplementedException();
        }
    }
}