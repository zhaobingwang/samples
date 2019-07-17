using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// 正确实现对象深拷贝和浅拷贝
    /// </summary>
    public class _014DeepCopyAndShallowCopy
    {
        public static void Run()
        {
            Employee jack = new Employee() { IDCode = 1, Age = 30, Department = new Department() { Name = "IT" } };
            Employee steven = jack.DeepClone() as Employee;
            Console.WriteLine(steven.IDCode);
            Console.WriteLine(steven.Age);
            Console.WriteLine(steven.Department);
            Console.WriteLine("*****改变Jack的值*****");
            jack.IDCode = 2;
            jack.Age = 40;
            jack.Department.Name = "HR";
            Console.WriteLine(steven.IDCode);
            Console.WriteLine(steven.Age);
            Console.WriteLine(steven.Department);
        }
    }
    [Serializable]
    public class Employee : ICloneable
    {
        public uint IDCode { get; set; }
        public byte Age { get; set; }
        public Department Department { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Employee DeepClone()
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as Employee;
            }
        }

        public Employee ShallowClone()
        {
            return Clone() as Employee;
        }
    }
    [Serializable]
    public class Department
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
