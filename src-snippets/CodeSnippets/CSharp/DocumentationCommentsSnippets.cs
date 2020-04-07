using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.CSharp
{
    /// <summary>
    /// 文档注释
    /// https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/language-specification/documentation-comments
    /// </summary>
    public class DocumentationCommentsSnippets
    {
        public void Run()
        { 
            //SayHi()
        }

        /// <summary>
        /// 这个方法返回带用户姓名的问候语
        /// 你也可以直接使用<see cref="FormatGreetingMessage(string)"/>格式化问候语句
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SayHi(string name)
        {
            return FormatGreetingMessage(name);
        }

        public string FormatGreetingMessage(string name)
        {
            var now = DateTime.Now;
            if (now.Hour > 12)
                return $"早上好，{name}！";
            else if (now.Hour > 18)
                return $"下午好，{name}！";
            else
                return $"晚上好，{name}！";
        }
    }

    /// <summary>
    /// 这是一个列表类
    /// </summary>
    /// <typeparam name="T">列表中存储的类型</typeparam>
    public class MyList<T>
    { 
    }
}
