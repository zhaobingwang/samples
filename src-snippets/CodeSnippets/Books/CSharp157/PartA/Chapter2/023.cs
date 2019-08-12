using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// 建议23 避免将List<T>作为自定义集合类的基类
    /// </summary>
    public class _023
    {
        public static void Run1()
        {
            Employee1 employee1 = new Employee1() {
                new Employee(){Name="张三"},
                new Employee(){Name="李四"}
            };
            IList<Employee> employees = employee1;
            employees.Add(new Employee() { Name = "王五" });
            foreach (var item in employee1)
            {
                Console.WriteLine(item.Name);
            }
            // OutPut:
            // 张三Changed
            // 李四Changed
            // 王五
            Console.ReadLine();
        }
        public static void Run2()
        {
            Employee2 employee2 = new Employee2() {
                new Employee(){Name="张三"},
                new Employee(){Name="李四"}
            };
            ICollection<Employee> employees = employee2;
            employees.Add(new Employee() { Name = "王五" });
            foreach (var item in employee2)
            {
                Console.WriteLine(item.Name);
            }
            // OutPut:
            // 张三Changed
            // 李四Changed
            // 王五Changed
            Console.ReadLine();
        }

        public class Employee1 : List<Employee>
        {
            public new void Add(Employee item)
            {
                item.Name += "Changed";
                base.Add(item);
            }
        }
        public class Employee2 : IEnumerable<Employee>, ICollection<Employee>
        {
            #region IEnumerable<Employee> 成员
            List<Employee> items = new List<Employee>();
            public IEnumerator<Employee> GetEnumerator()
            {
                return items.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
            #endregion

            #region 
            public int Count => throw new NotImplementedException();

            public bool IsReadOnly => throw new NotImplementedException();

            public void Add(Employee item)
            {
                item.Name += "Changed";
                items.Add(item);
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(Employee item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Employee[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(Employee item)
            {
                throw new NotImplementedException();
            }
            #endregion
        }
        public class Employee
        {
            public string Name { get; set; }
        }
    }
}
