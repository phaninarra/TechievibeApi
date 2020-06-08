using System;
using System.Collections.Generic;

namespace Techievibe.DataAccess.Models
{
    public partial class BlogPostCategories
    {
        public BlogPostCategories()
        {
            BlogPosts = new HashSet<BlogPosts>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<BlogPosts> BlogPosts { get; set; }
    }
}
