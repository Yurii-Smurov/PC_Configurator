using Configurator.Models.Components;
using Configurator.Repositories.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Utils
{
    class ComponentListConsoleView<T>
        where T : PCComponent 
    {
        public void ShowList()
        {
            var componentRepository = new SQLComponentRepository<T>(new PCComponentDbContext());

            var componentList = componentRepository.GetAll();

            foreach (var component in componentList)
            {
                Console.WriteLine(component.Name);
            }
        }
    }
}
