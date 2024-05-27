using System.Text.RegularExpressions;

namespace Configurator.Services.RegistrationService.Validators
{
    public class MailValidator : IValidator
    {
        // Регулярные выражения для условий почты
        private readonly Regex hasMiniMaxChars = new Regex(@".{6,30}");
        private readonly Regex hasStructure = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

        public bool Validate(string? mail)
        {
            if (mail == null)
            {
                return false;
            }
            // Проверка соответствия всем условиям
            return hasMiniMaxChars.IsMatch(mail) && hasStructure.IsMatch(mail);
        }
    }
}
