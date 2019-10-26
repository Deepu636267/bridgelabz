

namespace EmployementManagementSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class EmployeeModel
    {
        private int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string EmpPassword { get; set; }
        public string Address { get; set; }
    }
}
