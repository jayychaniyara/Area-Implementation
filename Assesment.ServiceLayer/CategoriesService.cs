using Assesment.DomainModels;
using Assesment.RepositoryContracts;
using Assesment.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.ServiceLayer
{
    public class CategoriesService : ICategoriesService
    {
        ICategoriesRepository categoriesRepository;

        public CategoriesService(ICategoriesRepository repo)
        {
            this.categoriesRepository = repo;
        }

        public void DeleteCategory(long CategoryId)
        {
            categoriesRepository.DeleteCategory(CategoryId);
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = categoriesRepository.GetCategories();
            return categories;
        }

        public Category GetCategoryByCategoryID(long CategoryId)
        {
            Category c = categoriesRepository.GetCategoryByCategoryID(CategoryId);
            return c;
        }

        public void InsertCategory(Category category)
        {
            categoriesRepository.InsertCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            categoriesRepository.UpdateCategory(category);
        }
    }
}
