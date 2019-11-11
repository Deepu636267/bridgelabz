// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ILabelRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using Common.Models.LabelsModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// ILabelRepository is an inteface which has all method related to label crud operation
    /// </summary>
    public interface ILabelRepository
    {
        Task Create(LabelModel model, string email);
        Task Delete(int ID, string Email);
        Task<List<LabelModel>> Show(string Email);
        Task Update(LabelModel model, string Email);
    }
}