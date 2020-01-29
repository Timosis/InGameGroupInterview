using InGame.WebApi.Data;
using InGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.WebApi.DataService
{

    public interface ICategoryDataService
    {
        List<Category> GetCategories();
        Product GetCategory(int categoryId);
        bool CategoryExists(int categoryId);

        bool IsDuplicateCategoryName(int countryId, string countryName);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }



    public class CategoryDataService : ICategoryDataService
    {
        private InGameDataContext _context;
        public CategoryDataService(InGameDataContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var result = _context.Categories.ToList();
            return result;
        }

        public Product GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool CategoryExists(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateCategoryName(int countryId, string countryName)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
