using Microsoft.EntityFrameworkCore;

namespace Homework5._29.Data
{
    public class BookmarkDbContext : DbContext
    {
        private string _connectionString;

        public BookmarkDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
