using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployementManagementSystem.Manager
{
    public interface IEmployeeManager
    {
        string Add(string EmployeeName, string Designation, string Gender, string Email, string EmpPassword, string Address);
    }
}
