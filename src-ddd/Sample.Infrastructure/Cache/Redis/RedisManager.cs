using StackExchange.Redis;
using System;

namespace Sample.Infrastructure.Cache.Redis
{
    public partial class RedisManager
    {
        private readonly ConnectionMultiplexer redis;
        private int _dbIndex = -1;
        public RedisManager(string redisUri = "127.0.0.1:6379", int dbIndex = 0)
        {
            if (dbIndex < 0 || dbIndex > 15)
            {
                throw new ArgumentOutOfRangeException(nameof(dbIndex));
            }
            _dbIndex = dbIndex;
            redis = ConnectionMultiplexer.Connect(redisUri);
        }
    }
}
