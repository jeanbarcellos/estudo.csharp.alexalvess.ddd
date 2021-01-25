using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using FluentValidation;

namespace Api.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IList<T> Get()
        {
            return _repository.SelectAll();
        }

        public T Get(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            return _repository.Select(id);
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);

            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);

            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            _repository.Remove(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

    }
}