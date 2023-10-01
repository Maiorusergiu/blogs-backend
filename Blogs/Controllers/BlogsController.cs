using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.Data;
using Blogs.Interfaces;
using Blogs.UIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Blogs.Controllers
{
    
    [Route("blog")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly DataContext _context;
        // private readonly Serilog.ILogger _logger;
        private readonly IBlogProvider _blogsProvider;
        private readonly IHttpContextAccessor? _accessor;
     
        public BlogsController(
            IBlogProvider blogsProvider,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _blogsProvider = blogsProvider;
            _accessor = httpContextAccessor;
            

        }
        [HttpGet]
        public async Task<IActionResult> GetBlogs(int skip = 0, int take = 10)
        {
            var response = new ApiResponseModel<IEnumerable<BlogsModel>>();
            try
            {
                response.Data = await _blogsProvider.GetAllBlogsAsync(skip, take);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // response.ErrorMessage = LogErrorMessage(ex);
                return Ok(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogsModel>> GetBlogById(int id)
        {
            var blog = _context.Blogs.FindAsync(id);
            if(blog == null) return BadRequest("Blog not found");
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogsModel>> DeleteBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if(blog == null) return BadRequest("Blog not found");
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return Ok(await _context.Blogs.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<BlogsModel>>> AddBlog(BlogsModel blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return Ok(await _context.Blogs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BlogsModel>>> UpdateBlog(BlogsModel request)
        {
            var blog = await _context.Blogs.FindAsync(request.Id);
            if(blog == null) return BadRequest("Blog not found.");
            blog.Title = request.Title;
            blog.Description = request.Description;
            blog.Date = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(await _context.Blogs.ToListAsync());
        }
        
    // [NonAction]
    //  public string LogErrorMessage(Exception ex)
    //     {
    //         var errorMessage = (ex.InnerException ?? ex).Message;
    //         _logger.Error(ex, errorMessage);
    //         return errorMessage;
    //     }   
    }
}