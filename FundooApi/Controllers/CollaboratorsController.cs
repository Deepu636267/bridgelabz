// --------------------------------------------------------------------------------------------------------------------
// <copyright file=CollaboratorsController.cs" company="Bridgelabz">
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
    using Common.Models.CollaboratorsModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// CollaboratorsController is controller which handle all the http request and connect with particular 
    /// business logic
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorsManager _manager;
        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorsController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public CollaboratorsController(ICollaboratorsManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Adds the collaborators.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCollaborators(CollaboratorsModel collaborators)
        {
            string email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.AddCollaboraotors(collaborators, email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest("Error");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Removes the collaborators.
        /// </summary>
        /// <param name="collaborators">The collaborators.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Remove")]
        public async Task<IActionResult> RemoveCollaborators(CollaboratorsModel collaborators)
        {
            string email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.RemoveCollaboraotors(collaborators, email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest("Error");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}