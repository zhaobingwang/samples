using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Cache.Redis
{
    public partial class RedisManager
    {
        #region string
        public async Task<bool> SetString(string key, string value, TimeSpan? expiry = null)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.StringSetAsync(key, value, expiry);
        }
        public async Task<string> GetString(string key)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.StringGetAsync(key);
        }
        #endregion

        #region hash
        public async Task<Dictionary<string, string>> GetAllHashAsync(string key)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            var result = await db.HashGetAllAsync(key);
            return ConvertHashEntry2Dictionary(result);
        }
        public async Task SetHashAsync(string key, string hashField, string value)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            IDatabase db = redis.GetDatabase(_dbIndex);
            await db.HashSetAsync(key, hashField, value);
        }
        public async Task SetHashAsync(string key, Dictionary<string, string> dictionary)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            IDatabase db = redis.GetDatabase(_dbIndex);
            await db.HashSetAsync(key, ConvertDictionary2HashEntry(dictionary));
        }
        private HashEntry[] ConvertDictionary2HashEntry(Dictionary<string, string> dictionary)
        {
            var fields = dictionary.Select(
                pair => new HashEntry(pair.Key, pair.Value)).ToArray();
            return fields;
        }
        private Dictionary<string, string> ConvertHashEntry2Dictionary(HashEntry[] fields)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (var item in fields)
            {
                dictionary.Add(item.Name, item.Value);
            }
            return dictionary;
        }
        #endregion
    }
}
