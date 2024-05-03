using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Models.UserModels;

namespace Configurator.Repositories.Interface
{
    interface IUserRepository
    {
        void Add(User entity); // добавление пользователя
        void Update(User entity); // обновление пользователя
        User? GetUserByUsername(string? username); // поиск пользователя по имени
        void Delete(User entity); // удаление пользователя
        IEnumerable<User> GetAll(); // получение всех пользователей
    }
}
