using System;
using System.Collections.Generic;

namespace Techievibe.DataAccess.Models
{
    public partial class BlogPosts
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public string PostAuthor { get; set; }
        public DateTime PostDate { get; set; }
        public int PostReadingTime { get; set; }
        public int? PostLikeCount { get; set; }
        public int? PostCommentCount { get; set; }
        public int PostCategoryId { get; set; }

        public BlogPostCategories PostCategory { get; set; }
    }
}
