using InGame.WebApi.Data;
using InGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.WebApi.DataService
{
    public interface IProductDataService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategory(int categoryId);

        Product GetProduct(int productId);
        bool ProductExists(int productId);

        bool IsDuplicateProductName(int countryId, string countryName);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }

    public class ProductDataService : IProductDataService
    {
        private InGameDataContext _context;

        public ProductDataService(InGameDataContext context)
        {
            _context = context;
        }

        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool ProductExists(int productId)
        {
            var result = _context.Products.Any(x => x.Id == productId);
            return result;
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            var result = Save();
            return result;
        }

        public Product GetProduct(int productId)
        {
            var result = _context.Products.Where(x => x.Id == productId).FirstOrDefault();
            return result;
        }

        public List<Product> GetProducts()
        {
            var result = _context.Products.ToList();
            return result;
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            var result = Save();
            return result;
        }

        public bool IsDuplicateProductName(int countryId, string countryName)
        {
            var product = _context.Products.Where(c => c.Name.Trim().ToUpper() == countryName.Trim().ToUpper()
                                                && c.Id != countryId).FirstOrDefault();
            var result = product == null ? false : true;
            return result;
        }

        public bool Save()
        {
            _context.SaveChanges();
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var result = _context.Products.Where(c => c.CategoryId == categoryId).ToList();
            return result;
        }
    }
}
