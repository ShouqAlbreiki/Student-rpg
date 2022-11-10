using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_rpg.Models;

namespace Student_rpg.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(string Role, User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}