using InGame.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.Api.DataService
{
    public interface ICategoryDataService
    {
        List<Category> GetProducts();
        List<Product> GetProductsByCategory(int categoryId);

        Product GetProduct(int productId);
        bool ProductExists(int productId);

        bool IsDuplicateProductName(int countryId, string countryName);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
    


    public class CategoryDataService
    {
    }
}
