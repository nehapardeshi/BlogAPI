using AutoMapper;
using BlogAPI;
using BlogAPI.Controllers;
using BlogAPI.DTO;
using BlogAPI.Repository;
using BlogAppTest.MockData;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppTest
{
    public class BlogTest
    {
        private readonly BlogsController _blogController;
        private readonly IDataRepository _repository;
        private readonly IMapper _mapper;
        public BlogTest()
        {
            _repository = new MockDataRepository();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BlogProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _blogController = new BlogsController(_repository, _mapper);
        }

        [Fact]
        public async void AddBlog()
        {
            // Arrange
            var existingBlogsCount = _repository.GetBlogs().Count();
            var expectedNewBlogId = existingBlogsCount + 1;
            var newBlog = new CreateBlogDTO
            {
                UserId = 1,
                Title = "Health Blog",
                Content = "Health is important!"
            
            };

            // Act
            var result = await _blogController.AddBlog(newBlog);
            var okResult = result as OkObjectResult;
            var successDTO = (SuccessDTO)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(successDTO);
            Assert.Equal(expectedNewBlogId, successDTO.Id);
        }

        [Fact]
        public async void GetBlog()
        {
            // Arrange
            var blogId = 2;


            // Act
            var result = await _blogController.GetBlog(blogId);
            var okResult = result as OkObjectResult;
            var blogDTO = (BlogDTO)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(blogDTO);
            Assert.Equal(2, blogDTO.Id);
        }

        [Fact]
        public async void GetBlogs()
        {
            // Arrange
            var actualCount = _repository.GetBlogs().Count();

            // Act
            var result = await _blogController.GetBlogs();
            var okResult = result as OkObjectResult;
            var blogsDTO = (List<BlogDTO>)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(blogsDTO);
            Assert.Equal(actualCount, blogsDTO.Count);
        }
        [Fact]
        public async void UpdateBlog()
        {
            // Arrange
            var blogId = 1;
            var actualTitleName = "Food Blog";

            var getResult = await _blogController.GetBlog(blogId);
            var okGetResult = getResult as OkObjectResult;
            var blogDTO = (BlogDTO)okGetResult.Value;
            blogDTO.Title = actualTitleName;

            // Act
            var result = await _blogController.UpdateBlog(blogDTO);
            var okResult = result as OkObjectResult;
            var successDTO = (SuccessDTO)okResult.Value;
            var updatedBlog = _repository.GetBlog(blogId);

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(successDTO);
            Assert.Equal(blogId, successDTO.Id);
            Assert.Equal(actualTitleName, updatedBlog.Title);
        }

        [Fact]
        public async void DeleteBlog()
        {
            // Arrange
            var blogId = 3;

            // Act
            var result = await _blogController.DeleteBlog(3);
            var okResult = result as OkObjectResult;
            var successDTO = (SuccessDTO)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(successDTO);
            Assert.Equal(3, successDTO.Id);
        }

        
        
    }
}