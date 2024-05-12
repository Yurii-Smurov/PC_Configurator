using Configurator.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class ViewController
    {
        private IView _currentView;

        public ViewController()
        {
            _currentView = new RegistrationView();
        }

        public void ChangeState(IView view)
        {
            _currentView = view;
        }

        public void ShowCurrentView()
        {
            _currentView.Show();
        }
    }
}
