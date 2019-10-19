// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern
{
    using System;
    using System.Threading.Tasks;
    using System.Reflection;
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("1.Singleton" + "\n2.Factory" + "\n3.Prototype" + "\n4.Adatpter" + "\n5.Facade" + "\n6.Proxy" + "\n7.Template" + "\n8.Visitor" + "\n9.Mediator");
            Console.WriteLine("Enter your choice Which You Want to Test the Design patetrn");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    CreationalDesignPattern.SingletonMain singleton = new CreationalDesignPattern.SingletonMain();
                    singleton.TestSingleton();
                    break;
                case 2:
                    CreationalDesignPattern.FactoryPattern.ComputerClient client = new CreationalDesignPattern.FactoryPattern.ComputerClient();
                    client.test();
                    break;
                case 3:
                    CreationalDesignPattern.PrototypeDesign.Prototype prototype = new CreationalDesignPattern.PrototypeDesign.Prototype();
                    prototype.PrototypeMain();
                    break;
                case 4:
                    StructuralDesignPattern.AdapterDesign.AdapterPatternTest test = new StructuralDesignPattern.AdapterDesign.AdapterPatternTest();
                    Console.WriteLine("From Class Type...........");
                    Console.WriteLine();
                    test.testClassAdapter();
                    Console.WriteLine();
                    Console.WriteLine("From Object Model...........");
                    Console.WriteLine();
                    test.testObjectAdapter();
                    break;
                case 5:
                    StructuralDesignPattern.FacadeDesign.CarFacade carFacade = new StructuralDesignPattern.FacadeDesign.CarFacade();
                    carFacade.CreateCompleteCar();
                    break;
                case 6:
                    StructuralDesignPattern.ProxyDesign.ProxyClient proxy = new StructuralDesignPattern.ProxyDesign.ProxyClient();
                    Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());
                    break;
                case 7:
                    BehavioralDesignPattern.TemplateDesign.HousingClient housing = new BehavioralDesignPattern.TemplateDesign.HousingClient();
                    housing.ClientMain();
                    break;
                case 8:
                    BehavioralDesignPattern.VisitorDesign.ShoppingCartClient cartClient = new BehavioralDesignPattern.VisitorDesign.ShoppingCartClient();
                    cartClient.ClientMain();
                    break;
                case 9:
                    BehavioralDesignPattern.MediatorDesign.ChatClient client1 = new BehavioralDesignPattern.MediatorDesign.ChatClient();
                    client1.ChatStart();
                    break;
                case 10:
                    Reflection1 reflection = new Reflection1();
                    reflection.GetReflection();
                    break;
                case 11:
                    DependencyInversionPrinciple.IAutomobile automobile = new DependencyInversionPrinciple.Jeep();
                    //DependencyInversionPrinciple.IAutomobile automobile = new DependencyInversionPrinciple.SUV();
                    DependencyInversionPrinciple.AutomobileController automobileController = new DependencyInversionPrinciple.AutomobileController(automobile);
                    automobile.Ignition();
                    automobile.Stop();
                    break;
            }
            // School school = new School();
            //school.test();
            //My_Program.ChatClient client = new My_Program.ChatClient();
            //client.Test();
        }
    }
}