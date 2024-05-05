using Configurator.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.UserModels;

namespace Configurator.Authentication
{
    class AuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Метод аутентификации пользователя
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Данные о пользователе</returns>
        public User? AuthenticateUser(string? username, string? password)
        {
            var user = _userRepository.GetUserByUsername(username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password) ? user : null;
        }
    }
}
