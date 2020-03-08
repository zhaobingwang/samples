using ServiceA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticles(int userId);
    }
}
