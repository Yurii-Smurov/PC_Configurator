using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Configurator.Services.RegistrationService.Validators
{
    public class MailValidator : IValidator
    {
        // Регулярные выражения для условий почты
        private readonly Regex hasMiniMaxChars = new Regex(@".{6,30}");
        private readonly Regex hasStructure = new Regex(@"^\w+(\@\w+\.\w+)$");

        public bool Validate(string password)
        {
            // Проверка соответствия всем условиям
            return hasMiniMaxChars.IsMatch(password) && hasStructure.IsMatch(password);
        }
    }
}
