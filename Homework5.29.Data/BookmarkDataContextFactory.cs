using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Homework5._29.Data
{
    public class BookmarkDataContextFactory : IDesignTimeDbContextFactory<BookmarkDbContext>
    {
        public BookmarkDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Homework5.29.Web"))
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new BookmarkDbContext(config.GetConnectionString("ConStr"));
        }
    }
}
