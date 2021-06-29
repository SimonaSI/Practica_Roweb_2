using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryByID(int categoryID);
        Category InsertCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(Category category);
       
    }
}
