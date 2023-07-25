using BlogAPI.Entities;
using BlogAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppTest.MockData
{
    public class MockDataRepository : IDataRepository
    {
        private static List<Blog> _blogs = new List<Blog>
        {
            new Blog {Id= 1, Title = "Food Blog",Content = "Deb’s kitchen, where she experiments and comes up with unique recipes that she shares with the world. Her site has a nice feature called “Surprise me!” " +
                "where a random recipe is suggested. Great for people wondering what to eat!"},
            new Blog {Id= 2, Title = "Health Blog", Content = "My Fitness Pal is an online platform that helps people lose weight. The site also offers a great set of mobile apps that allow users to keep track of their weight, exercise regularly, and more. The site also has a " +
                "lively blog section where users can learn more about all things related to fitness."},
            new Blog {Id= 3, Title = "Travel Blog", Content = "Trisha is a Philippines-born blogger who shares her adventures from travels around the globe. Being a digital nomad, she always has an interesting story to tell or impressions to share about various places. Moreover, the blog has useful information for people who want to travel, " +
                "including posts about visas, travel budgets, solo travel, and more." },
        };

        private static List<User> _users = new List<User>
        {
            new User {Id = 1, FirstName = "John", LastName = "Henrikson", Email = "John@gmail.com", Password = "abcdef" },
            new User {Id =2, FirstName = "Natalia", LastName = "choma", Email = "Natalia@yahoomail.com", Password = "123456"},
            new User {Id =3, FirstName = "Martin", LastName = "Haavi", Email = "Martin@hotmail.com", Password = "abcdef"}
        };
        public int AddBlog(Blog blog)
        {
            var newBlogId = _blogs.Count + 1;
            blog.Id = newBlogId;
            _blogs.Add(blog);
            return newBlogId;
        }
        public Blog GetBlog(int id)
        {
            return _blogs.FirstOrDefault(b => b.Id == id);
        }
        public void DeleteBlog(int id)
        {
            var blog = GetBlog(id);
            _blogs.Remove(blog);
        }
        public List<Blog> GetBlogs()
        {
            return _blogs;
        }
        public void UpdateBlog(Blog blog)
        {
            var updatedBlog = GetBlog(blog.Id);
            var index = _blogs.IndexOf(updatedBlog);
            _blogs[index] = blog;
        }
        public int AddUser(User user)
        {
            var newUserId = _users.Count + 1;
            user.Id = newUserId;
            _users.Add(user);
            return newUserId;
        }
        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        public List<User> GetUsers()
        {
            return _users;
        }


        public User LoginUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassword(string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetUserBlogs(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
