using Bookies.API.ViewModel.BasicVMs;
using Bookies.Core.BasicClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookies.API.Controllers.BasicController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TagController : ControllerBase
    {
        private readonly BookiesContext db;

        public TagController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Tag> GetAllTags()
        {
            var Tag = db.Tag.OrderBy(T=>T.TagName).ToList();
            return Tag;
        }

        [HttpPost]
        public ActionResult AddTag([FromForm] GenreTagAddVM T)
        {
            var NewTag = new Tag();
            NewTag.TagName = T.Name;
            NewTag.TagDescription = T.Description;

            db.Tag.Add(NewTag);
            db.SaveChanges();
            return Ok($"{NewTag.TagName} succesfully added to the database!");
        }

        [HttpPost]
        public ActionResult Update([FromForm] GenreTagUpdateVM T)
        {
            var Tag = db.Tag.FirstOrDefault(Tag => Tag.TagID == T.ID);

            if (Tag == null)
            {
                return BadRequest("Tag not found!");
            }

            Tag.TagName = T.Name;
            Tag.TagDescription = T.Description;

            db.Tag.Update(Tag);
            db.SaveChanges();
            return Ok($"{Tag.TagName} tag succesfully updated!");
        }

        [HttpDelete("{TagID}")]
        public ActionResult Delete(int TagID)
        {
            var Tag = db.Tag.FirstOrDefault(G => G.TagID == TagID);

            if (Tag == null)
            {
                return BadRequest("Tag not found!");
            }

            db.Tag.Remove(Tag);
            db.SaveChanges();
            return Ok($"Tag {Tag.TagName} succesfuly removed!");
        }
    }
}
