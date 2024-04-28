using Configurator.Models.User;
using Configurator.Repositories.Interface;
using Configurator.Services.RegistrationService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Configurator.Services.RegistrationService
{
    class RegistrationService
    {
        private readonly IUserRepository _userRepository;
        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(string username, string password, string repeatedPassword, string mail)
        {
            IValidator passwordValidator = new PasswordValidator();
            IValidator loginValidator = new LoginValidator();
            IValidator mailValidator = new MailValidator();

            if (loginValidator.Validate(username) && passwordValidator.Validate(password) && mailValidator.Validate(mail) &&(password == repeatedPassword))
            {
                // Создание нового объекта пользователя
                var user = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    Email = mail,
                    UserRole = Role.User
                };
                // Сохранение нового пользователя в базе данных
                _userRepository.Add(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
