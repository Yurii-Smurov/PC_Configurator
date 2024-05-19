using Configurator;
using Configurator.Models.Components;
using Configurator.Models.PCBuider;
using Configurator.Models.UserModels;
using Configurator.Views.Utils;
using Configurator.Views;
using Configurator.Repositories;
using Configurator.Repositories.MSSQL;
using Configurator.Authentication;
using Configurator.Views.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

class Program
{
    static void Main()
    {
        ViewController stateController = new ViewController();
        stateController.ShowCurrentView(); // Отображается начальная страница авторизации.
    }
}