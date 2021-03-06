﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mongo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MongoDBHelper helper = new MongoDBHelper("dev");
            await helper.InsertAsync("sample", new Book
            {
                BookName = "三体",
                Price = 93.00M,
                Category = "科幻",
                Author = "刘慈欣"
            });
            Console.WriteLine("end...");
        }


    }

    /// <summary>
    /// 见: https://www.cnblogs.com/zhaodayou/p/6875586.html
    /// </summary>
    class MongoDBHelper
    {
        private static MongoClient client;
        private static IMongoDatabase database;
        private const string MongoDbConnectionString = "mongodb://localhost:27017";
        public MongoDBHelper(string dbName)
        {
            GetConnection(dbName);
        }
        static void GetConnection(string dbName)
        {
            client = new MongoClient(MongoDbConnectionString);
            database = client.GetDatabase(dbName);
        }

        public Task InsertAsync<T>(string collcetionName, T obj)
        {
            if (database == null)
                throw new Exception("Unspecified database.");
            var collcetion = database.GetCollection<T>(collcetionName);
            return collcetion.InsertOneAsync(obj);
        }
        /// <summary>
        /// 异步插入一条数据，采用类型T的完全限定名作为collection name
        /// </summary>
        public Task InsertAsync<T>(T obj)
        {
            return InsertAsync(typeof(T).FullName, obj);
        }

        /// <summary>
        /// 异步插入多条数据，手动输入collection name
        /// </summary>
        public Task BatchInsertAsync<T>(string collectionName, IEnumerable<T> objs)
        {
            if (database == null)
            {
                throw new Exception("没有指定数据库");
            }
            if (objs == null)
            {
                throw new ArgumentException();
            }
            var collection = database.GetCollection<T>(collectionName);
            return collection.InsertManyAsync(objs);
        }

        /// <summary>
        /// 异步插入多条数据，采用类型T的完全限定名作为collection name
        /// </summary>
        public Task BatchInsertAsync<T>(IEnumerable<T> objs)
        {
            return BatchInsertAsync(typeof(T).FullName, objs);
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        public void Insert<T>(T obj)
        {
            InsertAsync(obj).Wait();
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        public void Insert<T>(IEnumerable<T> objs)
        {
            BatchInsertAsync(objs).Wait();
        }

        /// <summary>
        /// MongoDB C# Driver的Find方法，返回IFindFluent。手动输入collection name
        /// </summary>
        public IFindFluent<T, T> Find<T>(string collectionName, FilterDefinition<T> filter, FindOptions options = null)
        {
            if (database == null)
            {
                throw new Exception("没有指定数据库");
            }
            var collection = database.GetCollection<T>(collectionName);
            return collection.Find(filter, options);
        }

        /// <summary>
        /// MongoDB C# Driver的Find方法，返回IFindFluent。采用类型T的完全限定名作为collection name
        /// </summary>
        public IFindFluent<T, T> Find<T>(FilterDefinition<T> filter, FindOptions options = null)
        {
            return Find(typeof(T).FullName, filter, options);
        }

        /// <summary>
        /// 取符合条件的数据 sort中多个排序条件逗号分隔，默认asc
        /// </summary>
        public List<T> Get<T>(Expression<Func<T, bool>> condition, int skip, int limit, string sort)
        {
            return Get(new List<Expression<Func<T, bool>>> { condition }, skip, limit, sort);
        }

        public List<T> Get<T>(Expression<Func<T, bool>> condition)
        {
            return Get(condition, 0, 0, null);
        }

        /// <summary>
        /// 取符合条件的数据 sort中多个排序条件逗号分隔，默认asc
        /// </summary>
        public List<T> Get<T>(List<Expression<Func<T, bool>>> conditions, int skip, int limit, string sort)
        {
            if (conditions == null || conditions.Count == 0)
            {
                conditions = new List<Expression<Func<T, bool>>> { x => true };
            }
            var builder = Builders<T>.Filter;
            var filter = builder.And(conditions.Select(x => builder.Where(x)));

            var ret = new List<T>();
            try
            {
                List<SortDefinition<T>> sortDefList = new List<SortDefinition<T>>();
                if (sort != null)
                {
                    var sortList = sort.Split(',');
                    for (var i = 0; i < sortList.Length; i++)
                    {
                        var sl = Regex.Replace(sortList[i].Trim(), @"\s+", " ").Split(' ');
                        if (sl.Length == 1 || (sl.Length >= 2 && sl[1].ToLower() == "asc"))
                        {
                            sortDefList.Add(Builders<T>.Sort.Ascending(sl[0]));
                        }
                        else if (sl.Length >= 2 && sl[1].ToLower() == "desc")
                        {
                            sortDefList.Add(Builders<T>.Sort.Descending(sl[0]));
                        }
                    }
                }
                var sortDef = Builders<T>.Sort.Combine(sortDefList);
                ret = Find(filter).Sort(sortDef).Skip(skip).Limit(limit).ToListAsync().Result;
            }
            catch (Exception e)
            {
                //异常处理
            }
            return ret;
        }
    }
}
