﻿using System.Text.RegularExpressions;

namespace Configurator.Services.RegistrationService.Validators
{
    public class PasswordValidator : IValidator
    {
        // Регулярные выражения для условий пароля
        private readonly Regex hasNumber = new Regex(@"[0-9]+");
        private readonly Regex hasUpperChar = new Regex(@"[A-Z]+");
        private readonly Regex hasMiniMaxChars = new Regex(@".{6,12}");
        private readonly Regex hasLowerChar = new Regex(@"[a-z]+");
        private readonly Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?-]");

        public bool Validate(string? password)
        {
            if (password == null)
            {
                return false;
            }
            // Проверка соответствия всем условиям
            return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMiniMaxChars.IsMatch(password)
                && hasLowerChar.IsMatch(password) && hasSymbols.IsMatch(password);
        }
    }    
}
