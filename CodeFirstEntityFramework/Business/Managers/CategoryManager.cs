using Data.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class CategoryManager
    {

        CategoryRepository categoryRepository;
        public CategoryManager(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Add(Category category)
        {
            categoryRepository.Add(category);
        }
        public void Delete(Category category)
        {
            categoryRepository.Delete(category);
        }
        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }
        public Category FindWithId(Category category)
        {
            return categoryRepository.FindWithId(category);
        }
        public IEnumerable<Category> GetAll(Category category)
        {
            return categoryRepository.GetAll(category);
        }
    }
}
