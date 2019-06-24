using ClickHouse.Ado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace ClickHouseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ClickHouseOperator clickHouseOperator = new ClickHouseOperator();

                // insert
                Sample sample = new Sample();
                sample.I64Value = 1;
                sample.StringValue = "0000";
                sample.DateValue = DateTime.Now;
                sample.Float64Value = 1;
                sample.PartitionByValue = new DateTime(2000, 1, 1);
                sample.PKI64 = 4;
                sample.PKString = "d";

                List<Sample> aaa = new List<Sample>();
                aaa.Add(sample);
                string sqlInsert = clickHouseOperator.GetInsertSQL(sample, nameof(sample));
                using (var conn = clickHouseOperator.GetConnection())
                {
                    var cmd = conn.CreateCommand(sqlInsert);
                    cmd.Parameters.Add(new ClickHouseParameter
                    {
                        DbType = DbType.Object,
                        ParameterName = "bulk",
                        Value = aaa
                    });
                    cmd.ExecuteNonQuery();
                }

                // query
                string sqlQuery = "select * from sample";
                using (var conn = clickHouseOperator.GetConnection())
                using (var cmd = conn.CreateCommand(sqlQuery))
                {
                    //cmd.Parameters.Add();
                    using (var reader = cmd.ExecuteReader())
                    {
                        PrintData(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
    }

    class ClickHouseOperator
    {

        public ClickHouseConnection GetConnection(string cstr = "Compress=True;CheckCompressedHash=False;Compressor=lz4;Host=192.168.2.22;Port=9000;Database=test;User=default;Password=")
        {
            var settings = new ClickHouseConnectionSettings(cstr);
            var conn = new ClickHouseConnection(settings);
            conn.Open();
            return conn;
        }


        public string GetInsertSQL<T>(T obj, string tableName = null) where T : class
        {
            string sqlInsert = $"INSERT INTO { tableName ?? nameof(T)} (";
            Type t = obj.GetType();
            var properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var pName = property.Name;
                if (property == properties.Last())
                    sqlInsert += $"{pName}";
                else
                    sqlInsert += $"{pName},";
            }
            sqlInsert += ") VALUES @bulk";
            return sqlInsert;
        }
    }

    class Sample : IEnumerable
    {
        public long I64Value { get; set; }
        public string StringValue { get; set; }
        public DateTime DateValue { get; set; }
        public double Float64Value { get; set; }
        public DateTime PartitionByValue { get; set; }
        public long PKI64 { get; set; }
        public string PKString { get; set; }

        public IEnumerator GetEnumerator()
        {
            yield return I64Value;
            yield return StringValue;
            yield return DateValue;
            yield return Float64Value;
            yield return PartitionByValue;
            yield return PKI64;
            yield return PKString;
        }
    }
}
