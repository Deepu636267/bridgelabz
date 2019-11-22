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
    using System.Security.Claims;
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
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.Create(notes, email,key);
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
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + Email;
            try
            {
                var result = await _manager.Del(ID, Email,key);
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

            string Email = User.Claims.First(c => c.Type ==ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + Email;
            try
            {
                var result = await _manager.Update(note, Email,key);
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
        public async Task<List<NotesModel>> Show()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + Email;
            try
            {
                var result = await _manager.Show(Email,key);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
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
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + Email;
            try
            {
                var result = await _manager.RetrieveById(Id,Email,key);
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
        /// Archives the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Archive")]
        public async Task<IActionResult> Archive(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.Archive(Id, email,key);
                if (result != null)
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
        /// Uns the archive.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UnArchive")]
        public async Task<IActionResult> UnArchive(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.UnArchive(Id, email,key);
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
        /// Pins the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Pin")]
        public async Task<IActionResult> Pin(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.Pin(Id, email,key);
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
        /// Uns the pin.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("UnPin")]
        public async Task<IActionResult> UnPin(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.UnPin(Id, email,key);
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
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Trash")]
        public async Task<IActionResult> Trash(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.Trash(Id, email,key);
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
        /// Uns the trash.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RestoreById")]
        public async Task<IActionResult> RestoreById(int Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.RestoreById(Id, email,key);
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
        /// Deletes all.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteAll")]
        public async Task<IActionResult> DeleteAll()
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.DeleteAll(email);
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
        /// Images the upload.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Image")]
        public async Task<IActionResult> ImageUpload(int Id, IFormFile file)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;

            try
            {
                var result = await _manager.ImageUpload(Id,file,email);
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
        /// Reminder is for to set the Reminder
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Reminder")]
        public async Task<IActionResult> Reminder(NotesModel note)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.Reminder(note,email);
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
        /// Removes the reminder.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RemoveReminder")]
        public async Task<IActionResult> RemoveReminder(NotesModel note)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.RemoveReminder(note, email);
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
        /// Restores all from trash.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RestoreAll")]
        public async Task<IActionResult> RestoreAllFromTrash()
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.RestoreAllFromTrash(email);
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
        /// SetColor for notes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SetColor")]
        public async Task<IActionResult> SetColor(NotesModel model)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.SetColor(model,email);
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
        /// Gets the list from trash.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TrashList")]
        public async Task<IActionResult> GetListFromTrash()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.GetListFromTrash(Email);
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
        /// Gets the list from archive.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ArchiveList")]
        public async Task<IActionResult> GetListFromArchive()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.GetListFromArchive(Email);
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
        /// Gets the list from reminder.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ReminderList")]
        public async Task<IActionResult> GetListFromReminder()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.GetListFromReminder(Email);
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
        /// Gets the list from pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PinList")]
        public async Task<IActionResult> GetListFromPin()
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.GetListFromPin(Email);
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
        /// Drags the and drop.
        /// </summary>
        /// <param name="drag">The drag.</param>
        /// <param name="drop">The drop.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Drag")]
        public async Task<IActionResult> DragAndDrop(int drag,int drop)
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.DragAndDrop(drag,drop,Email);
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
        /// Searches the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search(string searchString)
        {
            string Email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            try
            {
                var result = await _manager.Search(searchString, Email);
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
        /// Restores the selected from trash.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("RestoreSelected")]
        public async Task<IActionResult> RestoreSelected([FromBody]NotesModel[] id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.RestoreSelected(email, id, key);
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
        /// Trashes the selected.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("TrashSelected")]
        public async Task<IActionResult> TrashSelected([FromBody]NotesModel[] Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.TrashSelected(email, Id, key);
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
        /// Deletes the selected from trash.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteSelected")]
        public async Task<IActionResult> DeleteSelected([FromBody]NotesModel[] Id)
        {
            string email = User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.UserData).Value;
            var key = UserId + "_" + email;
            try
            {
                var result = await _manager.DeleteSelected(email, Id, key);
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