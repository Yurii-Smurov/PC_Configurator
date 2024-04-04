using Configurator.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Views.Renderers
{
    /// <summary>
    /// Интерфейс, хранящий метод для отрисовки меню
    /// </summary>
    interface IMenuRenderer
    {
        void RenderMenu(int selectedIndex);
    }
}
