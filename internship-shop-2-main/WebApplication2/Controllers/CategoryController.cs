using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        //get
        [HttpGet]
        public CategoryListRepresentation GetAll()
        {
            var dbCategories = _repo.GetAllCategories();

            return new CategoryListRepresentation(dbCategories);
        }


        [HttpGet("{id}")]
        public CategoryRepresentation GetCategory(int id)
        {
            var category = _repo.GetCategoryByID(id);
            if (category != null)
            {
                return new CategoryRepresentation(category);
            }

            return new CategoryRepresentation()
            {
                
            };
        }

        //post
        [HttpPost]

        public CategoryRepresentation Insert(Category category)
        {
            _repo.InsertCategory(category);
            return new CategoryRepresentation
            {
                
            };
        }

        //put

        [HttpPatch("{id}")]
        public CategoryRepresentation Update(int id, Category category)
        {
            var existingCategory = _repo.GetCategoryByID(id);
            if (existingCategory != null)
            {
                category.CategoryID = existingCategory.CategoryID;
                _repo.UpdateCategory(category);

                return new CategoryRepresentation
                {
                    
                };
            }
            return new CategoryRepresentation
            {
                
            };
        }


        //delete
        [HttpDelete("{id}")]
        public CategoryRepresentation Delete(int id)
        {
            var category = _repo.GetCategoryByID(id);
            if (category != null)
            {
                _repo.DeleteCategory(category);
                return new CategoryRepresentation
                {
                    
                };
            }
            return new CategoryRepresentation
            {
                
            };
        }

    }
}
