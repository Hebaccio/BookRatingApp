using Bookies.API.ViewModel.BasicVMs;
using Bookies.Core.BasicClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookies.API.Controllers.BasicController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenreController : ControllerBase
    {
        private readonly BookiesContext db;

        public GenreController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Genre> GetAllGenre()
        {
            var Genre = db.Genre.OrderBy(G=>G.GenreName).ToList();
            return Genre;
        }

        [HttpPost]
        public ActionResult AddGenre([FromBody] GenreTagAddVM G)
        {
            var NewGenre = new Genre();
            NewGenre.GenreName = G.Name;
            NewGenre.GenreDescription = G.Description;

            db.Genre.Add(NewGenre);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Update([FromBody] GenreTagUpdateVM G)
        {
            var Genre = db.Genre.FirstOrDefault(Gen => Gen.GenreID == G.ID);

            if (Genre == null)
            {
                return BadRequest();
            }

            Genre.GenreName = G.Name;
            Genre.GenreDescription = G.Description;

            db.Genre.Update(Genre);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{GenreID}")]
        public ActionResult Delete(int GenreID)
        {
            var Genre = db.Genre.FirstOrDefault(G => G.GenreID == GenreID);

            if (Genre == null)
            {
                return BadRequest();
            }

            db.Genre.Remove(Genre);
            db.SaveChanges();
            return Ok();
        }
    }
}
