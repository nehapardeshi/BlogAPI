using BlogAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public object Blog { get; internal set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                Id = 1,
                Title = "Use Git like a senior engineer",
                Content = "I’ve used these features of Git for years across teams and " +
                "projects. I’m still developing opinions around some workflows" +
                " (like to squash or not) but the core tooling is powerful and flexible" +
                " (and scriptable!).\r\n\r\nGoing through Git logs\r\nGit logs are" +
                " gross to go through out of the box.\r\n\r\ngit log is basic\r\nUsing" +
                " git log gives you some information. But it’s extremely high-resolution" +
                " and not usually what you’re looking for.",
                CreatedDate = DateTime.Now,
                UserId = 1,

            },
            new Blog
            {
                Id = 2,
                Title = "Sharing Data Between Microservices",
                Content = "When I started working with microservices, I took the common" +
                " rule of “two services must not share a data source” a bit too" +
                " literally.\r\n\r\nI saw it stapled everywhere on the internet:" +
                " “thou shalt not share a DB between two services”, and it definitely" +
                " made sense. A service must own its data and retain the freedom to " +
                "change its schema as it pleases, without changing its external-facing" +
                " API.\r\n\r\nBut there’s an important subtlety here that I didn’t" +
                " understand until much later. To apply this rule properly," +
                " we have to distinguish between sharing a data source and sharing data.",
                CreatedDate = DateTime.Now,
                UserId = 2,

            },
            new Blog
            {
                Id = 3,
                Title = "Why Experienced Programmers Fail Coding Interviews",
                Content = "A friend of mine recently joined a FAANG company as an engineering" +
                " manager, and found themselves in the position of recruiting for engineering" +
                " candidates.\r\n\r\nWe caught up.\r\n\r\n“Well,” I laughed when they" +
                " inquired about the possibility of me joining the team, “I’m not sure" +
                " I’ll pass the interviews, but of course I’d love to work with you again!" +
                " I’ll think about it.”\r\n\r\n“That’s the same thing X and Y both said,”" +
                " they told me, referring to other engineers we had worked with together." +
                " “They both said they…\r\n\r\n",
                CreatedDate = DateTime.Now,
                UserId = 3,

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Jacob",
                LastName = "Benett",
                Email = "jacob.benett@gmail.com",
                Password = "123456"
            },
            new User
            {
                Id = 2,
                FirstName = "Vinay",
                LastName = "Gupta",
                Email = "vinay.gupta@gmail.com",
                Password = "123456"

            },
            new User
            {
                Id = 3,
                FirstName = "Nicholas",
                LastName = "Henrikson",
                Email = "nicholas.henrikson@gmail.com",
                Password = "123456"

            });

        }
    }
}
