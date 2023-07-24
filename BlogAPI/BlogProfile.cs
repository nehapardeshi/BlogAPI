using AutoMapper;
using BlogAPI.DTO;
using BlogAPI.Entities;

namespace BlogAPI
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogDTO>();
            CreateMap<User, UserDTO>();
          

            CreateMap<BlogDTO, Blog>();
            CreateMap<UserDTO, User>();

            CreateMap<CreateBlogDTO, Blog>();
            CreateMap<BlogDTO, CreateBlogDTO>();

            CreateMap<CreateUserDTO, User>();
            CreateMap<User, CreateUserDTO>();




        }
    }
}
