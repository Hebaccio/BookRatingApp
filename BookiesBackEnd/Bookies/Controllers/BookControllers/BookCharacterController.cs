using Bookies.API.ViewModel.BookVMs;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookies.API.Controllers.BookControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookCharacterController : Controller
    {
        private readonly BookiesContext db;

        public BookCharacterController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Character> GetCharacters(int BookID)
        {
            var BookCharacters = db.BookCharacter
                .Include(x => x.Character)
                .Where(BC => BC.BookID == BookID || BookID == null)
                .Select(BC=> BC.Character)
                .ToList();

            return BookCharacters;
        }

        [HttpPost]
        public ActionResult AddBookCharacter(int BookID, int CharacterID)
        {
            var BookCharacter = new BookCharacter()
            {
                BookID = BookID,
                CharacterID = CharacterID
            };

            db.BookCharacter.Add(BookCharacter);
            db.SaveChanges();
            return Ok("Character succesfully added to the book");
        }

        [HttpDelete]
        public ActionResult DeleteCharacter(int BookID, int CharacterID)
        {
            var BookCharacter = db.BookCharacter
                .FirstOrDefault(C => C.CharacterID == CharacterID && C.BookID==BookID);

            db.BookCharacter.Remove(BookCharacter);
            db.SaveChanges();

            return Ok("Character succesfully removed from the book");
        }

    }
}
