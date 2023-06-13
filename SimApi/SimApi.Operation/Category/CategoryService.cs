using SimApi.Data;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using System.Collections.Generic;

namespace SimApi.Operation
{
    public class CategoryService : ICategoryService
    {
        private readonly IDapperRepository<Category> _repository;

        public CategoryService(IDapperRepository<Category> repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Category category)
        {
            _repository.Insert(category);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }
    }
}