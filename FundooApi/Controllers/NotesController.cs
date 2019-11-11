// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesController.cs" company="Bridgelabz">
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
    using Common.Models.NotesModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// NotesController is class which controls all the api
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager _manager;
        public NotesController(INotesManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Creates the specified notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Create(NotesModel notes)
        {
            string email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.Create(notes, email);
                if(result!=null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }

            }catch(Exception ex)
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
        [Route("Delete")]
        public async Task<IActionResult> Delete(int ID)
        {
            string Email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.Del(ID, Email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Updates the specified note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(NotesModel note)
        {
            string Email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.Update(note, Email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
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
        [Route("Show")]
        public async Task<IActionResult> Show()
        {
            string Email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.Show(Email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retrieves the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowById")]
        public async Task<IActionResult> RetrieveById(int Id)
        {
            string Email = User.Claims.First(c => c.Type == "Email").Value;
            try
            {
                var result = await _manager.RetrieveById(Id,Email);
                if (result != null)
                {
                    return Ok(new { result });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}