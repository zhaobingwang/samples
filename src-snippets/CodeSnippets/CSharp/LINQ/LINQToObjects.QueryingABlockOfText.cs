using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeSnippets.CSharp.LINQ
{
    // LINQ和字符串-查询文本块
    public static class LINQToObjectsSnippets
    {
        // 如何对某个词在字符串中出现的次数进行计数 (LINQ)

        public static void CountWords()
        {
            string text = @"Historically, the world of data and the world of objects" +
                @" have not been well integrated. Programmers work in C# or Visual Basic" +
                @" and also in SQL or XQuery. On the one side are concepts such as classes," +
                @" objects, fields, inheritance, and .NET Framework APIs. On the other side" +
                @" are tables, columns, rows, nodes, and separate languages for dealing with" +
                @" them. Data types often require translation between the two worlds; there are" +
                @" different standard functions. Because the object world has no notion of query, a" +
                @" query can only be represented as a string without compile-time type checking or" +
                @" IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to" +
                @" objects in memory is often tedious and error-prone.";
            string searchTerm = "data";
            // Convert the string into an array of words  
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Create the query.  Use ToLowerInvariant to match "data" and "Data"
            var matchQuery = from word in source
                             where word.ToLowerInvariant() == searchTerm.ToLowerInvariant()
                             select word;

            // Count the matches, which executes the query.  
            int wordCount = matchQuery.Count();
            Console.WriteLine($"{wordCount} occurrences(s) of the search term \"{searchTerm}\" were found.");
            Console.ReadLine();
        }
    }
}
