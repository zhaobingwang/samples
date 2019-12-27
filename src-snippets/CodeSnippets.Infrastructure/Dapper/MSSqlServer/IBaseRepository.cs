using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Infrastructure.Dapper.MSSqlServer
{
    public interface IBaseRepository
    {
        object Get();
    }
}
