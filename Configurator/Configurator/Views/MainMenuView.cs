using Configurator.Models.UserModels;
using Configurator.Models.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Repositories.MSSQL;

namespace Configurator.Views
{
    class MainMenuView : IView
    {
        private readonly ViewController _viewController;

        public MainMenuView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Главная страница");
            Console.WriteLine($"Текущий пользователь: {UserSession.GetInstance().CurrentUser.Username}");
            _viewController.ChangeState(new ChoosingComponentTypeView(_viewController));
            _viewController.ShowCurrentView();
        }
    }
}
