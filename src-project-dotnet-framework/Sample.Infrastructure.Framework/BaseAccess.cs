using ClickHouse.Ado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Framework
{
    public class BaseAccess<T> where T : class
    {
        private string _conn = string.Empty;

        public BaseAccess(string conn = "Compress=True;CheckCompressedHash=False;Compressor=lz4;Host=192.168.2.22;Port=9000;Database=sample;User=default;Password=")
        {
            _conn = conn;
        }

        public void Test()
        {
            using (var conn = GetConnection())
            {
                Thread.Sleep(1000);
                using (var cmd = conn.CreateCommand($"select * from test"))
                {
                    var result = cmd.ExecuteReader();
                }
            }
        }

        public bool Insert(T entity, string tableName = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            string sqlInsert = GetSingleInsertSQL(entity, tableName);
            using (var conn = GetConnection())
            {
                var cmd = conn.CreateCommand(sqlInsert);

                Type t = entity.GetType();
                var properties = t.GetProperties();
                foreach (var property in properties)
                {
                    cmd.AddParameter(property.Name, ConvertToDbType(property.PropertyType), property.GetValue(entity));
                }
                var result = cmd.ExecuteNonQuery();
            }
            return true;
        }

        private static void PrintData(IDataReader reader)
        {
            do
            {
                Console.Write("Fields: ");
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write("{0}:{1} ", reader.GetName(i), reader.GetDataTypeName(i));
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var val = reader.GetValue(i);
                        if (val.GetType().IsArray)
                        {
                            Console.Write('[');
                            Console.Write(string.Join(", ", ((IEnumerable)val).Cast<object>()));
                            Console.Write(']');
                        }
                        else
                        {
                            Console.Write(val);
                        }
                        Console.Write(", ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            } while (reader.NextResult());
        }
        public ClickHouseConnection GetConnection()
        {
            var settings = new ClickHouseConnectionSettings(this._conn);
            var conn = new ClickHouseConnection(settings);
            conn.Open();
            return conn;
        }
        private string GetSingleInsertSQL(T obj, string tableName = null)
        {
            string sqlInsert = $"INSERT INTO { tableName ?? typeof(T).Name} ";
            string sqlValue = string.Empty;
            Type t = obj.GetType();
            var properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var pName = property.Name;
                if (property == properties.First())
                {
                    sqlInsert += $"({pName},";
                    sqlValue += $" VALUES (@{pName},";
                }
                else if (property == properties.Last())
                {
                    sqlInsert += $"{pName})";
                    sqlValue += $"@{pName})";
                }
                else
                {
                    sqlInsert += $"{pName},";
                    sqlValue += $"@{pName},";
                }
            }

            var result = sqlInsert + sqlValue;

            return result;
        }
        private DbType ConvertToDbType(Type t)
        {
            if (t == typeof(long))
                return DbType.Int64;
            else if (t == typeof(string))
                return DbType.String;
            else if (t == typeof(DateTime))
                return DbType.DateTime;
            else if (t == typeof(double))
                return DbType.Double;
            else if (t == typeof(int))
                return DbType.Int32;
            else
                return DbType.Object;
        }
    }
}
