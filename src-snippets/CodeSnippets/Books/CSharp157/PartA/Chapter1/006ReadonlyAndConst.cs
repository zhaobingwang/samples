using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// const是一个编译期的常量，readonly是一个运行时的常量，因此const效率相对较高。
    /// readonly的意义在于，它在第一次被赋值后将不可以改变：
    ///     1.对于值类型变量，值本身不可改变
    ///     2.对于引用类型变量，引用本身（相当于指针）不可改变
    /// </summary>
    public class _006ReadonlyAndConst
    {
    }
}
