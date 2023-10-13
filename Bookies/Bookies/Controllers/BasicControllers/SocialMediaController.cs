using Bookies.API.ViewModel.BasicVMs;
using Bookies.Core.BasicClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Bookies.API.Controllers.BasicController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SocialMediaController : ControllerBase
    {
        private readonly BookiesContext db;

        public SocialMediaController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<SocialMedia> GetAll()
        {
            var SocialMedia = db.SocialMedia.OrderBy(SM=>SM.SocialMediaName).ToList();
            return SocialMedia;
        }

        [HttpPost]
        public ActionResult Add([FromForm] SocialMediaAddVM SM)
        {
            var SocialMedia = new SocialMedia();

            SocialMedia.SocialMediaName = SM.SocialMediaName;
            SocialMedia.Picture = SM.Picture;

            db.SocialMedia.Add(SocialMedia);
            db.SaveChanges();
            return Ok($"New social media {SocialMedia.SocialMediaName} succesfully added!");
        }

        [HttpPost]
        public ActionResult Update([FromForm] SocialMediaUpdateVM SM)
        {
            var SocialMedia = db.SocialMedia.FirstOrDefault(Social=> Social.ID == SM.SocialMediaID);

            if (SocialMedia == null)
            {
                return BadRequest("Social media not found!");
            }

            SocialMedia.SocialMediaName = SM.SocialMediaName;
            SocialMedia.Picture= SM.Picture;

            db.SocialMedia.Update(SocialMedia);
            db.SaveChanges();
            return Ok($"Social media {SocialMedia.SocialMediaName} succesfully updated!");
        }

        [HttpDelete("{SocialMediaID}")]
        public ActionResult Delete(int SocialMediaID)
        {
            var SocialMedia = db.SocialMedia.FirstOrDefault(SM => SM.ID == SocialMediaID);

            if(SocialMedia == null)
            {
                return BadRequest("Social media not found!");
            }

            db.SocialMedia.Remove(SocialMedia);
            db.SaveChanges();
            return Ok("Social media succesfuly removed!");
        }
    }
}
