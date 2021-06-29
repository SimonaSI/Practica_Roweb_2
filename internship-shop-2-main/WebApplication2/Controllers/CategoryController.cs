using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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


        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            try
            {
                if (id != category.CategoryID)
                {
                    return BadRequest("Id");
                }
                var data = _repo.GetCategoryByID(id);
                if (data == null)
                {
                    return NotFound("Null");
                }
                var updateCategory = _repo.UpdateCategory(category);
                return Ok(updateCategory);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        // POST
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid");
                }

                var NewCategory = _repo.InsertCategory(category);

                return CreatedAtAction("GetAll", new { CategoryId = category.CategoryID }, category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
