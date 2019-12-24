﻿// --------------------------------------------------------------------------------------------------------------------
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
        Task<string> Create(NotesModel notes, string email,string key);
        Task<string> Del(NotesModel ID, string Email, string key);
        Task<List<NotesModelView>> Show(string Email, string key);
        Task<string> Update(NotesModel note, string Email, string key);
        Task<NotesModel> RetrieveById(int Id, string email, string key);
        Task<string> Archive(NotesModel notes, string email, string key);
        Task<string> UnArchive(int Id, string email, string key);
        Task<string> Pin(int Id, string email, string key);
        Task<string> UnPin(int Id, string email, string key);
        Task<string> Trash(NotesModel notes, string email, string key);
        Task<string> RestoreById(int Id, string email, string key);
        Task<string> RestoreAllFromTrash(string email);
        Task<string> DeleteAll(string email);
        Task<string> ImageUpload(int Id, IFormFile file, string email);
        Task<string> Reminder(NotesModel note, string email, string key);
        Task<string> RemoveReminder(NotesModel note,string email, string key);
        Task<string> SetColor(NotesModel model, string email, string key);
        Task<List<NotesModel>> GetListFromTrash(string Email);
        Task<List<NotesModel>> GetListFromArchive(string Email);
        Task<List<NotesModel>> GetListFromReminder(string Email);
        Task<List<NotesModel>> GetListFromPin(string Email);
        Task<string> DragAndDrop(int drag, int drop, string email);
        Task<List<NotesModel>> Search(string searchString, string email);
        Task<string> RestoreSelected(string Email, NotesModel[] id, string key);
        Task<string> TrashSelected(string Email, NotesModel[] id, string key);
        Task<string> DeleteSelected(string Email, NotesModel[] id, string key);
        Task<string> PushMessage();
        Task<string> RecieveMessage();

    }
}