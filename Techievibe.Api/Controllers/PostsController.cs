using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techievibe.Api.Models;
using Techievibe.DataAccess.Models;

namespace Techievibe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PostsController : ControllerBase
    {
        // GET api/Posts/list
        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            using (var context = new DB_A61787_TechieVibeContext())
            {
                var posts = context.BlogPosts.Include(x=>x.PostCategory).OrderByDescending(x=>x.PostDate).ToList();
                                
                return Ok(posts);
            }
        }

        // GET api/Posts/11980
        [HttpGet("{postId}")]
        public IActionResult Get(int postId)
        {
            using (var context = new DB_A61787_TechieVibeContext())
            {
                var post = context.BlogPosts.Include(y => y.PostCategory).FirstOrDefault(y => y.PostId == postId);
                return Ok(post);
            }
        }

        // POST api/Posts/create
        [HttpPost]
        [Route("create")]
        public IActionResult CreatePost([FromBody] BlogPosts post)
        {
            if (post == null)
                return BadRequest("Something wrong in the request");

            //get post category or create a new one.
            using (var context = new DB_A61787_TechieVibeContext())
            {
                var category = context.BlogPostCategories.Where(x => x.CategoryName.ToLower() == post.PostCategory.CategoryName.ToLower()).FirstOrDefault();

                if (category == null)
                {
                    category = new BlogPostCategories();

                    category.CategoryName = post.PostCategory.CategoryName;

                    context.BlogPostCategories.Add(category);

                    context.SaveChanges();

                    category = context.BlogPostCategories.Where(x => x.CategoryName.ToLower() == post.PostCategory.CategoryName.ToLower()).FirstOrDefault();
                }

                BlogPosts dataPost = new BlogPosts();

                
                dataPost.PostAuthor = "Phani Narra";
                dataPost.PostBody = post.PostBody;
                dataPost.PostCategory = category;
                dataPost.PostCategoryId = category.CategoryId;
                dataPost.PostCommentCount = post.PostCommentCount;
                dataPost.PostDate = post.PostDate;
                dataPost.PostLikeCount = post.PostLikeCount;
                dataPost.PostReadingTime = post.PostReadingTime;
                dataPost.PostTitle = post.PostTitle;

                context.BlogPosts.Add(dataPost);

                context.SaveChanges();

            }

            return Ok("Blog Post saved successfully to the database");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}