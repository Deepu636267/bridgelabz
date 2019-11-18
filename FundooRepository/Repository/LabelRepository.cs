// --------------------------------------------------------------------------------------------------------------------
// <copyright file=LabelRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.LabelsModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class LabelRepository:ILabelRepository
    {
        private readonly UserContext _context;
        public LabelRepository(UserContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates the specified model with Jwt Authentication . 
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Create(LabelModel model, string email)
        {
            model.Email = email;
            var note = new LabelModel()
            {
                Email = model.Email,
                Label = model.Label
            };
             _context.Labels.Add(note);
            return Task.Run(() => _context.SaveChanges());
        }
        /// <summary>
        /// Deletes the specified identifier with Jwt Authentication .
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Delete(int ID, string Email)
        {
            var result = _context.Labels.Where(j => j.ID == ID).FirstOrDefault();
            if (result != null)
            {
                if (result.Email.Equals(Email))
                {
                    _context.Labels.Remove(result);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Shows the specified email with Jwt Authentication .
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<LabelModel>> Show(string Email)
        {
            bool note = _context.Labels.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Labels.Where(p => p.Email == Email).ToList());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Updates the specified model with Jwt Authentication .
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task Update(LabelModel model, string Email)
        {
            var result = _context.Labels.Where(j => j.ID == model.ID).FirstOrDefault();
            if (result != null)
            {
                if (result.Email.Equals(Email))
                {
                    result.Label = model.Label;
                    _context.Labels.Update(result);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
    }
}