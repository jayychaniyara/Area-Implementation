using Assesment.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.ServiceContracts
{
    public interface ICategoriesService
    {
        List<Category> GetCategories();

        Category GetCategoryByCategoryID(long CategoryId);

        void InsertCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(long CategoryId);
    }
}
