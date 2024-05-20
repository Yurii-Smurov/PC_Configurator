using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.Components;
using Configurator.Models.UserModels;
using Configurator.Repositories;
using Configurator.Repositories.MSSQL;
using Configurator.Views.Director;
using Configurator.Views.UserInput;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Configurator.Views.Admin
{
    class AddComponentView : IView
    {
        private readonly ViewController _viewController;

        public AddComponentView(ViewController viewController)
        {
            _viewController = viewController;
        }

        public void Show()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                Console.Clear();
                Console.WriteLine("Добавить комплектующее");
                Console.WriteLine("0 Вернуться");
                Console.WriteLine("1 Процессор");
                Console.WriteLine("2 Материнская плата");
                Console.WriteLine("3 Видеокарта");
                Console.WriteLine("4 Оперативная память");
                Console.WriteLine("5 Корпус");
                Console.WriteLine("6 Блок Питания");
                Console.WriteLine("7 HDD");
                Console.WriteLine("8 SSD");
                Console.WriteLine("9 Система воздушного охлаждения процессора");
                Console.WriteLine("10 Система водяного охлаждения процессора");
                Console.WriteLine("11 Звуковая карта");

                int choice = ConsoleInput.ReadInteger("Выбор: ");

                switch (choice)
                {
                    case 0:
                        if (UserSession.GetInstance().CurrentUser.UserRole == Role.Admin)
                        {
                            _viewController.ChangeState(new AdminMenuView(_viewController));
                        }
                        else if (UserSession.GetInstance().CurrentUser.UserRole == Role.Director)
                        {
                            _viewController.ChangeState(new DirectorMenuView(_viewController));
                        }
                        else
                        {
                            _viewController.ChangeState(new EnterView(_viewController));
                        }

                        _viewController.ShowCurrentView();
                        shouldExit = true;
                        break;
                    case 1:
                        AddProcessor(new SQLComponentRepository<Processor>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 2:
                        AddMotherboard(new SQLComponentRepository<Motherboard>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 3:
                        AddGraphicsCard(new SQLComponentRepository<GraphicsCard>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 4:
                        AddMemory(new SQLComponentRepository<Memory>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 5:
                        AddCase(new SQLComponentRepository<ComputerCase>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 6:
                        AddPowerUnit(new SQLComponentRepository<PowerUnit>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 7:
                        AddHDD(new SQLComponentRepository<HDD>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 8:
                        AddSSD(new SQLComponentRepository<SSD>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 9:
                        AddAirCS(new SQLComponentRepository<AirCoolingSystem>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 10:
                        AddLiquidCS(new SQLComponentRepository<LiquidCoolingSystem>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    case 11:
                        AddSoundCard(new SQLComponentRepository<SoundCard>(new PCComponentDbContext()));
                        shouldExit = true;
                        break;
                    default:
                        shouldExit = true;
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                _viewController.ShowCurrentView();
            }
        }

        private static void AddProcessor(IComponentRepository<Processor> processorRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            Processor processor = new Processor
            {
                Name = ConsoleInput.ReadString("Название процессора"),
                Price = ConsoleInput.ReadDecimal("Цена процессора"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Socket = ConsoleInput.ReadString("Сокет"),
                DDR4 = ConsoleInput.ReadBoolean("Поддержка ddr4"),
                DDR5 = ConsoleInput.ReadBoolean("Поддержка ddr5"),
                M2 = ConsoleInput.ReadBoolean("Поддержка m2 накопителей"),
                TDP = ConsoleInput.ReadInteger("Тепловыделение")
            };

            processorRepository.Add(processor);
            Console.WriteLine("Процессор успешно добавлен в БД");
        }

        private static void AddMotherboard(IComponentRepository<Motherboard> motherboardRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            Motherboard motherboard = new Motherboard
            {
                Name = ConsoleInput.ReadString("Название материнской платы"),
                Price = ConsoleInput.ReadDecimal("Цена материнской платы"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор"),
                Chipset = ConsoleInput.ReadString("Чипсет"),
                Socket = ConsoleInput.ReadString("Сокет"),
                DDR4 = ConsoleInput.ReadBoolean("Поддержка ddr4"),
                DDR5 = ConsoleInput.ReadBoolean("Поддержка ddr5"),
                M2 = ConsoleInput.ReadBoolean("Поддержка m2 накопителей")
            };

            motherboardRepository.Add(motherboard);
            Console.WriteLine("Материнская плата успешно добавлена в БД");
        }

        private static void AddGraphicsCard(IComponentRepository<GraphicsCard> gpuRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            GraphicsCard gpu = new GraphicsCard
            {
                Name = ConsoleInput.ReadString("Название видеокарты"),
                Price = ConsoleInput.ReadDecimal("Цена видеокарты"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                ModelGPU = ConsoleInput.ReadString("Модель видеокарты"),
                TypeMEM = ConsoleInput.ReadString("Тип видеопамяти"),
                Freq = ConsoleInput.ReadInteger("Частота графического процессора"),
                Volume = ConsoleInput.ReadInteger("Объём видеопамяти")
            };

            gpuRepository.Add(gpu);
            Console.WriteLine("Видеокарта успешно добавлена в БД");
        }

        private static void AddMemory(IComponentRepository<Memory> memRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            Memory memory = new Memory
            {
                Name = ConsoleInput.ReadString("Название оперативной памяти"),
                Price = ConsoleInput.ReadDecimal("Цена оперативной памяти"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                DDR4 = ConsoleInput.ReadBoolean("ddr4"),
                DDR5 = ConsoleInput.ReadBoolean("ddr5"),
                Freq = ConsoleInput.ReadInteger("Частота оперативной памяти"),
                Volume = ConsoleInput.ReadInteger("Объём оперативной памяти")
            };

            memRepository.Add(memory);
            Console.WriteLine("Оперативная память успешно добавлена в БД");
        }

        private static void AddCase(IComponentRepository<ComputerCase> caseRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            ComputerCase computerCase = new ComputerCase
            {
                Name = ConsoleInput.ReadString("Название корпуса"),
                Price = ConsoleInput.ReadDecimal("Цена корпуса"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор")
            };

            caseRepository.Add(computerCase);
            Console.WriteLine("Корпус успешно добавлен в БД");
        }

        private static void AddPowerUnit(IComponentRepository<PowerUnit> powerUnitRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            PowerUnit powerUnit = new PowerUnit
            {
                Name = ConsoleInput.ReadString("Название блока питания"),
                Price = ConsoleInput.ReadDecimal("Цена блока питания"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор")
            };

            powerUnitRepository.Add(powerUnit);
            Console.WriteLine("Блок питания успешно добавлен в БД");
        }
        private static void AddHDD(IComponentRepository<HDD> hddRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            HDD hdd = new HDD
            {
                Name = ConsoleInput.ReadString("Название HDD"),
                Price = ConsoleInput.ReadDecimal("Цена HDD"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор"),
                Speed = ConsoleInput.ReadInteger("Скорость записи"),
                Volume = ConsoleInput.ReadInteger("Объём накопителя"),
                Rotation = ConsoleInput.ReadInteger("Скорость вращения диска")
            };

            hddRepository.Add(hdd);
            Console.WriteLine("HDD успешно добавлен в БД");
        }
        private static void AddSSD(IComponentRepository<SSD> ssdRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            SSD ssd = new SSD
            {
                Name = ConsoleInput.ReadString("Название SSD"),
                Price = ConsoleInput.ReadDecimal("Цена SSD"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор"),
                Speed = ConsoleInput.ReadInteger("Скорость записи"),
                Volume = ConsoleInput.ReadInteger("Объём накопителя"),
                Nvme = ConsoleInput.ReadBoolean("NVMe")
            };

            ssdRepository.Add(ssd);
            Console.WriteLine("SSD успешно добавлен в БД");
        }

        private static void AddAirCS(IComponentRepository<AirCoolingSystem> airCSRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            AirCoolingSystem airCS = new AirCoolingSystem
            {
                Name = ConsoleInput.ReadString("Название системы охлаждения"),
                Price = ConsoleInput.ReadDecimal("Цена системы охлаждения"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Socket = ConsoleInput.ReadString("Сокет"),
                Speed = ConsoleInput.ReadInteger("Скорость вентиляторов"),
                TdpDIS = ConsoleInput.ReadInteger("Теплоотвод"),
                Upgradable = ConsoleInput.ReadBoolean("Расширяемость"),
                CuTubes = ConsoleInput.ReadInteger("Количество медных трубок")
            };

            airCSRepository.Add(airCS);
            Console.WriteLine("Система воздушного охлаждения успешно добавлена в БД");
        }

        private static void AddLiquidCS(IComponentRepository<LiquidCoolingSystem> liquidCSRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            LiquidCoolingSystem liquidCS = new LiquidCoolingSystem
            {
                Name = ConsoleInput.ReadString("Название системы охлаждения"),
                Price = ConsoleInput.ReadDecimal("Цена системы охлаждения"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Socket = ConsoleInput.ReadString("Сокет"),
                Speed = ConsoleInput.ReadInteger("Скорость вентиляторов"),
                TdpDIS = ConsoleInput.ReadInteger("Теплоотвод"),
                Serviced = ConsoleInput.ReadBoolean("Обслуживаемость")
            };

            liquidCSRepository.Add(liquidCS);
            Console.WriteLine("Система водяного охлаждения успешно добавлена в БД");
        }

        private static void AddSoundCard(IComponentRepository<SoundCard> soundCardRepository)
        {
            Console.Clear();
            Console.WriteLine("Заполните следующие поля:");

            SoundCard soundCard = new SoundCard
            {
                Name = ConsoleInput.ReadString("Название звуковой карты"),
                Price = ConsoleInput.ReadDecimal("Цена звуковой карты"),
                Manufacturer = ConsoleInput.ReadString("Производитель"),
                Stock = ConsoleInput.ReadInteger("Наличие в магазине"),
                Form = ConsoleInput.ReadString("Форм-фактор")
            };

            soundCardRepository.Add(soundCard);
            Console.WriteLine("Звуковая карта успешно добавлена в БД");
        }
    }
}
