// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Interfaces
{
    using Common.Models.LabelsModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// ILabelManager is an inteface class
    /// </summary>
    public interface ILabelManager
    {
        Task<string> Add(LabelModel model, string email);
        Task<string> Del(int ID, string Email);
        Task<List<LabelModel>> Show(string Email);
        Task<string> Update(LabelModel model, string Email);
    }
}