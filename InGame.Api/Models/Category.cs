using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.Api.Models
{
    public class Category : Base
    {
        public int? ParentId { get; set; }
        public string CategoryName { get; set; }

        public Category Parent { get; set; }
        public List<Category> SubCategories { get; set; }

    }
}
