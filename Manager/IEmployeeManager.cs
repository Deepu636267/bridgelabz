// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IEmployeeManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployementManagementSystem.Manager
{
    using EmployementManagementSystem.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// IEmployeeManager is an interface which implementation in Manger class and controller can contact manager
    /// through this interface
    /// </summary>
    public interface IEmployeeManager
    {
        string Add(string EmployeeName, string Designation, string Gender, string Email, string EmpPassword, string Address);
        string Edit(EmployeeModel empl);
        string Delete(EmployeeModel employee);
        List<EmployeeModel> Show();
        string Login(EmployeeModel login);
    }
}