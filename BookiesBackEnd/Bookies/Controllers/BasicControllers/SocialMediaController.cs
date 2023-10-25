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
        public ActionResult Add([FromBody] SocialMediaAddVM SM)
        {
            if(SM.SocialMediaName=="" || SM.Picture == "")
            {
                return BadRequest();
            }

            var SocialMedia = new SocialMedia();

            SocialMedia.SocialMediaName = SM.SocialMediaName;
            SocialMedia.Picture = SM.Picture;

            db.SocialMedia.Add(SocialMedia);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Update([FromBody] SocialMediaUpdateVM SM)
        {
            var SocialMedia = db.SocialMedia.FirstOrDefault(Social=> Social.ID == SM.ID);

            if (SocialMedia == null)
            {
                return BadRequest();
            }

            SocialMedia.SocialMediaName = SM.SocialMediaName;
            SocialMedia.Picture= SM.Picture;

            db.SocialMedia.Update(SocialMedia);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var SocialMedia = db.SocialMedia.FirstOrDefault(SM => SM.ID == id);

            if(SocialMedia == null)
            {
                return BadRequest();
            }

            db.SocialMedia.Remove(SocialMedia);
            db.SaveChanges();
            return Ok();
        }
    }
}
