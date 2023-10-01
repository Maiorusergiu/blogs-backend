using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.UIModels
{
    public class ApiResponseModel<T> where T : class
    {
        public T? Data {get; set;}
        public string? ErrorMessage {get; set;}
        
    }
}