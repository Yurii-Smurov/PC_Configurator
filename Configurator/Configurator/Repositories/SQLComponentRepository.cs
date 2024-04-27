using System;
using System.Collections.Generic;
using System.ComponentModel;
using Configurator.Models.Components;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Configurator.Repositories
{
    internal class SQLComponentRepository<T> : IComponentRepository<T>
        where T : PCComponent
    {
        private readonly PCComponentDbContext _dbContext;

        public SQLComponentRepository(PCComponentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            using (var _dbContext = new PCComponentDbContext())
            {
                // Логика добавления компонента в контекст БД
                _dbContext.Set<T>().Add(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var _dbContext = new PCComponentDbContext())
            {
                // Логика обновления компонента в контексте БД
                _dbContext.Set<T>().Update(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var _dbContext = new PCComponentDbContext())
            {
                // Логика удаления компонента из контекста БД
                _dbContext.Set<T>().Remove(entity);
                // сохранение изменений сделанных в контексте БД в саму БД
                _dbContext.SaveChanges();
            }
        }

        public T GetComponent(int id)
        {
            using (var _dbContext = new PCComponentDbContext())
            {
                // Логика получения компонента по id из базы данных
                return _dbContext.Set<T>().Find(id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var _dbContext = new PCComponentDbContext())
            {
                // Логика получения всех компонентов из базы данных
                return _dbContext.Set<T>().ToList();
            }
        }
    }
}
