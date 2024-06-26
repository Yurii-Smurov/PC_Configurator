﻿using Configurator.Models.UserModels;
using Configurator.Repositories.Interface;
using Configurator.Services.RegistrationService.Validators;

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

            if (loginValidator.Validate(username) && passwordValidator.Validate(password) && mailValidator.Validate(mail) 
                && (password == repeatedPassword) && _userRepository.GetUserByUsername(username) == null)
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
                _userRepository.AddUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
