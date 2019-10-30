using EmployementManagementSystem.Model;
using EmployementManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployementManagementSystem.Manager
{
    public class EmployeeManager :IEmployeeManager
    {
        Model.EmployeeModel emp = new Model.EmployeeModel();
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager()
        {

        }
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
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
        public string Edit(EmployeeModel empl)
        {
            _employeeRepository.Update(empl);
            return "Updated Succesfully";
        }
        public string Delete(EmployeeModel employee)
        {
            _employeeRepository.Delete(employee);
            return "Data Deleted Succesfully";
        }
        public List<EmployeeModel> Show()
        {
            return _employeeRepository.Retrieve();
          
        }
        public string Login(EmployeeModel login)
        {
            var result=_employeeRepository.M_Login(login);
            if(result==true)
            {
                return "Login suceesfully";
            }
            else
            {
                return "Login Credential Not correct";
            }
            

        }
    }
}
