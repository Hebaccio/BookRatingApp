using Bookies.API.ViewModel.BookVMs;
using Bookies.API.ViewModel.PersonVMs;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookies.API.Controllers.BookControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RelatedBooksController : ControllerBase
    {
        private readonly BookiesContext db;

        public RelatedBooksController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet("{Book1ID}")]
        public List<RelatedBookGetVM> GetRelatedBooks(int Book1ID)
        {
            var Book = db.RelatedBooks
                .Include(RB => RB.Book1)
                .Include(RB => RB.Book2)
                .Include(RB => RB.Relation)
                .Where(RB => RB.Book1_ID == Book1ID)
                .OrderBy(RB => RB.Relation.RelationOrder)
                .Select(RB => new RelatedBookGetVM()
                {
                    Book2ID = RB.Book2_ID,
                    Book2Picture = RB.Book2.Picture,
                    Relation = RB.Relation.RelationName,
                }).ToList();

            return Book;
        }

        [HttpPost]
        public ActionResult AddRelatedBook([FromForm] RelatedBookVM Rb)
        {

            var RelatedBook = new RelatedBooks()
            {
                Book1_ID = Rb.Book1ID,
                Book2_ID = Rb.Book2ID,
                RelationID = Rb.RelationID,
            };

            db.RelatedBooks.Add(RelatedBook);
            db.SaveChanges();
            EstablishOtherRelation(Rb);
            return Ok($"Relation added to the database!");
        }

        [HttpDelete]
        public ActionResult DeleteRelatedBook([FromForm] RelatedBookVM Rb)
        {

            var RelatedBook = new RelatedBooks()
            {
                Book1_ID = Rb.Book1ID,
                Book2_ID = Rb.Book2ID,
                RelationID = Rb.RelationID,
            };

            db.RelatedBooks.Remove(RelatedBook);
            db.SaveChanges();
            DeleteOtherRelation(Rb);
            return Ok($"Relation removed to the database!");
        }

        private void EstablishOtherRelation(RelatedBookVM Rb)
        {
            var Relation = RelationSwap(Rb.RelationID);

            var RelatedBook = new RelatedBooks()
            {
                Book1_ID = Rb.Book2ID,
                Book2_ID = Rb.Book1ID,
                RelationID = Relation,
            };

            db.RelatedBooks.Add(RelatedBook);
            db.SaveChanges();
        }
        private void DeleteOtherRelation(RelatedBookVM Rb)
        {
            var Relation = RelationSwap(Rb.RelationID);

            var RelatedBook = new RelatedBooks()
            {
                Book1_ID = Rb.Book2ID,
                Book2_ID = Rb.Book1ID,
                RelationID = Relation,
            };

            db.RelatedBooks.Remove(RelatedBook);
            db.SaveChanges();
        }
        private int RelationSwap(int RelationID)
        {
            if (RelationID == 1)
                return 2;
            else if (RelationID == 2)
                return 1;
            else return RelationID;
        }
    }
}
