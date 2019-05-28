using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DotNet.CSharp.Concepts
{
    /// <summary>
    /// 逆变（contravariance）与协变（covariance）
    /// </summary>
    public class ContravariantAndCovariant
    {
        public delegate T MyFuncA<T>(); // 不支持逆变和协变
        public delegate T MyFuncB<out T>(); // 支持协变
    }
}
