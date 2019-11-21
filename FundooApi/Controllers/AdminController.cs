﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AdminController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessManager.Interfaces;
    using Common.Models.AdminModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// AdminController is class for taking request from browser to controll all admin related api
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager _admin; 
        public AdminController(IAdminManager admin)
        {
            _admin = admin;
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
                if (result != null)
                    return Ok(new { result });
                else
                    return BadRequest("LoginCredential Wrong");
            }catch(Exception ex)
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
                if (result != null)
                    return Ok(new { result });
                else
                    return BadRequest("error");
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
        public async Task<IActionResult> Details()
        {

            try
            {
                var result = await _admin.Details();
                if (result != null)
                    return Ok(new { result });
                else
                    return BadRequest("error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                if (result != null)
                    return Ok(new { result });
                else
                    return BadRequest("error");
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
        [Route("Count")]
        public async Task<IActionResult> UpdateAdminDetails(AdminModel model)
        {

            try
            {
                var result = await _admin.UpdateAdminDetails(model);
                if (result != null)
                    return Ok(new { result });
                else
                    return BadRequest("error");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}