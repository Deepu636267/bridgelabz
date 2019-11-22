// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AdminController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApi.Controllers
{
    using BusinessManager.Interfaces;
    using Common.Models.AdminModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Resources;
    using System.Threading.Tasks;

    /// <summary>
    /// AdminController is class for taking request from browser to controll all admin related api
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager _admin;
        private readonly ILogger _logger;
        //private readonly ResourceManager _resourceManager;
        public AdminController(IAdminManager admin, ILogger<AdminController> logger)//,ResourceManager resourceManager)
        {
            _admin = admin;
            _logger = logger;
          //  _resourceManager = resourceManager;
        }

        /// <summary>
        /// Adds the new admin details.
        /// </summary>
        /// <param name="admin">The admin.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewAdminDetails(AdminModel admin)
        {

            try
            {
                var result = await _admin.AddAdminDetails(admin);
                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                if (result != null)
                {
                    _logger.LogInformation("{methodName} request for {message}", nameof(AddNewAdminDetails), resourceManager);
                    return Ok(new { result });
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} not Match", nameof(AddNewAdminDetails), resourceManager);
                    return BadRequest("error");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        /// <summary>
        /// Admins the login.
        /// </summary>
        /// <param name="admin">The admin.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> AdminLogin(AdminLoginModel admin)
        {

            try
            {     
                var result = await _admin.AdminLogin(admin);
                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                if (result != null)
                {
                    _logger.LogInformation("{methodName} request for {message}", nameof(AdminLogin), resourceManager);
                    return Ok(new { result });
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} not Match", nameof(AdminLogin), resourceManager);
                    return BadRequest("error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Detailses this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        [Route("List")]
        public async Task<List<AdminUserDetailsModel>> Details()
        {
            
            try
            {
                var result = await _admin.Details();

                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                //_logger.LogInformation(BuildLogInfo(nameof(Get), "LoggingGetCustomers"));
                if (result != null)
                {
                    //var resourceManager = new ResourceManager(typeof(A.Properties.Resource));

                    _logger.LogInformation("{methodName} request for {message}", nameof(Details), resourceManager);
                    return result;
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} not found", nameof(Details), resourceManager);
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///Count the no of user login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Count")]
        public async Task<IActionResult> Count()
        {

            try
            {
                var result = await _admin.Count();
                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                if (result != null)
                {
                    _logger.LogInformation("{methodName} request for {message}", nameof(Count), resourceManager);
                    return Ok(new { result });
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} no data found", nameof(Count), resourceManager);
                    return BadRequest("error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates the admin details by using Procedure and CURSOR.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAdminDetails(AdminModel model)
        {

            try
            {
                var result = await _admin.UpdateAdminDetails(model);
                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                if (result != null)
                {
                    _logger.LogInformation("{methodName} request for {message}", nameof(UpdateAdminDetails), resourceManager);
                    return Ok(new { result });
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} not updated", nameof(UpdateAdminDetails), resourceManager);
                    return BadRequest("error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adds the new column with batches in TSql For test.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("NewColumn")]
        public async Task<IActionResult> AddNewColumn()
        {

            try
            {
                var result = await _admin.AddNewColoumn();
                var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
                if (result != null)
                {
                    _logger.LogInformation("{methodName} request for {message}", nameof(AddNewColumn), resourceManager);
                    return Ok(new { result });
                }
                else
                {
                    _logger.LogError("{methodName} request for {message} not updated", nameof(AddNewColumn), resourceManager);
                    return BadRequest("error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}