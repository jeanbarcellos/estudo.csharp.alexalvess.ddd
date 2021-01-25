using Api.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace Api.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        IList<T> Get();

        T Get(int id);

        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);
    }
}