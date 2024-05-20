using Configurator.Models.UserModels;
using Configurator.Repositories.Interface;
using Configurator.Models.PCBuider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Configurator.Models.Components;
using System.Runtime.CompilerServices;

namespace Configurator.Repositories.MSSQL
{
    class SQLUserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;
        public SQLUserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User entity)
        {
            using (var _dbContext = new UserDbContext())
            {
                // Логика добавления компонента в контекст БД
                _dbContext.Set<User>().Add(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(User entity)
        {
            using (var _dbContext = new UserDbContext())
            {
                throw new NotImplementedException();
            }
        }

        public User? GetUserByUsername (string? username)
        {
                return _dbContext.Users
                    .Include(u => u.PCs)
                    .ThenInclude(pc => pc.Components)
                    .FirstOrDefault(u => u.Username == username);
        }

        public void RefreshUserSession()
        {           
            var user = GetUserByUsername(UserSession.GetInstance().CurrentUser.Username);
            if (user != null)
            {
                UserSession.GetInstance().CurrentUser = user;
            }
        }

        public void AddPC(PC pc, User user)
        {
            pc.User = _dbContext.Users.First(u => u.UserId == user.UserId);
            _dbContext.PCs.Add(pc);
            _dbContext.SaveChanges();
        }

        public void DeletePC(int pcId, User user)
        {
            var pc = _dbContext.PCs
            .Include(pc => pc.Components)
            .FirstOrDefault(pc => pc.PCId == pcId);

            if (pc != null)
            {

            _dbContext.PCComponents.RemoveRange(pc.Components);
            _dbContext.PCs.Remove(pc);
            _dbContext.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = _dbContext.Users.Find(user.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.Password = user.Password;
                userToUpdate.Email = user.Email;
                userToUpdate.UserRole = user.UserRole;

                _dbContext.SaveChanges();
            }
        }
    }
}
