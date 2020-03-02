using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface IUserService
    {
        Task<Tag> CreateTag(int userId, string tag);
    }
}
