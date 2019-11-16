// --------------------------------------------------------------------------------------------------------------------
// <copyright file=INotesManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interfaces
{
    using Common.Models.NotesModels;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// INotesManager is an inteface 
    /// </summary>
    public interface INotesManager
    {
        Task<string> Create(NotesModel notes, string email);
        Task<string> Del(int ID, string Email);
        Task<List<NotesModel>> Show(string Email);
        Task<string> Update(NotesModel note, string Email);
        Task<List<NotesModel>> RetrieveById(int Id, string email);
        Task<string> Archive(int Id, string email);
        Task<string> UnArchive(int Id, string email);
        Task<string> Pin(int Id, string email);
        Task<string> UnPin(int Id, string email);
        Task<string> Trash(int Id, string email);
        Task<string> RestoreById(int Id, string email);
        Task<string> RestoreAllFromTrash(string email);
        Task<string> DeleteAll(string email);
        Task<string> ImageUpload(int Id, IFormFile file, string email);
        Task<string> Reminder(NotesModel note, string email);
        Task<string> RemoveReminder(NotesModel note,string email);
        Task<string> SetColor(NotesModel model, string email);
        Task<List<NotesModel>> GetListFromTrash(string Email);
        Task<List<NotesModel>> GetListFromArchive(string Email);
        Task<List<NotesModel>> GetListFromReminder(string Email);
        Task<List<NotesModel>> GetListFromPin(string Email);
        Task<string> DragAndDrop(int drag, int drop, string email);
        Task<List<NotesModel>> Search(string searchString, string email);
    }
}