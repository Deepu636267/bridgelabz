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
        public async Task<string> Create(NotesModel notes, string email, string key)
        {
            await repository.Create(notes, email, key);
            return "Added Succesfully";
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Del(int ID, string Email, string key)
        {
            await repository.Delete(ID, Email, key);
            return "Deleted Successfully";
        }
        /// <summary>
        /// Shows the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> Show(string Email, string key)
        {
            
            var result = await repository.Show(Email, key);
            return result;

        }
        /// <summary>
        /// Retrieves the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<NotesModel> RetrieveById(int Id, string email, string key)
        {
            var result = await repository.RetrieveById(Id, email, key);
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
        public async Task<string> Update(NotesModel note, string Email, string key)
        {
             await repository.Update(note, Email, key);
              return "Updated Successfully";
          
        }
        /// <summary>
        /// Archives the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Archive(int Id, string email, string key)
        {
            var result = await repository.Archive(Id, email, key);
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
        public async Task<string> UnArchive(int Id, string email, string key)
        {
            var result= await repository.UnArchive(Id, email, key);
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
        public async Task<string> Pin(int Id, string email, string key)
        {
            var result = await repository.Pin(Id, email, key);
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
        public async Task<string> UnPin(int Id, string email, string key)
        {
            var result = await repository.UnPin(Id, email, key);
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
        public async Task<string> Trash(int Id, string email, string key)
        {
            var result = await repository.Trash(Id, email, key);
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
        public async Task<string> RestoreById(int Id, string email, string key)
        {
            var result = await repository.RestoreById(Id, email, key);
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
                return "ImageUpload Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Reminders the specified note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> Reminder(NotesModel note, string email)
        { 
            var result = await repository.Reminder(note,email);
            if (result == true)
            {
                return "Reminder Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> RemoveReminder(NotesModel note, string email)
        {
            var result = await repository.RemoveReminder(note, email);
            if (result == true)
            {
                return "Reminder Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Restores all from trash.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> RestoreAllFromTrash(string email)
        {
            var result = await repository.RestoreAllFromTrash(email);
            if (result == true)
            {
                return "Restore Succesfully";
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> SetColor(NotesModel model, string email)
        {
             await repository.SetColor(model,email);
             return "ColorSet Succesfully";
            
        }
        /// <summary>
        /// Gets the list from trash.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> GetListFromTrash(string Email)
        {

            var result = await repository.GetListFromTrash(Email);
            return result;

        }
        /// <summary>
        /// Gets the list from archive.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> GetListFromArchive(string Email)
        {

            var result = await repository.GetListFromArchive(Email);
            return result;

        }
        /// <summary>
        /// Gets the list from reminder.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> GetListFromReminder(string Email)
        {

            var result = await repository.GetListFromReminder(Email);
            return result;

        }
        /// <summary>
        /// Gets the list from pin.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> GetListFromPin(string Email)
        {

            var result = await repository.GetListFromPin(Email);
            return result;

        }
        /// <summary>
        /// Drags the and drop.
        /// </summary>
        /// <param name="drag">The drag.</param>
        /// <param name="drop">The drop.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<string> DragAndDrop(int drag, int drop, string email)
        {
            await repository.DragAndDrop(drag,drop,email);
            return "DragDrop Succesfully";

        }
        /// <summary>
        /// Searches the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<List<NotesModel>> Search(string searchString, string email)
        {
            var result=await repository.Search(searchString, email);
            return result;
        }

        /// <summary>
        /// Restores the selected from trash.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<string> RestoreSelected(string Email, NotesModel[] id, string key)
        {
            var result = await repository.RestoreSelected(Email,id,key);
            if (result == true)
            {
                return "Restore Succesfully";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Trashes the selected.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<string> TrashSelected(string Email, NotesModel[] id, string key)
        {
            var result = await repository.TrashSelected(Email, id, key);
            if (result == true)
            {
                return "Restore Succesfully";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Deletes the selected.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<string> DeleteSelected(string Email, NotesModel[] id, string key)
        {
            var result = await repository.DeleteSelected(Email, id, key);
            if (result == true)
            {
                return "Restore Succesfully";
            }
            else
            {
                return null;
            }
        }
    }
}