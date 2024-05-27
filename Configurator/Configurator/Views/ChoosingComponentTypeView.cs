using Configurator.Models.Components;
using Configurator.Repositories.MSSQL;
using Configurator.Views.UserInput;

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


            while (true)
            {
                try 
                {
                Console.Clear();
                Console.WriteLine("Выберите тип комплектующего: ");
                Console.WriteLine("0 Вернуться.");
                Console.WriteLine("1 Процессор.");
                Console.WriteLine("2 Материнская плата.");
                Console.WriteLine("3 Видеокарта.");
                Console.WriteLine("4 Оперативная память.");
                Console.WriteLine("5 Корпус.");
                Console.WriteLine("6 Блок Питания.");
                Console.WriteLine("7 HDD.");
                Console.WriteLine("8 SSD.");
                Console.WriteLine("9 Система воздушного охлаждения процессора.");
                Console.WriteLine("10 Система водяного охлаждения процессора.");
                Console.WriteLine("11 Звуковая карта.");

                int choice = ConsoleInput.ReadInteger("Выбор: ");

                    switch (choice)
                    {
                        case 0:
                            _viewController.ChangeState(new MainMenuView(new SQLUserRepository(new UserDbContext()), _viewController));
                            _viewController.ShowCurrentView();
                            return;
                        case 1:
                            _viewController.ChangeState(new ChooseComponentView<Processor>(_viewController, new SQLComponentRepository<Processor>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 2:
                            _viewController.ChangeState(new ChooseComponentView<Motherboard>(_viewController, new SQLComponentRepository<Motherboard>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 3:
                            _viewController.ChangeState(new ChooseComponentView<GraphicsCard>(_viewController, new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 4:
                            _viewController.ChangeState(new ChooseComponentView<Memory>(_viewController, new SQLComponentRepository<Memory>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 5:
                            _viewController.ChangeState(new ChooseComponentView<ComputerCase>(_viewController, new SQLComponentRepository<ComputerCase>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 6:
                            _viewController.ChangeState(new ChooseComponentView<PowerUnit>(_viewController, new SQLComponentRepository<PowerUnit>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 7:
                            _viewController.ChangeState(new ChooseComponentView<HDD>(_viewController, new SQLComponentRepository<HDD>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 8:
                            _viewController.ChangeState(new ChooseComponentView<SSD>(_viewController, new SQLComponentRepository<SSD>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 9:
                            _viewController.ChangeState(new ChooseComponentView<AirCoolingSystem>(_viewController, new SQLComponentRepository<AirCoolingSystem>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 10:
                            _viewController.ChangeState(new ChooseComponentView<LiquidCoolingSystem>(_viewController, new SQLComponentRepository<LiquidCoolingSystem>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        case 11:
                            _viewController.ChangeState(new ChooseComponentView<SoundCard>(_viewController, new SQLComponentRepository<SoundCard>(new PCComponentDbContext())));
                            _viewController.ShowCurrentView();
                            return;
                        default:
                            Console.WriteLine("Неверный выбор.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Произошла ошибка:");
                    Console.WriteLine(e.Message); // Вывод сообщения об ошибке
                    Console.WriteLine("Чтобы повторить попытку нажмите любую клавишу.");
                    Console.ReadKey();
                    _viewController.ShowCurrentView();
                    return;
                }
            }
        }
    }
}
