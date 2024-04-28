using Configurator.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>true, если аутентификация пройдена успешно, false - безуспешно</returns>
        public bool AuthenticateUser(string username, string password)
        {
            // Ищем пользователя в БД по имени
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false;
            }
            // Если находим, то сравниваем пароли
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}
