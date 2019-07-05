using Sample.Infrastructure.Extensions;
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
        public async Task<string> GetHashAsync(string key, string hashField)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            var result = await db.HashGetAsync(key, hashField);
            return result;
        }
        public async Task<string[]> GetHashAsync(string key, string[] hashFields)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            var result = await db.HashGetAsync(key, hashFields.ToRedisValueArray());
            return result.ToStringArray();
        }
        public async Task<Dictionary<string, string>> GetAllHashAsync(string key)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            var result = await db.HashGetAllAsync(key);
            return result.ToStringDictionary();
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
            await db.HashSetAsync(key, dictionary.ToHashEntry());
        }

        public async Task<bool> DeleteHashAsync(string key, string hashField)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            var result = await db.HashDeleteAsync(key, hashField);
            return result;
        }
        public async Task<long> DeleteHashAsync(string key, string[] hashFields)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.HashDeleteAsync(key, hashFields.ToRedisValueArray());
        }
        #endregion

        #region List
        /// <summary>
        /// 将指定值插入该key的列表中。如果该key不存在，在执行插入操作前，先为其创建空列表
        /// </summary>
        /// <param name="key">列表的键</param>
        /// <param name="value">要添加到列表尾部的值</param>
        /// <returns>在插入数据后列表的长度</returns>
        public async Task<long> SetListRightPushAsync(string key, string value)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.ListRightPushAsync(key, value);
        }

        /// <summary>
        /// 将指定值插入该key的列表中。如果该key不存在，在执行插入操作前，先为其创建空列表
        /// </summary>
        /// <param name="key">列表的键</param>
        /// <param name="values">要添加到列表尾部的值</param>
        /// <returns>在插入数据后列表的长度</returns>
        public async Task<long> SetListRightPushAsync(string key, string[] values)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.ListRightPushAsync(key, values.ToRedisValueArray());
        }

        /// <summary>
        /// 删除列表中值等于value的第一个值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="count">count > 0：删除等于从头到尾移动的值的元素;count < 0:删除等于从尾部到头部移动的值的元素; count = 0：全部删除</param>
        /// <returns>已删除元素的数量</returns>
        public async Task<long> DeleteListAsync(string key, string value, long count = 0)
        {
            IDatabase db = redis.GetDatabase(_dbIndex);
            return await db.ListRemoveAsync(key, value, count);
        }
        #endregion
    }
}
