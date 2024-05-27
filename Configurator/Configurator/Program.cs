using Configurator.Views;

class Program
{
    static void Main()
    {
        ViewController stateController = new ViewController();
        stateController.ShowCurrentView(); // Отображается начальная страница авторизации.
    }
}