// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace OOPS
{
    using System;
    /// <summary>
    /// Program is a class to represent that how the user will interact through us.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Yur Choice Which Method You Want to Perform.....");
            Console.WriteLine("1.For Inventory Data Mangement" + "2.\nFor Replace String Using Regex" + "\n3.For Stock Report"
                + "\n4.Inventory management" + "\n5.Commercial Data Mangaement" + "\n6.For Deck Card" + "\n7.for Deck Card using Queue linked list" + "\n8.For Address book");
            int choice = Convert.ToInt32(Console.ReadLine());
            ////User choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Inventory Data Management Pocess is going on... ");
                    InventoryManageMent.InventoryData inventory = new InventoryManageMent.InventoryData();
                    inventory.display();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 2:
                    Console.WriteLine("Replace String uing regex Process is going on....");
                    RegularExpression.Replace replace = new RegularExpression.Replace();
                    replace.RegexExp();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 3:
                    Console.WriteLine("Stock management Process Is Going on......");
                    StockReport.StockSummary stock = new StockReport.StockSummary();
                    stock.Summary();
                    break;
                case 4:
                    Console.WriteLine("IOnventory management Program Is going On....");
                    InventoryMangementData.InventoryManger manger = new InventoryMangementData.InventoryManger();
                    manger.Manger();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 5:
                    Console.WriteLine("Commercial Data management Process is going on...");
                    CommercialData.UserIntraction intraction = new CommercialData.UserIntraction();
                    intraction.UserChoice();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 6:
                    Console.WriteLine("Deck Card is Playing....");
                    Deck deck = new Deck();
                    deck.InitializeDeckofCard();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 7:
                    Console.WriteLine("Deck Card by using Queue is Runnig.....");
                    DeckOfCard.DeckOfCardMain card = new DeckOfCard.DeckOfCardMain();
                    card.Play();
                    Console.WriteLine("Thank You For Using...");
                    break;
                case 8:
                    Console.WriteLine("Adress Book Process is  Running....");
                    AddressBookModel.AddressBookMain address = new AddressBookModel.AddressBookMain();
                    address.Operation();
                    Console.WriteLine("Thank You For Using...");
                    break;
                    //CommercialDataLinkedList.UserIntraction user = new CommercialDataLinkedList.UserIntraction();
                    //user.UserChoice();
                    //DeckOfCard.DeckOfCardMain card = new DeckOfCard.DeckOfCardMain();
                    //card.Play();
            }
        }
    }
}