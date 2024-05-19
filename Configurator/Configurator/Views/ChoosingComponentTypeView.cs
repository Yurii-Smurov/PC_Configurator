using Configurator.Models.Components;
using Configurator.Repositories.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views
{
    class ChoosingComponentTypeView : IView
    {
        private readonly ViewController _viewController;

        public ChoosingComponentTypeView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            _viewController.ChangeState(new ChooseComponentView<Processor>(new SQLComponentRepository<Processor>(new PCComponentDbContext())));
            _viewController.ShowCurrentView();


            _viewController.ChangeState(new ChooseComponentView<Processor>(new SQLComponentRepository<Processor>(new PCComponentDbContext())));
        }
    }
}
