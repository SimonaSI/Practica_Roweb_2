using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Domain;

namespace WebApplication2.Business
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductByID(int productID);
        Product InsertProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
