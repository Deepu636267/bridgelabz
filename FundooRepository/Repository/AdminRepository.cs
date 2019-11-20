// --------------------------------------------------------------------------------------------------------------------
// <copyright file=AdminRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Repository
{
    using Common.Models.AdminModels;
    using Common.Models.UserModels;
    using FundooRepository.Intefaces;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// AdminRepository is class for all business logic for all admin api
    /// </summary>
    public class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration configuration;
        private SqlConnection con = null;
        private string constr = null;

        /// <summary>
        /// initialize 
        /// </summary>
        /// <param name="configurations"></param>
        public AdminRepository(IConfiguration configurations)
        {
            configuration = configurations;
        }

        /// <summary>
        /// connection is method to get connection with sql
        /// </summary>
        private void Connection()
        {
            try
            {
                constr = configuration.GetSection("ConnectionStrings").GetSection("UserDBConncetion").Value;
                this.con = new SqlConnection(constr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        /// <summary>
        /// AddAdminDetails is method for adding the admin details
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Task<bool> AddAdminDetails(AdminModel admin)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddNewAdminDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", admin.FirstName);
            com.Parameters.AddWithValue("@LastName", admin.LastName);
            com.Parameters.AddWithValue("@Email", admin.Email);
            com.Parameters.AddWithValue("@Password", admin.Password);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return Task.Run(()=>true);
            }
            else
            {
                return Task.Run(() => false);
            }
        }

        /// <summary>
        /// Adds the user details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public Task<bool> AddUserDetails(UserModel model, DateTime date)
        {
            AdminUserDetailsModel admin = new AdminUserDetailsModel();
            admin.UserEmail = model.Email;
            admin.Login_Date_Time = date;
            admin.Service = model.CardType;
            Connection();
            SqlCommand com = new SqlCommand("AddUserDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserEmail", admin.UserEmail);
            com.Parameters.AddWithValue("@LoginTime", admin.Login_Date_Time);
            com.Parameters.AddWithValue("@Service", admin.Service);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return Task.Run(() => true);
            }
            else
            {
                return Task.Run(() => false);
            }
        }
    }
}