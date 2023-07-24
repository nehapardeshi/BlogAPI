using AutoMapper;
using BlogAPI.DTO;
using BlogAPI.Entities;
using BlogAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")] //for documenting the media type
    [Consumes("Application/json")]
    public class BlogsController : Controller
    {
        private readonly IDataRepository _repository;
        private readonly IMapper _mapper;
        public BlogsController(IDataRepository repository, IMapper mapper)
        {
              _repository = repository;
              _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BlogDTO>))]
        public async Task<IActionResult> GetBlogs()
        {
              var blogs = _repository.GetBlogs();
              var blogsDTO = _mapper.Map<List<BlogDTO>>(blogs);
              return Ok(blogsDTO);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BlogDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = _repository.GetBlog(id);
            if (blog == null)

            return NotFound(new NotFoundDTO { Message = $"Blog not found with Id {id}" });

            var blogDTO = _mapper.Map<BlogDTO>(blog);
            return Ok(blogDTO);
      
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDTO))]
        public async Task<IActionResult> AddBlog([FromBody] CreateBlogDTO createBlogDTO)
        {
            try
            {
                var blog = _mapper.Map<Blog>(createBlogDTO);
                var newBlog = _repository.AddBlog(blog);
                var dto = new SuccessDTO
                {
                    Message = "Blog added successfully",
                    Id = newBlog
                };
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO { Message = ex.Message });
            }

        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDTO))]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogDTO blogDTO)
        {
            try
            {
                var updatedBlog = _mapper.Map<Blog>(blogDTO);
                _repository.UpdateBlog(updatedBlog);
                return Ok(new SuccessDTO { Message = "Blog updated successfully.", Id = blogDTO.Id });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new NotFoundDTO { Message = $"Blog not found with Id {blogDTO.Id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO { Message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDTO))]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                _repository.DeleteBlog(id);
                return Ok(new SuccessDTO { Message = "Blog deleted successfully.", Id = id });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new NotFoundDTO { Message = $"Blog not found with Id {id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO { Message = ex.Message });
            }
        }
    }
}
