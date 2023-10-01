using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blogs.Data;
using Blogs.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Blogs.Repositories
{
    public class BlogsRepository : IBlogRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
         public BlogsRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _context = dataContext;
        }

        public async Task<IEnumerable<BlogsModel>> GetAllBlogsAsync(int skip, int take)
        {
            var blogs = await _context.Blogs
            .Skip(skip).Take(take)
            .ToListAsync();
            return _mapper.Map<IEnumerable<BlogsModel>>(blogs);
        }
    }
}