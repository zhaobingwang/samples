using Sample.Infrastructure.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Infrastructure.Tests.Cache.Redis
{
    [Trait("缓存", "Redis")]
    public class RedisManagerTest
    {
        public const string stringKey = "test.str";
        public const string hashKey = "test.hash";

        RedisManager redisManager;
        public RedisManagerTest()
        {
            redisManager = new RedisManager(dbIndex: 0);
        }

        [Fact(DisplayName = "写入字符串")]
        public async Task SetStringSuccess()
        {

            var result = await redisManager.SetString(stringKey, "1", TimeSpan.FromSeconds(60));
            Assert.True(result);
        }

        [Fact(DisplayName = "读取字符串")]
        public async Task GetStringSuccess()
        {
            var result = await redisManager.GetString(stringKey);
            Assert.True(result == "1");
        }

        [Fact(DisplayName = "写入哈希，单条")]
        public async Task SetHashSingleDataSuccess()
        {
            await redisManager.SetHashAsync(hashKey, "Z", "26");
        }

        [Fact(DisplayName = "写入哈希，批量")]
        public async Task SetHashBulkDataSuccess()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("A", "1");
            dic.Add("B", "2");
            dic.Add("C", "3");
            await redisManager.SetHashAsync(hashKey, dic);
        }

        [Fact(DisplayName = "获取所有哈希数据")]
        public async Task GetAllHashAsyncSuccess()
        {
            var result = await redisManager.GetAllHashAsync(hashKey);
            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "删除哈希数据")]
        public async Task DeleteHashAsyncSuccess()
        {
            await redisManager.DeleteHashAsync(hashKey, "Z");
        }
    }
}
