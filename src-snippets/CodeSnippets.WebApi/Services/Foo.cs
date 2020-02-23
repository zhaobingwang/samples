using CodeSnippets.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.WebApi.Services
{
    public class Foo : IFoo
    {
        public bool Ping(string ip)
        {
            return new Random().Next(1, 100) % 2 == 1;
        }
    }
}
