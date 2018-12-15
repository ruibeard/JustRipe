using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
    public class CategoryRepository :  IDisposable
    {
        private readonly IRepository<CategoryDTO> repository;
        public CategoryRepository(IRepository<CategoryDTO> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return from cat in repository.GetAll()
                   select new Category()
                   {
                       Id = cat.Id,
                       Name = cat.Name,
                   };
        }

        public void UpdateCategory(CategoryDTO _category)
        {
            repository.Update(_category);
        }
        public void DeleteCategory(CategoryDTO _category)
        {
            repository.Delete(_category);
        }

        public void AddCategory(CategoryDTO _category)
        {
            repository.Add(_category);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
