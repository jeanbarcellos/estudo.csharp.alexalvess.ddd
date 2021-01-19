using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Infra.Data.Repositories;
using FluentValidation;

namespace Api.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public IList<T> Get()
        {
            return repository.SelectAll();
        }

        public T Get(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            return repository.Select(id);
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            repository.Remove(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

    }
}