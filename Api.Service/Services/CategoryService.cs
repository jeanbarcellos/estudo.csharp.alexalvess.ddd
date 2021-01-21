using System.Collections.Generic;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

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
    }
}