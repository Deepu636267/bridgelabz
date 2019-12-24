// --------------------------------------------------------------------------------------------------------------------
// <copyright file=Labelmanager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace BusinessManager.Managers
{
    using BusinessManager.Interfaces;
    using Common.Models.LabelsModels;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Labelmanager is a class which implemented the ILabelManager Inteface
    /// </summary>
    /// <seealso cref="BusinessManager.Interfaces.ILabelManager" />
    public class Labelmanager : ILabelManager
    {
        private readonly ILabelRepository label;
        public Labelmanager(ILabelRepository Ilabel)
        {
            label = Ilabel;
        }
        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Add(LabelModel model, string email)
        {
            await label.Create(model, email);
            return "Added Successfully";
        }
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Del(string Label, string Email)
        {
            await label.Delete(Label, Email);
            return "Deleted Successfully";
        }
        /// <summary>
        /// Shows the specified email.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<List<LabelModel>> Show(string Email)
        {
            var result = await label.Show(Email);
            return result;
        }
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public async Task<string> Update(string Label, int id, string Email)
        {
            await label.Update(Label, id,Email);
            return "Update Successfull";
        }
    }
}