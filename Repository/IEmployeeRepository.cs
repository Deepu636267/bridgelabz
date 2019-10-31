// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IEmployeeRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployementManagementSystem.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployementManagementSystem.Model;
    /// <summary>
    /// IEmployeeRepository is an inteface which implements inthe Repository class and
    /// if Manager has conatct with Repositary then he contact through this inteface
    /// </summary>
    public interface IEmployeeRepository
    {
        bool Create(string EmpName, string Designation, string Gender, string Email, string EmpPassword, string Address);
        List<EmployeeModel> Retrieve();
        bool Update(EmployeeModel employee);
        bool Delete(EmployeeModel employee);
        bool M_Login(EmployeeModel login);
    }
}