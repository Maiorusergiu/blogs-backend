using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Interfaces
{
    public interface IBlogProvider
    {
        Task<IEnumerable<BlogsModel>?> GetAllBlogsAsync(int skip, int take);
    }
}