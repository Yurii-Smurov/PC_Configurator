using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.UserModels;
using Configurator.Models.PCBuider;

namespace Configurator.Repositories.Interface
{
    interface IUserRepository
    {
        void AddUser(User entity); // добавление пользователя
        void RefreshUserSession(); // обновление информации о пользователе
        User? GetUserByUsername(string? username); // поиск пользователя по имени
        void DeleteUser(User entity); // удаление пользователя
        void AddPC(PC entity, User user); // добавление сборки ПК к учётной записи пользователя
        void DeletePC(int pcId, User user); // удаление сборки ПК из учётной записи пользователя

    }
}
