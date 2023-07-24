using BlogAPI.Entities;

namespace BlogAPI.Repository
{
    public interface IDataRepository
    {
        List<Blog> GetBlogs();
        Blog GetBlog(int id);

        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <param name="movie"></param>
        int AddBlog(Blog blog);

        /// <summary>
        /// Updates an existing movie 
        /// </summary>
        /// <param name="movie"></param>
        void UpdateBlog(Blog blog);

        /// <summary>
        /// Deletes a movie by Id
        /// </summary>
        /// <param name="id"></param>
        void DeleteBlog(int id);
        List<User> GetUsers();
        User GetUser(int id);

        /// <summary>
        /// Adds a new movie
        /// </summary>
        /// <param name="movie"></param>
        int AddUser(User user);
        User LoginUser(string email, string password);
        //// Update Password

        bool UpdatePassword(string email, string newPassword);
        //void EditPassword(string newPassword);
        //Validate new User
        //User Validate User(string User user);
        //Save new User
        //void Save();
        //

        List<Blog> GetUserBlogs(int userId);


    }
}
