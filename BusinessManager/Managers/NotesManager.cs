// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Managers
{
    using BusinessManager.Interfaces;
    using Common.Models.NotesModels;
    using FundooRepository.Intefaces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// NotesManager is a class which implemented the INotesManager inteface
    /// </summary>
    /// <seealso cref="BusinessManager.Interfaces.INotesManager" />
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository repository;
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class.
        /// </summary>
        /// <param name="_repository">The repository.</param>
        public NotesManager(INotesRepository _repository)
        {
            repository = _repository;
        }
        /// <summary>
        /// Creates the specified notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Create(NotesModel notes, string email)
        {
            await repository.Create(notes, email);
            return "Added Succesfully";
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Del(int ID, string Email)
        {
            await repository.Delete(ID, Email);
            return "Deleted Successfully";
        }
        /// <summary>
        /// Shows the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> Show(string Email)
        {

            var result = await repository.Show(Email);
            return result;

        }
        /// <summary>
        /// Retrieves the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> RetrieveById(int Id, string email)
        {
            var result = await repository.RetrieveById(Id, email);
            if(result!=null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Updates the specified note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Update(NotesModel note, string Email)
        {
             await repository.Update(note, Email);
              return "Updated Successfully";
          
        }
        /// <summary>
        /// Archives the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Archive(int Id, string email)
        {
            var result = await repository.Archive(Id, email);
            if(result==true)
            {
                return "Archieve Succesfully";
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Uns the archive.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> UnArchive(int Id, string email)
        {
            var result= await repository.UnArchive(Id, email);
            if (result == true)
            {
                return "UnArchieve Succesfully";
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Pins the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Pin(int Id, string email)
        {
            var result = await repository.Pin(Id, email);
            if (result == true)
            {
                return "Pin Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Uns the pin.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> UnPin(int Id, string email)
        {
            var result = await repository.UnPin(Id, email);
            if (result == true)
            {
                return "UnPin Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Trash(int Id, string email)
        {
            var result = await repository.Trash(Id, email);
            if (result == true)
            {
                return "Trash Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Uns the trash.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> RestoreById(int Id, string email)
        {
            var result = await repository.RestoreById(Id, email);
            if (result == true)
            {
                return "UnTrash Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> DeleteAll(string email)
        {
            var result = await repository.DeleteAll(email);
            if (result == true)
            {
                return "UnTrash Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Images the upload.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="file">The file.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> ImageUpload(int Id, IFormFile file, string email)
        {
            var result = await repository.ImageUpload(Id,file,email);
            if (result == true)
            {
                return "UnTrash Succesfully";
            }
            else
            {
                return null;
            }
        }
    }
}