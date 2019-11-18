﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using Common.Models.NotesModels;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// INotesRepository is an inteface
    /// </summary>
    public interface INotesRepository
    {
        Task Create(NotesModel notes, string email);
        Task<NotesModel> RetrieveById(int Id, string email);
        Task Delete(int ID, string Email);
        Task Update(NotesModel notes, string Email);
        Task<List<NotesModel>> Show(string Email);
        Task<bool> Archive(int Id, string email);
        Task<bool> UnArchive(int Id, string email);
        Task<bool> Pin(int Id, string email);
        Task<bool> UnPin(int Id, string email);
        Task<bool> Trash(int Id, string email);
        Task<bool> RestoreById(int Id, string email);
        Task<bool> DeleteAll(string email);
        Task<bool> ImageUpload(int Id, IFormFile file, string email);
        Task<bool> Reminder(NotesModel note, string email);
        Task<bool> RemoveReminder(NotesModel note, string email);
        Task<bool> RestoreAllFromTrash(string email);
        Task SetColor(NotesModel model, string email);
        Task<List<NotesModel>> GetListFromTrash(string Email);
        Task<List<NotesModel>> GetListFromArchive(string Email);
        Task<List<NotesModel>> GetListFromReminder(string Email);
        Task<List<NotesModel>> GetListFromPin(string Email);
        Task DragAndDrop(int drag, int drop, string email);
        Task<List<NotesModel>> Search(string searchString, string email);
    }
}