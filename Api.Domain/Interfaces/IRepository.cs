using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> SelectAll();

        T Select(int id);

        void Insert(T obj);

        void Update(T obj);

        void Remove(int id);
    }

}