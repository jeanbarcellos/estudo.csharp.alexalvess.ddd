using System;
using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Service.Validators;
using FluentValidation;

namespace Api.Service.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public IList<Category> Get()
        {
            return _repository.SelectAll();
        }

        public Category Get(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            return _repository.Select(id);
        }

        public Category Post<AbstractValidator>(Category category)
        {
            Validate(category, Activator.CreateInstance<CategoryValidator>());

            _repository.Insert(category);

            return category;
        }

        public Category Post(Category category)
        {
            Validate(category, Activator.CreateInstance<CategoryValidator>());

            _repository.Insert(category);

            return category;
        }

        public Category Put<AbstractValidator>(Category category)
        {
            Validate(category, Activator.CreateInstance<CategoryValidator>());

            _repository.Update(category);

            return category;
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("The id can't be zero.");
            }

            _repository.Remove(id);
        }

        private void Validate(Category category, AbstractValidator<Category> validator)
        {
            if (category == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(category);
        }

    }
}