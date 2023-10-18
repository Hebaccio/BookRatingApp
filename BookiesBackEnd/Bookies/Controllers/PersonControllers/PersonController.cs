using Bookies.API.ViewModel.BasicVMs;
using Bookies.API.ViewModel.PersonVMs;
using Bookies.Core.PersonClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookies.API.Controllers.PersonController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly BookiesContext db;

        public PersonController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Person> GetAllPeople()
        {
            var Person = db.Person.OrderBy(P => P.Name).ToList();
            return Person;
        }

        [HttpGet("{PersonID}")]
        public Person GetPerson(int PersonID)
        {
            var Person = db.Person.FirstOrDefault(p => p.PersonID == PersonID);
            return Person;
        }

        [HttpPost]
        public ActionResult AddPerson([FromBody] PersonAddVM P)
        {
            var Person = new Person()
            {
                Name = P.Name,
                Picture = P.Picture == null ? "https://i.pinimg.com/474x/5b/8f/3d/5b8f3d9f30460aeedbe6a235e2d001d3.jpg" : P.Picture,
                Birthday = P.Birthday,
                Bio = P.Bio,
                Website = P.Website,
            };

            db.Person.Add(Person);
            db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public ActionResult Update([FromForm] PersonUpdateVM P)
        {
            var Person = db.Person.FirstOrDefault(Person => Person.PersonID == P.PersonID);

            if (Person == null)
            {
                return BadRequest($"{P.Name} not found!");
            }

            Person.Name = P.Name;
            Person.Picture = P.Picture;
            Person.Birthday = P.Birthday;
            Person.Bio = P.Bio;
            Person.Website = P.Website;

            db.Person.Update(Person);
            db.SaveChanges();
            return Ok($"{Person.Name} succesfully updated!");
        }

        [HttpDelete("{PersonID}")]
        public ActionResult Delete(int PersonID)
        {
            var Person = db.Person.FirstOrDefault(G => G.PersonID == PersonID);

            if (Person == null)
            {
                return BadRequest($"{Person.Name} not found!");
            }

            db.Person.Remove(Person);
            db.SaveChanges();
            return Ok($"{Person.Name} succesfuly removed from the database!");
        }

    }
}
