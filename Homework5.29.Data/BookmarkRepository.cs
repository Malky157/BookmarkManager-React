using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5._29.Data
{
    public class BookmarkRepository
    {
        private readonly string _connectionString;
        public BookmarkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Addbookmark(Bookmark bookmark)
        {
            var context = new BookmarkDbContext(_connectionString);
            context.Bookmarks.Add(bookmark);
            context.SaveChanges();
        }

        public List<object> TopFiveUrlsWithCount()
        {
            using (var context = new BookmarkDbContext(_connectionString))
            {
                var top5URLsWithUserCount = context.Bookmarks
                    .GroupBy(b => b.Url)
                    .OrderByDescending(g => g.Count())
                    .Take(5)
                    .Select(g => new { Url = g.Key, UserCount = g.Count() })
                    .ToList();
                return top5URLsWithUserCount.Cast<object>().ToList();
            }
        }
        public List<Bookmark> GetMyBookmarks(int userId)
        {
            var context = new BookmarkDbContext(_connectionString);
            return context.Bookmarks.Where(b => b.UserId == userId).ToList();
        }

        public void UpdateBookmarkTitle(Bookmark bookmark)

        {
            var context = new BookmarkDbContext(_connectionString);
            context.Bookmarks.Update(bookmark);
            context.SaveChanges();
        }
        public void DeleteBookmark(int id)
        {
            var context = new BookmarkDbContext(_connectionString);
            var bookmark = context.Bookmarks.FirstOrDefault(b => b.Id == id);
            if (bookmark != null)
            {
                context.Database.ExecuteSqlInterpolated($"Delete Bookmarks Where Id = {id}");
            }

        }
    }
}
