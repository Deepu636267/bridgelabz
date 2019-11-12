﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file=INotesRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using Common.Models.NotesModels;
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
        Task<List<NotesModel>> RetrieveById(int Id, string email);
        Task Delete(int ID, string Email);
        Task Update(NotesModel notes, string Email);
        Task<List<NotesModel>> Show(string Email);
        Task<bool> Archive(int Id, string email);
        Task<bool> UnArchive(int Id, string email);
        Task<bool> Pin(int Id, string email);
        Task<bool> UnPin(int Id, string email);
        Task<bool> Trash(int Id, string email);
        Task<bool> RestoreById(int Id, string email);
        

    }
}
