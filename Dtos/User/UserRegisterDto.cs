using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_rpg.Models;

namespace Student_rpg.Dtos.User
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}