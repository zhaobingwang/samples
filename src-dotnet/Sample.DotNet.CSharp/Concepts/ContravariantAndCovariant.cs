using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.DotNet.CSharp.Concepts
{
    /// <summary>
    /// 逆变（contravariance）与协变（covariance）
    /// </summary>
    public static class ContravariantAndCovariant
    {

    }

    public abstract class Animal
    {
    }

    public class Dog : Animal
    {
    }

    public interface IMyList<in T>
    {
        //T GetElement();
        void ChangeT(T t);
    }
    public class MyList<T> : IMyList<T>
    {
        //public T GetElement()
        //{
        //    return default(T);
        //}
        public void ChangeT(T t)
        {
            throw new NotImplementedException();
        }
    }
}
