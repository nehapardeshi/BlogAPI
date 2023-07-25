using AutoMapper;
using BlogAPI;
using BlogAPI.Controllers;
using BlogAPI.DTO;
using BlogAPI.Repository;
using BlogAppTest.MockData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppTest
{
    public class UserTest
    {
        private readonly UsersController _userController;
        private readonly IDataRepository _repository;
        private readonly IMapper _mapper;
        public UserTest()
        {
            _repository = new MockDataRepository();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BlogProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _userController = new UsersController(_repository, _mapper);
        }

        [Fact]
        public async void AddUser()
        {
            // Arrange
            var existingUsersCount = _repository.GetUsers().Count();
            var expectedNewUserId = existingUsersCount + 1;
            var newUser = new CreateUserDTO
            {
                FirstName = "Marion",
                LastName = "Klintzing",
                Email = "marion@gmail.com"

            };

            // Act
            var result = await _userController.AddUser(newUser);
            var okResult = result as OkObjectResult;
            var successDTO = (SuccessDTO)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(successDTO);
            Assert.Equal(expectedNewUserId, successDTO.Id);
        }

        [Fact]
        public async void GetUser()
        {
            // Arrange
            var userId = 2;


            // Act
            var result = await _userController.GetUser(2);
            var okResult = result as OkObjectResult;
            var userDTO = (UserDTO)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(userDTO);
            Assert.Equal(2, userDTO.Id);
        }

        [Fact]
        public async void GetUsers()
        {
            // Arrange
            var actualCount = _repository.GetUsers().Count();

            // Act
            var result = await _userController.GetUsers();
            var okResult = result as OkObjectResult;
            var usersDTO = (List<UserDTO>)okResult.Value;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(usersDTO);
            Assert.Equal(actualCount, usersDTO.Count);
        }
        



    }
}
