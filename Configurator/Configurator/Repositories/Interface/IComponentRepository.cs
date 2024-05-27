using Configurator.Models.Components;

namespace Configurator.Repositories
{
    /// <summary>
    /// Интерфейс репозитория для общих операций CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IComponentRepository<T>
        where T : PCComponent
    {
        void Add(T entity); // добавление комплектующего
        void Update(T entity); // обновление комплектующего
        void Delete(T entity); // удаление комплектующего по id
        T? GetComponent(int id); // получение одного комплектующего по id
        IEnumerable<T> GetAll(); // получение всех комплектующих
    }
}
