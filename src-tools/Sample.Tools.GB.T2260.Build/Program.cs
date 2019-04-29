using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Sample.Tools.GB.T2260.Build
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fileName = $"GB-T2260-201902.txt";
                List<GBT2260> list = new List<GBT2260>();
                using (var fileReader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        var split = line.Split(':');
                        list.Add(new GBT2260
                        {
                            Key = split[0],
                            Value = split[1]
                        });
                    }
                }
                var jsonGBT2260 = JsonConvert.SerializeObject(list);
                using (StreamWriter writer = File.AppendText("GB-T2260.json"))
                {
                    writer.Write(jsonGBT2260);
                }
                Console.WriteLine("success.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    class GBT2260
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

