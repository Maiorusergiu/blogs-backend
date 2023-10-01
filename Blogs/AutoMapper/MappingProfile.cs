using AutoMapper;
using Blogs;
using Blogs.UIModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BlogsModel, BlogsModel>();
    }
}