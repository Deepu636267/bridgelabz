// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LabelController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using BusinessManager.Interfaces;
    using Common.Models.LabelsModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// LabelController is class which handle all the api
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager manager;

        public LabelController(ILabelManager emanager)
        {
            manager = emanager;
        }
        /// <summary>
        /// Creates the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddLabel")]
        public async Task<IActionResult> Create(LabelModel label)
        {
            try
            {
                string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                var result = await manager.Add(label,email);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Updates the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("LabelUpdate")]
        public async Task<IActionResult> Update(string label,int id)
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await manager.Update(label,id,Email);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("LabelDelete")]
        public async Task<IActionResult> Delete(string label)
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await manager.Del(label, Email);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        /// <summary>
        /// Shows this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LabelShow")]
        public async Task<IActionResult> Show()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await manager.Show(Email);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}