using JwtApi.Models;
using System.Collections.Generic;

namespace JwtApi.Services
{
    public interface IUsersService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
