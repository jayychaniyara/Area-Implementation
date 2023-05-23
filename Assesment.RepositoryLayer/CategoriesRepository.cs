using Assesment.DataLayer;
using Assesment.DomainModels;
using Assesment.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.RepositoryLayer
{
    public class CategoriesRepository : ICategoriesRepository
    {
        CompanyDbContext dbContext = new CompanyDbContext();

        public void DeleteCategory(long CategoryId)
        {
            Category existingCategory = dbContext.Categories.Where(temp => temp.CategoryId == CategoryId).FirstOrDefault();
            dbContext.Categories.Remove(existingCategory);
            dbContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = dbContext.Categories.ToList();
            return categories;
        }

        public Category GetCategoryByCategoryID(long CategoryId)
        {
            Category category = dbContext.Categories.Where(temp => temp.CategoryId == CategoryId).FirstOrDefault();
            return category;
        }

        public void InsertCategory(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            Category existingCategory = dbContext.Categories.Where(temp => temp.CategoryId == category.CategoryId).FirstOrDefault();
            existingCategory.CategoryId = category.CategoryId;
            existingCategory.CategoryName = category.CategoryName;
            dbContext.SaveChanges();
        }
    }
}
