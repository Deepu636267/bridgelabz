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
    }
}