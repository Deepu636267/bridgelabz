using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessManager.Interfaces;
using Common.Models.NotesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooApi.Controllers
{
    [Route("api/[controller]"),Authorize]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager _manager;
        public NotesController(INotesManager manager)
        {
            _manager = manager;
        }
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
    }
}