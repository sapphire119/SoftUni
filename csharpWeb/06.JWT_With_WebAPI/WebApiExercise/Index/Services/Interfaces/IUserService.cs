using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> Authenticate(string username, string password);
    }
}
