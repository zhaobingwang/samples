using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExcelDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IImporter importer = new ExcelImporter();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "tmp.xlsx");
            if (File.Exists(filePath))
                File.Delete(filePath);

            var result = await importer.GenerateTemplate<ImportStudentDTO>(filePath);
            Console.WriteLine(result.FileName);
        }
    }
}
