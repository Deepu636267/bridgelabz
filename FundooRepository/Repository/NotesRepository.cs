// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.NotesModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// NotesRepository is a class which inherited the INotesRepository
    /// </summary>
    public class NotesRepository:INotesRepository
    {
        private readonly UserContext _context;
        public NotesRepository(UserContext context)
        {
            _context = context;
        }

        public Task Create(NotesModel notes,string email)
        {
            notes.Email = email;
            var note = new NotesModel()
            {
                Email=notes.Email,
                Title=notes.Title,
                Description=notes.Description,
                CreatedDate=DateTime.Now
            };
             _context.Notes.Add(note);
            return Task.Run(() => _context.SaveChanges());
        }

        public Task Retrieve(int Id,string email)
        {
            var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if(result!=null)
            {
                if(result.Email.Equals(email))
                {

                }
            }

            throw new NotImplementedException();
        }
    }
}
