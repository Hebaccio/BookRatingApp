using Bookies.Repository;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Bookies.Core.BasicClasses;
using Microsoft.EntityFrameworkCore;
using Bookies.API.ViewModel.BookVMs;

namespace Genreies.API.Controllers.GenreControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookGenreController : Controller
    {
        private readonly BookiesContext db;

        public BookGenreController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<BookGenreShowVM> GetBookGenre(int BookID)
        {
            var Genre = db.BookGenre
                .Include(x => x.Genre)
                .OrderBy(BG => BG.Genre.GenreName)
                .Where(BG => BG.BookID == BookID)
                .Select(BG=>new BookGenreShowVM()
                {
                    GenreID = BG.GenreID,
                    GenreName=BG.Genre.GenreName,
                }).ToList();

            return Genre;
        }

        [HttpPost]
        public ActionResult AddBookGenre([FromForm] BookGenreVM BG)
        {
            var BookGenre = new BookGenre()
            {
                BookID= BG.BookID,
                GenreID= BG.GenreID,
            };
            db.BookGenre.Add(BookGenre);
            db.SaveChanges();
            return Ok("Genre added to the book!");
        }

        [HttpDelete]
        public ActionResult DeleteBookGenre([FromForm] BookGenreVM Bg)
        {
            var BookGenre = db.BookGenre.FirstOrDefault(BG => BG.BookID == Bg.BookID && BG.GenreID == Bg.GenreID);

            db.BookGenre.Remove(BookGenre);
            db.SaveChanges();
            return Ok($"Succesfuly removed from the database!");
        }
    }
}
