using AutoMapper;
using BlogAPI.DTO;
using BlogAPI.Entities;
using BlogAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")] //for documenting the media type
    [Consumes("Application/json")]
    public class UsersController : Controller
    {
         private readonly IDataRepository _repository;
         private readonly IMapper _mapper;
         public UsersController(IDataRepository repository, IMapper mapper)
         {
              _repository = repository;
              _mapper = mapper;
         }
         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]    
         public async Task<IActionResult> GetUsers()
         {
            var users = _repository.GetUsers();
            var usersDTO = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDTO);
         }

         [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
         [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
         public async Task<IActionResult> GetUser(int id)
         {
            var user = _repository.GetUser(id);
            if (user == null)

                return NotFound(new NotFoundDTO { Message = $"User not found with Id {id}" });

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);

         }
         [HttpPost]
         [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
         [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDTO))]
         public async Task<IActionResult> AddUser([FromBody] CreateUserDTO createUserDTO)
         {
            try
            {
                var user = _mapper.Map<User>(createUserDTO);
                var userId = _repository.AddUser(user);
                var dto = new SuccessDTO
                {
                    Message = "User added successfully",
                    Id = userId
                };
                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorDTO { Message = ex.Message });
            }


            //[HttpPost]
            //[Route("login")]
            //public async Task<IActionResult> LoginUser([FromBody] LoginInfo info)
            //{
            //    var user = _repository.LoginUser(info.Email, info.Password);
            //    return Ok(user.Id);
            //}

         //[HttpPut]
         //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
         //[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundDTO))]
         //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDTO))]
         //public async Task<IActionResult> UpdatePassword([FromBody] PasswordReset user)
         //{
         //     var updatedPassword = _repository.UpdatePassword(user.Email, user.NewPassword);
         //      return Ok(true);

         }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessDTO))]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginInfo info)
        {
            var user = _repository.LoginUser(info.Email, info.Password);
            var dto = new SuccessDTO
            {
                Message = "User added successfully",
                Id = user.Id
            };
            return Ok(dto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BlogDTO>))]
        [Route("{userId}/blogs")]
        public async Task<IActionResult> GetUserBlogs(int userId)
        {
            var blogs = _repository.GetUserBlogs(userId);
            var blogsDTO = _mapper.Map<List<BlogDTO>>(blogs);
            return Ok(blogsDTO);
        }

    }
}
