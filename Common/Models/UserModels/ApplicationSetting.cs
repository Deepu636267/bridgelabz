// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ApplicationSetting.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace Common.Models.UserModels
{
    /// <summary>
    /// ApplicationSetting is a class for setting the secreat key for jwt token authentication
    /// </summary>
    public class ApplicationSetting
    {
        public string JWT_Secret { get; set; }
    }
}
