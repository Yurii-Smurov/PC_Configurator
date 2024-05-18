using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Admin
{
    class AdminMenuView : IView
    {
        private ViewController _viewController;

        public AdminMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
