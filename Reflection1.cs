// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Program.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace DesignPattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    /// <summary>
    /// Reflection is a class Which reflect the all class Property Name, Method name uses in Algorithm Prpoject
    /// </summary>
    class Reflection1
    {
        /// <summary>
        /// Gets the reflection.
        /// </summary>
        public void GetReflection()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\Algorithm\bin\Debug\netcoreapp3.0\Algorithm.dll";
            ////read the file path and load into the assembly type          
            Assembly assembly = Assembly.LoadFile(path);
            ////Getting Alll types Whatever we use as class name in that project array type
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Class:" + type.Name);
                ////Getting all method name in same class
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("Methods: " + method.Name);
                    ////Getting all parameter name in same class
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var param in parameters)
                    {
                        Console.WriteLine("Parameter: " + param.Name);
                        Console.WriteLine("Type of Parameter: " + param.ParameterType);
                    }
                }
            }
        }
    }
}