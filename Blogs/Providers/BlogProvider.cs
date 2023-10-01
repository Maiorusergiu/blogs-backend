using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blogs.Interfaces;
using Blogs.Repository;

namespace Blogs.Providers
{
    public class BlogProvider : IBlogProvider
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        
        public BlogProvider(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogsModel>> GetAllBlogsAsync(int skip, int take)
        {
            IEnumerable<BlogsModel> result = await _blogRepository.GetAllBlogsAsync(skip, take);
            return _mapper.Map<IEnumerable<BlogsModel>>(result);
        }
    }
}