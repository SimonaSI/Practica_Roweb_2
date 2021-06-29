using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return _context.Categories.SingleOrDefault(x => x.CategoryID == categoryID);
        }

        public Category InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var c = GetCategoryByID(category.CategoryID);
            c.Name = category.Name;
            c.Products = category.Products;
            c.Description = category.Description;
            _context.Update(c);
            _context.SaveChanges();
            return c;
        }

        public void DeleteCategory(Category categoryID)
        {
            _context.Remove(categoryID);
            _context.SaveChanges();
        }

    }
}

