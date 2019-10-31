// --------------------------------------------------------------------------------------------------------------------
// <copyright file=EmployeeModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployementManagementSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// EmployeeModel is a class which the basic strcture of our project
    /// </summary>
    public class EmployeeModel
    {
        [Key]      
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Emp name is required.")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is required.")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "EmpPassword is required.")]
        public string EmpPassword { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}