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
        /// <summary>
        /// NotesRepository is constructor for initailizing
        /// </summary>
        /// <param name="context"></param>
        public NotesRepository(UserContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create is method for add the data in our notes table  with Jwt Authentication 
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="email"></param>
        /// <returns></returns>
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
        /// <summary>
        /// RetrieveById is method which has retrieving the data of particular Id  with Jwt Authentication 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<List<NotesModel>> RetrieveById(int Id,string email)
        {
            var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if(result!=null)
            {
                if(result.Email.Equals(email))
                {
                    return Task.Run(() => _context.Notes.Where(p => p.Id == Id).ToList());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Delete is method for deleting the particular id  with Jwt Authentication 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task Delete(int ID, string Email)
        {
            var result = _context.Notes.Where(j => j.Id == ID).FirstOrDefault();
            if (result.Email.Equals(Email))
            {

                if (result != null)
                {
                    _context.Notes.Remove(result);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Update is a method which has updated the data by its particular Id with Jwt Authentication 
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task Update(NotesModel notes, string Email)
        {
            var result = _context.Notes.Where(j => j.Id == notes.Id).FirstOrDefault();
            if (result.Email.Equals(Email))
            {
                if (result != null)
                {
                    result.Title = notes.Title;
                    result.Description = notes.Description;
                    result.ModifiedDate = DateTime.Now;
                    _context.Notes.Update(result);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Show is a mthod which shows all the related to login person  with Jwt Authentication 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task<List<NotesModel>> Show(string Email)
        {
            bool note = _context.Notes.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Notes.Where(p => p.Email == Email).ToList());
            }
            else
            {
                return null;
            }
        }
    }
}