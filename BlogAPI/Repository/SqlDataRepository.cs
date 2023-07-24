using BlogAPI.Controllers;
using BlogAPI.Entities;

namespace BlogAPI.Repository
{
    public class SqlDataRepository : IDataRepository
    {
        private readonly RepositoryContext _context;
        public SqlDataRepository(RepositoryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// To add a new blog.
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>

        public int AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return blog.Id;
        }
        /// <summary>
        /// To add a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;

        }
        public User? LoginUser(string email, string password)
        {
            // Fetch user from database using email and password

            return _context.Users.FirstOrDefault(
                u => u.Email.Trim().ToUpper() == u.Email.Trim().ToUpper()
                && u.Password == password);
        }
        public bool UpdatePassword(string email, string newPassword)
        {
            // Find first user from database:
            var user = _context.Users.FirstOrDefault(u => u.Email.Trim().ToUpper()
                                                      == email.Trim().ToUpper());
            if (user == null)
                throw new Exception("User not found!");

            // If user found update password:

            user.Password = newPassword;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// To delete a blog
        /// </summary>
        /// <param name="id"></param>
        public void Deleteblog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                Console.WriteLine("Blog is not found with this id!");
            }
            _context.Remove(blog);
            _context.SaveChanges();
        }
        /// <summary>
        /// To get a blog with blogid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Blog GetBlog(int id)
        {
            return _context.Blogs.FirstOrDefault(b => b.Id == id);
        }

        public List<Blog> GetUserBlogs(int userId)
        {
            return _context.Blogs.Where(b => b.UserId == userId).ToList();
        }

        /// <summary>
        /// To get all the blogs
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetBlogs()
        {
            return _context.Blogs.ToList();
        }
        /// <summary>
        /// To get all the users
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        /// <summary>
        /// To find or get a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
          
        public void UpdateBlog(Blog blog)
        {
            //First check BlogId:
            var UpdatedBlog = _context.Blogs.FirstOrDefault(x => x.Id == blog.Id);
            if (UpdatedBlog == null)
            {
                throw new NotFoundException($"Blog not found with this Id {blog.Id}!");
            }

            // Updates the blog properties:
            UpdatedBlog.Title = blog.Title;
            UpdatedBlog.Content = blog.Content;
            _context.SaveChanges();

        }
        /// <summary>
        /// to Delete a blog
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotFoundException"></exception>
        public void DeleteBlog(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null)
                throw new NotFoundException("This blog is not found in the system!");

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

       
    }
}
