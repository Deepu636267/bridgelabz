// --------------------------------------------------------------------------------------------------------------------
// <copyright file=EmployeeController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployementManagementSystem.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployementManagementSystem.Manager;
    using EmployementManagementSystem.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    //[Route("api/[controller]")]
    //[ApiController]    
    /// <summary>
    /// EmployeeController is class which taking request from browser and send to the Manager
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class EmployeeController : ControllerBase
    {
            //EmployeeRepository employeeRepository = new EmployeeRepository();

        private readonly IEmployeeManager _employeeManager;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeManager">The employee manager.</param>
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        /// <summary>
        /// Creates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public IActionResult Create(EmployeeModel employee)
        {
            try
            {
               var result = _employeeManager.Add(employee.EmpName, employee.Designation, employee.Gender, employee.Email, employee.EmpPassword, employee.Address);
               return Ok(new { result });
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public IActionResult Update(EmployeeModel employee)
        {
            try
            {
                var result = _employeeManager.Edit(employee);
                return Ok(new { result });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Actions the delete.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public IActionResult ActionDelete(EmployeeModel employee)
        {
            try
            {
                var result = _employeeManager.Delete(employee);
                return Ok(new { result });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retrieves this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Show")]
        public IActionResult Retrieve()
        {
            try
            {
                var result = _employeeManager.Show();
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Indexes the specified login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Index(EmployeeModel login)
        {
            try
            {
                var result = _employeeManager.Login(login);
                return Ok(new { result });
               
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}