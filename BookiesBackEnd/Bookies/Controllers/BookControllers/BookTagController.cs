using Bookies.Repository;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Bookies.Core.BasicClasses;
using Microsoft.EntityFrameworkCore;
using Bookies.API.ViewModel.BookVMs;

namespace Tagies.API.Controllers.TagControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookTagController : Controller
    {
        private readonly BookiesContext db;

        public BookTagController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<BookTagShowVM> GetBookTag(int BookID)
        {
            var Tag = db.BookTag
                .Include(x => x.Tag)
                .OrderBy(BG => BG.Tag.TagName)
                .Where(BG => BG.BookID == BookID)
                .Select(BG=>new BookTagShowVM()
                {
                    TagID = BG.TagID,
                    TagName=BG.Tag.TagName,
                }).ToList();

            return Tag;
        }

        [HttpPost]
        public ActionResult AddBookTag([FromForm] BookTagVM BG)
        {
            var BookTag = new BookTag()
            {
                BookID= BG.BookID,
                TagID= BG.TagID,
            };
            db.BookTag.Add(BookTag);
            db.SaveChanges();
            return Ok("Tag added to the book!");
        }

        [HttpDelete]
        public ActionResult DeleteBookTag([FromForm] BookTagVM Bg)
        {
            var BookTag = db.BookTag.FirstOrDefault(BG => BG.BookID == Bg.BookID && BG.TagID == Bg.TagID);

            db.BookTag.Remove(BookTag);
            db.SaveChanges();
            return Ok($"Succesfuly removed from the database!");
        }
    }
}
