using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Configurator.Services.RegistrationService.Validators
{
    public class LoginValidator : IValidator
    {
        // Регулярные выражения для условий логина
        private readonly Regex hasMiniMaxChars = new Regex(@".{6,12}");

        public bool Validate(string login)
        {
            // Проверка соответствия всем условиям
            return hasMiniMaxChars.IsMatch(login);
        }
    }
}
