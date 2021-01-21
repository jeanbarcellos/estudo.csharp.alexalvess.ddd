using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface ICategoryService
    {
        IList<Category> Get();
    }

}