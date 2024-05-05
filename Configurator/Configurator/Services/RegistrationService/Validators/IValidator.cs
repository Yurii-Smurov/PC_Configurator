using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.RegistrationService.Validators
{
    interface IValidator
    {
        public bool Validate(string? value);
    }
}
