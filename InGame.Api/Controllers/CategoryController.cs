using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InGame.Api.DataService;
using InGame.Api.Models;
using InGame.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InGame.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryDataService _categoryDataService;
        IMapper _mapper;

        public CategoryController(ICategoryDataService categoryDataService, IMapper mapper)
        {
            _categoryDataService = categoryDataService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = _categoryDataService.GetCategories();
            if (categories == null)
                return NotFound("There is no categories");

            var hierarchicalCategory = BuildTree(categories);
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(hierarchicalCategory);

            return Ok(categoryDtos);
        }

        [Route("GetCategoriesWithoutHierarchy")]
        public IActionResult GetCategoriesWithoutHierarchy()
        {
            var categories = _categoryDataService.GetCategories();
            if (categories == null)
                return NotFound("There is no categories");            
            List<CategoryDto> categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }



        public static List<Category> BuildTree(List<Category> source)
        {
            var groups = source.GroupBy(i => i.ParentId);

            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();

            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        private static void AddChildren(Category node, IDictionary<int, List<Category>> source)
        {
            if (source.ContainsKey(node.Id))
            {
                node.SubCategories = source[node.Id];
                for (int i = 0; i < node.SubCategories.Count; i++)
                    AddChildren(node.SubCategories[i], source);
            }
            else
            {
                node.SubCategories = new List<Category>();
            }
        }

    }
}