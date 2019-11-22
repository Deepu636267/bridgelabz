// --------------------------------------------------------------------------------------------------------------------
// <copyright file=ICacheProvider.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Intefaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// ICacheProvider is a class where we have define the all the techniques of cache operation 
    /// </summary>
    public interface ICacheProvider
    {
        void Set<T>(string key, T value);

        void SetR<T>(string key, T value);

        T Get<T>(string key);

        bool Remove(string key);

        bool IsInCache(string key);
    }
}
