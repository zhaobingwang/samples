using Sample.Infrastructure.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sample.Infrastructure.Tests.Cache.Redis
{
    [Trait("缓存", "Redis")]
    [TestCaseOrderer("Sample.Infrastructure.Tests.PriorityOrderer", "Sample.Infrastructure.Tests")]
    public class RedisManagerTest
    {
        public const string stringKey = "test.str";
        public const string hashKey = "test.hash";
        public const string listKey = "test.list";

        RedisManager redisManager;
        public RedisManagerTest()
        {
            redisManager = new RedisManager(dbIndex: 0);
        }

        #region string
        [TestPriority((int)CRUDPriority.Create)]
        [Fact(DisplayName = "字符串-写入-成功")]
        public async Task SetStringSuccess()
        {
            var result = await redisManager.SetStringAsync(stringKey, "1", TimeSpan.FromSeconds(60));
            Assert.True(result);
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "字符串-读取-成功")]
        public async Task GetStringSuccess()
        {
            var result = await redisManager.GetStringAsync(stringKey);
            Assert.True(result == "1");
        }
        #endregion

        #region hash
        [TestPriority((int)CRUDPriority.Create)]
        [Fact(DisplayName = "哈希-写入-单条-成功")]
        public async Task SetHashSingleDataSuccess()
        {
            await redisManager.SetHashAsync(hashKey, "Z", "26");
        }

        [TestPriority((int)CRUDPriority.Create)]
        [Fact(DisplayName = "哈希-写入-批量-成功")]
        public async Task SetHashMultipleDataSuccess()
        {
            var dict = GetFakeDictDatas();
            await redisManager.SetHashAsync(hashKey, dict);
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "哈希-读取-单条-成功")]
        public async Task GetHashByFieldAsyncSuccess()
        {
            var result = await redisManager.GetHashAsync(hashKey, "A");
            Assert.NotNull(result);
            Assert.True(result == "1");
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "哈希-读取-单条-失败")]
        public async Task GetHashByFieldAsyncFailed()
        {
            var result = await redisManager.GetHashAsync(hashKey, "NOKEY");
            Assert.Null(result);
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "哈希-读取-多条-成功")]
        public async Task GetHashByFieldsAsyncSuccess()
        {
            string[] fields = new string[] { "A", "B" };
            var result = await redisManager.GetHashAsync(hashKey, fields);

            Assert.True(result.Length == 2);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.True(result[0] == "1");
            Assert.True(result[1] == "2");
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "哈希-读取-多条-失败")]
        public async Task GetHashByFieldsAsyncFailed()
        {
            string[] fields = new string[] { "NOKEY1", "NOKEY2" };
            var result = await redisManager.GetHashAsync(hashKey, fields);

            Assert.True(result.Length == 2);
            Assert.Null(result[0]);
            Assert.Null(result[1]);
        }

        [TestPriority((int)CRUDPriority.Retrieve)]
        [Fact(DisplayName = "哈希-读取-所有")]
        public async Task GetAllHashAsyncSuccess()
        {
            var result = await redisManager.GetAllHashAsync(hashKey);
            Assert.True(result.Count > 0);
        }

        [TestPriority((int)CRUDPriority.Delete)]
        [Fact(DisplayName = "哈希-删除-单条")]
        public async Task DeleteSingleHashAsyncSuccess()
        {
            var result = await redisManager.DeleteHashAsync(hashKey, "Z");
            Assert.True(result);
        }

        [TestPriority((int)CRUDPriority.Delete)]
        [Fact(DisplayName = "哈希-删除-多条")]
        public async Task DeleteMultipleHashAsync()
        {
            var dict = GetFakeDictDatas();
            string[] hashFields = new string[dict.Count];
            int index = 0;
            foreach (var item in dict)
            {
                hashFields[index] = item.Key;
                index++;
            }

            await redisManager.DeleteHashAsync(hashKey, hashFields);
        }
        #endregion

        #region list
        [TestPriority((int)CRUDPriority.Create)]
        [Fact(DisplayName = "列表-写入-单条-成功")]
        public async Task SetListRightPushSingleSuccess()
        {
            var result = await redisManager.SetListRightPushAsync(listKey, "A");
            Assert.True(result > 0);
        }

        [TestPriority((int)CRUDPriority.Create)]
        [Fact(DisplayName = "列表-批量-多条-成功")]
        public async Task SetListRightPushMultipleSuccess()
        {
            string[] values = new string[] { "B", "C", "D" };
            var result = await redisManager.SetListRightPushAsync(listKey, values);
            Assert.True(result > 0);
        }

        [TestPriority((int)CRUDPriority.Delete)]
        [Fact(DisplayName = "列表-删除-成功")]
        public async Task SetListDeleteSuccess()
        {
            var result = await redisManager.DeleteListAsync(listKey, "A");
            result = await redisManager.DeleteListAsync(listKey, "B");
            result = await redisManager.DeleteListAsync(listKey, "C");
            result = await redisManager.DeleteListAsync(listKey, "D");
            Assert.True(result > 0);
        }
        #endregion

        #region fake data
        private Dictionary<string, string> GetFakeDictDatas()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("A", "1");
            dict.Add("B", "2");
            dict.Add("C", "3");
            return dict;
        }
        #endregion
    }
}
