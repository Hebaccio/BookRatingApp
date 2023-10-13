using Bookies.API.ViewModel.PersonVMs;
using Bookies.Core;
using Bookies.Core.PersonClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bookies.API.Controllers.PersonController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonSocialController : ControllerBase
    {
        private readonly BookiesContext db;

        public PersonSocialController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet("{PersonID}")]
        public List<PersonSocialGetVM> GetPersonSocialMedia(int PersonID)
        {
            var SocialMedia = db.PersonSocial
                .Include(PS=>PS.Person)
                .Include(PS=>PS.SocialMedia)
                .Where(PS => PS.PersonID == PersonID)
                .Select(PS => new PersonSocialGetVM()
                {
                    Picture = PS.SocialMedia.Picture,
                    URL = PS.URL,
                    Count=PS.Count
                    
                }).ToList();

            return SocialMedia;
        }

        [HttpPost]
        public ActionResult AddPersonSocialMedia([FromForm] PersonSocialAddVM Ps)
        {
            var Counted = db.PersonSocial.Where(PS => PS.PersonID == Ps.PersonID && PS.SocialMediaID == Ps.SocialID).Count() + 1;
            var PersonSocial = new PersonSocial()
            {
                PersonID = Ps.PersonID,
                SocialMediaID = Ps.SocialID,
                Count = Counted,
                URL = Ps.URL
            };
            
            db.PersonSocial.Add(PersonSocial);
            db.SaveChanges();
            return Ok("Social meddia added!");
        }

        [HttpPost]
        public ActionResult UpdatePersonSocialMedia([FromForm] PersonSocialAddVM PS)
        {
            var Updated = db.PersonSocial
                .Include(PS => PS.Person)
                .Include(PS => PS.SocialMedia)
                .FirstOrDefault(PSQ => PSQ.PersonID == PS.PersonID && PSQ.SocialMediaID == PS.SocialID);

            Updated.URL = PS.URL;

            string SocialMediaName = Updated.SocialMedia.SocialMediaName;
            string PersonName = Updated.Person.Name;

            db.PersonSocial.Update(Updated);
            db.SaveChanges();
            return Ok($"{SocialMediaName} succesfully updated for {PersonName}");
        }

        [HttpDelete]
        public ActionResult DeletePersonSocialMedia([FromForm] PersonSocialDeleteVM PS)
        {
            var PersonSocial = db.PersonSocial
                .Include(PS => PS.Person)
                .Include(PS => PS.SocialMedia)
                .FirstOrDefault(PSQ => PSQ.PersonID == PS.PersonID && PSQ.SocialMediaID == PS.SocialID && PSQ.Count == PS.Count);


            db.PersonSocial.Remove(PersonSocial);
            db.SaveChanges();

            string SocialMediaName = PersonSocial.SocialMedia.SocialMediaName;
            string PersonName = PersonSocial.Person.Name;

            return Ok($"{SocialMediaName} succesfully removed from {PersonName}");
        }
    }
}
