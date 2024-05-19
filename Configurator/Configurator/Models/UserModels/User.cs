using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.PCBuider;

namespace Configurator.Models.UserModels
{
    enum Role
    {
        User,
        Admin,
        Director
    }
    /// <summary>
    /// Класс для хранения данных пользователя
    /// </summary>
    class User
    {
        public User()
        {
        }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            UserRole = Role.User;
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Role UserRole { get; set; } = Role.User;
        public ICollection<PC> PCs { get; } = new List<PC>();
    }
}
