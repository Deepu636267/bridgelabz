// --------------------------------------------------------------------------------------------------------------------
// <copyright file=EmployeeManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployementManagementSystem.Manager
{
    using EmployementManagementSystem.Model;
    using EmployementManagementSystem.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// EmployeeManager is a class which manage all the operation in EMployeeManagement System
    /// </summary>
    /// <seealso cref="EmployementManagementSystem.Manager.IEmployeeManager" />
    public class EmployeeManager :IEmployeeManager
    {
        Model.EmployeeModel emp = new Model.EmployeeModel();
        private readonly IEmployeeRepository _employeeRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager"/> class.
        /// </summary>
        public EmployeeManager()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManager" /> class.
        /// </summary>
        /// <param name="employeeRepository">The employee repository.</param>
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Adds the specified employee name.
        /// </summary>
        /// <param name="EmployeeName">Name of the employee.</param>
        /// <param name="Designation">The designation.</param>
        /// <param name="Gender">The gender.</param>
        /// <param name="Email">The email.</param>
        /// <param name="EmpPassword">The emp password.</param>
        /// <param name="Address">The address.</param>
        /// <returns></returns>
        public string Add(string EmployeeName, string Designation,string Gender,string Email,string EmpPassword ,string Address)
        {
            // emp.ID = ID;
            emp.EmpName = EmployeeName;
            emp.Designation = Designation;
            emp.Gender = Gender;
            emp.Email = Email;
            emp.EmpPassword = EmpPassword;
            emp.Address = Address;
            _employeeRepository.Create(emp.EmpName,emp.Designation,emp.Gender,emp.Email,emp.EmpPassword,emp.Address);
            return "Added Successfully";
        }
        /// <summary>
        /// Edits the specified empl.
        /// </summary>
        /// <param name="empl">The empl.</param>
        /// <returns></returns>
        public string Edit(EmployeeModel empl)
        {
           var result= _employeeRepository.Update(empl);
           if(result==true)
              return "Updated Succesfully";
           else
            {
                return null;
            }
        }
        /// <summary>
        /// Deletes the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public string Delete(EmployeeModel employee)
        {
            var result=_employeeRepository.Delete(employee);
            if (result == true)
                return "Data Deleted Succesfully";
            else
                return null;
        }
        /// <summary>
        /// Shows this instance.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> Show()
        {
            return _employeeRepository.Retrieve();
          
        }
        /// <summary>
        /// Logins the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        public string Login(EmployeeModel login)
        {

            var result=_employeeRepository.M_Login(login);
            if(result==true)
            {
                return "Login suceesfully";
            }
            else
            {
                return null;
            }
        }
    }
}