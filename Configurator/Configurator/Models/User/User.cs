using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Models.User
{
    enum Role
    {
        Unauthorized,
        User,
        Admin
    }
    /// <summary>
    /// Класс для хранения данных пользователя
    /// </summary>
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role UserRole { get; set; } = Role.User;
    }
}
