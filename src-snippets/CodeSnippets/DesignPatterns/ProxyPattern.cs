using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.DesignPatterns.ProxyPattern
{
    #region static proxy
    public interface ISubject
    {
        string SayHi(string words);
    }

    public class RealSubject : ISubject
    {
        public string SayHi(string words)
        {
            return words;
        }
    }

    public class SubjectProxy : ISubject
    {
        ISubject subImpl = new RealSubject();
        public string SayHi(string words)
        {
            return subImpl.SayHi(words);
        }
    }
    #endregion


}