using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployementManagementSystem.Model;

namespace EmployementManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        bool Create(string EmpName, string Designation, string Gender, string Email, string EmpPassword, string Address);
        //List<EmployeeModel> Retrieve();
        //bool Update(EmployeeModel employee);
        //bool Delete(int Id);

    }
}
