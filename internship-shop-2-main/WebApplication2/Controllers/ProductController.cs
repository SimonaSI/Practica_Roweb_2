using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductRepository repository, IWebHostEnvironment hostEnvironment)
        {
            _repo = repository;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public ProductListRepresentation GetAll()
        {
            var dbProducts = _repo.GetAllProducts();
            return new ProductListRepresentation(dbProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _repo.GetProductByID(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPost("Create")]
        public IActionResult Insert(Product product)
        {
            _repo.InsertProduct(product);
            return Ok(product);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repo.GetProductByID(id);
            if (product != null)
            {
                _repo.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {id} was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existingProduct = _repo.GetProductByID(id);
            if (existingProduct != null)
            {
                product.ProductID = existingProduct.ProductID;
                _repo.UpdateProduct(product);
            }
            return Ok(product);
        }

        // GET Image
        [HttpGet]
        [Route("api/product/{id}/{fileName}")]
        public IActionResult GetImage(int id, string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName + ext);
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/jpeg");
        }

        [HttpGet]
        [Route("api/produt/{id}")]
        public IActionResult GetImage([FromRoute] int id)
        {
            var data = _repo.GetProductByID(id);
            var file = data.FileName;
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", file);
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/jpeg");
        }

    }
}
