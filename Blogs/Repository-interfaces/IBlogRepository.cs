using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Repository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogsModel>> GetAllBlogsAsync(int skip, int take);
    }
}