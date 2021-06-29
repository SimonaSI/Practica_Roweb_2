using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Business;
using WebApplication2.Domain;

namespace WebApplication2.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductByID(int productID)
        {
            return _context.Products.SingleOrDefault(x => x.ProductID == productID);
        }

        public Product InsertProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product UpdateProduct(Product product)
        {
            var c = GetProductByID(product.ProductID);
            c.Name = product.Name;
            c.Price = product.Price;
            c.BasePrice = product.BasePrice;
            c.Description = product.Description;
            c.ProductID = product.ProductID;
            c.FileName = product.FileName;
            _context.Update(c);
            _context.SaveChanges();
            return c;
        }

        public void DeleteProduct(Product productID)
        {
            _context.Remove(productID);
            _context.SaveChanges();
        }
    }
}
