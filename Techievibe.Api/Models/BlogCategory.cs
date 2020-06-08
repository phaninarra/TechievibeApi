using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techievibe.Api.Models
{
    public class BlogCategory
    {
        public BlogCategory()
        {

        }
        public BlogCategory(int categoryId)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; }
        public string CategoryName { get; set; }
    }
}
