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
    using System.Linq;

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
            AdminUserStatisticModel admin = new AdminUserStatisticModel();
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

        /// <summary>
        /// AdminLogin is class 
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public Task<bool> AdminLogin(AdminLoginModel loginModel)
        {
            Connection();
            SqlCommand command = new SqlCommand("Login", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Email", loginModel.Email);
            command.Parameters.AddWithValue("@Password", loginModel.Password);
            con.Open();
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataSet);
            con.Close();
            bool loginSuccessful = ((dataSet.Tables.Count > 0) && (dataSet.Tables[0].Rows.Count > 0));
            if (loginSuccessful && loginModel.Email != "" && loginModel.Password != null)
            {
                return Task.Run(()=>true);
            }
            else
            {
                return Task.Run(()=>false);
            }
        }

        /// <summary>
        /// Details is a method for getting the details of user
        /// </summary>
        /// <returns></returns>
        public Task<List<AdminUserDetailsModel>> Details()
        {
            Connection();
            List<AdminUserDetailsModel> UserList = new List<AdminUserDetailsModel>();
            SqlCommand command = new SqlCommand("GetEmployees", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            UserList = (from DataRow dr in dt.Rows
                       select new AdminUserDetailsModel()
                       {
                           ID= Convert.ToInt32(dr["ID"]),
                           FirstName= Convert.ToString(dr["FirstName"]),
                           LastName= Convert.ToString(dr["LastName"]),
                           Email= Convert.ToString(dr["Email"]),
                           Service= Convert.ToString(dr["CardType"]),
                           TotalNotes= Convert.ToInt32(dr["TotalNotes"]),
                           Status= Convert.ToString(dr["Status"])
                       }).ToList();
            return Task.Run(()=> UserList);
        }

        /// <summary>
        /// Counts this Number Of user Login Through SqlServer Function.
        /// </summary>
        /// <returns></returns>
        public Task<string> Count()
        {
            Connection();
            SqlCommand command = new SqlCommand("Select dbo.Count()", con);
            command.CommandType = CommandType.Text;
            con.Open();
            string i = command.ExecuteScalar().ToString();
            con.Close();
            return Task.Run(() => i);
        }
    }
}