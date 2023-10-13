using Bookies.API.ViewModel.BookVMs;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookies.API.Controllers.BookControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CharacterController : Controller
    {
        private readonly BookiesContext db;

        public CharacterController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Character> GetCharacters()
        {
            var Character = db.Character.OrderBy(C=> C.Name).ToList();
            return Character;
        }

        [HttpGet]
        public Character GetCharacter(int CharacterID)
        {
            var Character = db.Character.FirstOrDefault(C => C.CharacterID == CharacterID);
            return Character;
        }

        [HttpPost]
        public ActionResult AddCharacter([FromForm] CharacterAddVM C)
        {
            var Character = new Character()
            {
                Name = C.Name,
                Picture = C.Picture == null ? "https://i1.sndcdn.com/avatars-PkAmzSOLCdxklQgS-AokumA-t500x500.jpg" : C.Picture,
                About=C.About,
                Age=C.Age,
            };

            db.Character.Add(Character);
            db.SaveChanges();
            return Ok($"{C.Name} added to the database!");
        }

        [HttpPost]
        public ActionResult UpdateCharacter([FromForm] Character C)
        {
            var Character = db.Character.FirstOrDefault(Character => Character.CharacterID == C.CharacterID);

            if (Character == null)
            {
                return BadRequest($"{Character.Name} not found!");
            }
                        
            Character.Name = C.Name;
            Character.Picture = C.Picture;
            Character.About = C.About;
            Character.Age = C.Age;

            db.Character.Update(Character);
            db.SaveChanges();
            return Ok($"{Character.Name} succesfully updated!");
        }

        [HttpDelete]
        public ActionResult DeleteCharacter(int CharacterID)
        {
            var Character = db.Character.FirstOrDefault(Character => Character.CharacterID == CharacterID);

            db.Character.Remove(Character);
            db.SaveChanges();

            return Ok($"{Character.Name} succesfully removed!");
        }
    }
}
