using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployementManagementSystem.Manager;
using EmployementManagementSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployementManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
            //EmployeeRepository employeeRepository = new EmployeeRepository();

            private readonly IEmployeeManager _employeeManager;

            public EmployeeController(IEmployeeManager employeeManager)
            {
                _employeeManager = employeeManager;
            }
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