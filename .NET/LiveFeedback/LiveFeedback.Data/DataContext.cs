using LiveFeedback.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace LiveFeedback.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<MyImage> MyImages { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LiveFeedback_db");
        }



    }
}
