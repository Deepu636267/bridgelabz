// --------------------------------------------------------------------------------------------------------------------
// <copyright file=IService1.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace EmployeeManagement
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    /// <summary>
    /// IService1 is an interface which has Operation contract are there
    /// </summary>
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Employee> GetEmployee();
        [OperationContract]
        bool AddEmployee(Employee employee);
        [OperationContract]
        bool Update(Employee employee);
        [OperationContract]
        bool Delete(Employee employee);
        [OperationContract]
        bool M_Login(Employee login);

        // TODO: Add your service operations here
    }
    /// <summary>
    /// Employee is a model class
    /// </summary>
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        private int _id;
        private string _name;
        private string _gender;
        private string _address;
        private string password;
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [DataMember]
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}