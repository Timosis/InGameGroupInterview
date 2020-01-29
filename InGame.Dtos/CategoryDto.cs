using System;
using System.Collections.Generic;
using System.Text;

namespace InGame.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }
        public bool HasChild { get; set; }
        public List<CategoryDto> SubCategories { get; set; }
    }
}
