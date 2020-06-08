using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Api.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            PostAuthor = "Phani Narra";
        }
        public BlogPost(int postId)
        {
            PostAuthor = "Phani Narra";
            PostId = postId;
        }
        public int PostId { get; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public string PostAuthor { get; }
        public DateTime PostDate { get; set; }
        public int PostReadingTime { get; set; }
        public int PostLikeCount { get; set; }
        public int PostCommentCount { get; set; }
        public string PostCategory { get; set; }

    }
}
