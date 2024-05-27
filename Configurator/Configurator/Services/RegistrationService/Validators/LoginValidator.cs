using System.Text.RegularExpressions;

namespace Configurator.Services.RegistrationService.Validators
{
    public class LoginValidator : IValidator
    {
        // Регулярные выражения для условий логина
        private readonly Regex hasMiniMaxChars = new Regex(@".{6,12}");

        public bool Validate(string? login)
        {
            if (login == null)
            {
                return false;
            }
            // Проверка соответствия всем условиям
            return hasMiniMaxChars.IsMatch(login);
        }
    }
}
