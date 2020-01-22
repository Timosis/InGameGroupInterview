using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InGame.Api.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int CategoryName { get; set; }
    }
}
