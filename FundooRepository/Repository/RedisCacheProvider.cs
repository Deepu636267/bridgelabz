// --------------------------------------------------------------------------------------------------------------------
// <copyright file=RedisCacheProvider.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using Common.Models.NotesModels;
    using FundooRepository.Intefaces;
    using Microsoft.Extensions.Options;
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// RedisCacheProvider is class for set and get remove the key and value from redis cache
    /// </summary>
    public class RedisCacheProvider : ICacheProvider
    {
        RedisEndpoint _endPoint;
        private readonly RedisSetting config;
        /// <summary>
        /// Initalize the objects
        /// </summary>
        /// <param name="_config"></param>
        public RedisCacheProvider(IOptions<RedisSetting> _config)
        {
            config = _config.Value;
            _endPoint = new RedisEndpoint(config.host, config.port);

        }
        /// <summary>
        /// Set the value in the redis cache by calling Set method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<T>(string key, T value)
        {
            this.SetR(key, value);
        }
        /// <summary>
        /// Set the the value in the provided key and time zone
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        public void SetR<T>(string key, T value)
        {
            using (RedisClient client = new RedisClient(_endPoint))
            {
                client.As<T>().SetValue(key, value);
            }
        }
        /// <summary>
        /// Get the value from the cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T result = default(T);

            using (RedisClient client = new RedisClient(_endPoint))
            {
                var wrapper = client.As<T>();

                result = wrapper.GetValue(key);
            }

            return result;
        }
        /// <summary>
        /// Remove the the particular key from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            bool removed = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                removed = client.Remove(key);
            }

            return removed;
        }
        /// <summary>
        /// IsInCache check a particular key thats are in used for cahce or not
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
    }
}