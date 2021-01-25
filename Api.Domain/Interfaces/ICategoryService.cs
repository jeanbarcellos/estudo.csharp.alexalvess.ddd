using System.Collections.Generic;
using Api.Domain.Entities;
using FluentValidation;

namespace Api.Domain.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> Get();

        Category Get(int id);

        Category Post<AbstractValidator>(Category category);

        Category Put<AbstractValidator>(Category category);

        void Delete(int id);
    }

}