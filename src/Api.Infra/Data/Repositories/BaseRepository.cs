using System.Collections.Generic;
using System.Linq;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;

namespace Api.Infra.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);

            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<T>().Remove(Select(id));

            _context.SaveChanges();
        }

    }
}