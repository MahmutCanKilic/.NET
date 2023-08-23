using Data.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class CategoryManager : ICategory
    {

        //CategoryRepository categoryRepository = new();
        readonly ICategory iCategoryRepository;
        public CategoryManager(ICategory iCategory)
        {
            this.iCategoryRepository = iCategory;
        }

        public void Add(Category category)
        {
            iCategoryRepository.Add(category);
        }
        public void Delete(Category category)
        {
            iCategoryRepository.Delete(category);
        }
        public Category Update(Category category)
        {
           return iCategoryRepository.Update(category);
        }
        public Category FindWithId(Category category)
        {
            return iCategoryRepository.FindWithId(category);
        }
        public IEnumerable<Category> GetAll()
        {
            return iCategoryRepository.GetAll();
        }
    }

}
