using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Issues
{
    /// <summary>
    /// 迭代器
    /// https://www.cnblogs.com/yangecnu/archive/2012/03/17/2402432.html
    /// </summary>
    public class Iterator
    {
        public class Timetable
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public IEnumerable<DateTime> DateRange
            {
                get
                {
                    for (DateTime day = StartDate; day <= EndDate; day = day.AddDays(1))
                    {
                        yield return day;
                    }
                }
            }
        }

        public static IEnumerable<string> ReadLines(string fileName)
        {
            using (TextReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }

    #region 实现自己的迭代器
    public class MyIEnumerable : IEnumerable
    {
        private string[] _strList;
        public MyIEnumerable(string[] strList)
        {
            _strList = strList;
        }
        public IEnumerator GetEnumerator()
        {
            return new MyIEnumerator(_strList);
        }
    }
    public class MyIEnumerator : IEnumerator
    {
        private string[] _strList;
        private int position;
        public MyIEnumerator(string[] strList)
        {
            _strList = strList;
            position = -1;
        }
        public object Current
        {
            get { return _strList[position]; }
        }

        public bool MoveNext()
        {
            position++;
            if (position < _strList.Length)
                return true;
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    #endregion
}
