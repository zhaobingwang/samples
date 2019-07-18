using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippets.Books.CSharp157
{
    /// <summary>
    /// 元素数量可变的情况下不应使用数组
    /// </summary>
    public class _016NoNotUseArrayWhenVariable
    {
        /// <summary>
        /// 如果一定要改变数组的长度，
        /// 一种方式是：将数组转换为ArrayList或List<T>
        /// 另一方式是：用数组的复制功能
        /// </summary>
        public static void Run()
        {
            // 1. 将数组转换为ArrayList或List<T>
            int[] iArr = { 0, 1, 2, 3, 4, 5 };
            ArrayList arrayListInt = ArrayList.Adapter(iArr);   // 将数组转变为ArrayList
            arrayListInt.Add(6);
            List<int> listInt = iArr.ToList<int>(); // 将数组转变为List<T>
            listInt.Add(6);

            // 2. 用数组的复制功能
            iArr = (int[])iArr.ReSize(10);
        }
    }
    public static class ClassForExtensions
    {
        public static Array ReSize(this Array array, int newSize)
        {
            Type t = array.GetType().GetElementType();
            Array newArray = Array.CreateInstance(t, newSize);
            Array.Copy(array, 0, newArray, 0, Math.Min(array.Length, newSize));
            return newArray;
        }
    }
}
