using Bookies.API.ViewModel.BookVMs;
using Bookies.API.ViewModel.BookVMs;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookies.API.Controllers.BookControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly BookiesContext db;

        public BookController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet("{BookID}")]
        public Book GetBook(int BookID)
        {
            var Book = db.Book.FirstOrDefault(p => p.BookID == BookID);

            return Book;
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] BookAddVM B)
        {
            var Book = new Book()
            {
                Title = B.Title,
                Picture = B.Picture == null ? "https://i.pinimg.com/originals/d8/ef/e1/d8efe15e9b9bb57f7dfc489746e2de7d.jpg" : B.Picture,
                Description = B.Description,
                BookStatus = B.StatusName,
                PublishDate = B.PublishDate,
                PageCount = B.PageCount,
                Rating = 0
            };

            db.Book.Add(Book);
            db.SaveChanges();

            return Ok($"{Book.Title} succesfully added to the database!");
        }

        [HttpPost]
        public ActionResult Update([FromForm] BookUpdateVM B)
        {
            var Book = db.Book.FirstOrDefault(Book => Book.BookID == B.BookID);

            if (Book == null)
            {
                return BadRequest($"{B.Title} not found!");
            }

            Book.Title = B.Title;
            Book.Picture = B.Picture;
            Book.Description = B.Description;
            Book.BookStatus = B.StatusName;
            Book.PublishDate = B.PublishDate;
            Book.PageCount = B.PageCount;
            Book.Rating = B.Rating;

            db.Book.Update(Book);
            db.SaveChanges();
            return Ok($"{Book.Title} succesfully updated!");
        }

        [HttpDelete("{BookID}")]
        public ActionResult Delete(int BookID)
        {
            var Book = db.Book.FirstOrDefault(G => G.BookID == BookID);

            if (Book == null)
            {
                return BadRequest($"{Book.Title} not found!");
            }

            db.Book.Remove(Book);
            db.SaveChanges();
            return Ok($"{Book.Title} succesfuly removed from the database!");
        }
    }
}
