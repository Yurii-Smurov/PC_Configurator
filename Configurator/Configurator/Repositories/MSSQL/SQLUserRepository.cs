using Configurator.Models.User;
using Configurator.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Repositories.MSSQL
{
    class SQLUserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public SQLUserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User entity)
        {
            using (var _dbContext = new UserDbContext())
            {
                // Логика добавления компонента в контекст БД
                _dbContext.Set<User>().Add(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (var _dbContext = new UserDbContext())
            {
                // Логика добавления компонента в контекст БД
                _dbContext.Set<User>().Remove(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public User? GetUserByUsername (string username)
        {
            using (var dbContext = new UserDbContext())
            {
                return dbContext.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
