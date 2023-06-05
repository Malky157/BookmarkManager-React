using Homework5._29.Data;
using Homework5._29.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Homework5._29.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarkController : SharedController
    {
        public BookmarkController(IConfiguration configuration) : base(configuration)
        {
        }

        [HttpPost]
        [Route("addbookmark")]
        public void AddBookmark(Bookmark bookmark)
        {
            var user = GetCurrentUser();
            bookmark.UserId = user.Id;
            var bp = new BookmarkRepository(_connectionString);
            bp.Addbookmark(bookmark);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("topfivebookmarks")]
        public List<object> TopFiveBookmarks()
        {
            var bp = new BookmarkRepository(_connectionString);
            return bp.TopFiveUrlsWithCount();           
        }

        [HttpGet]
        [Route("getmybookmarks")]
        public List<Bookmark> GetMyBookmarks()
        {
            User user = GetCurrentUser();
            var bp = new BookmarkRepository(_connectionString);
            return bp.GetMyBookmarks(user.Id);
        }

        [HttpPost]
        [Route("updatebookmarktitle")]
        public void UpdateBookmarkTitle(Bookmark bookmark)
        {
            var bp = new BookmarkRepository(_connectionString);
            bp.UpdateBookmarkTitle(bookmark);
        }

        [HttpPost]
        [Route("deletebookmark")]
        public void DeleteBookmark(DeleteViewModel deleteId)
        {
            var bp = new BookmarkRepository(_connectionString);
            bp.DeleteBookmark(deleteId.Id);
        }
    }
}
