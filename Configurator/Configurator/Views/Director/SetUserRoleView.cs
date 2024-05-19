using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Director
{
    class SetUserRoleView : IView
    {
        private readonly ViewController _viewController;

        public SetUserRoleView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
