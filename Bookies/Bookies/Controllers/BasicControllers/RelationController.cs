using Bookies.API.ViewModel.BasicVMs;
using Bookies.Core.BasicClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookies.API.Controllers.BasicControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RelationController : Controller
    {
        private readonly BookiesContext db;

        public RelationController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Relation> GetAllRelations()
        {
            var Relation = db.Relation.OrderBy(r => r.RelationOrder).ToList();
            return Relation;
        }

        [HttpPost]
        public ActionResult Add([FromForm] RelationAddVM R)
        {

            var Relation = new Relation();
            Relation.RelationName = R.RelationName;
            Relation.RelationOrder = R.RelationOrder;

            foreach (var Relation2 in db.Relation.ToList())
            {
                if (Relation2.RelationOrder >= Relation.RelationOrder)
                {
                    Relation2.RelationOrder++;
                }
            }

            db.Relation.Add(Relation);
            db.SaveChanges();
            return Ok($"Relation {Relation.RelationName} succesfully added!");
        }

        [HttpPost]
        public ActionResult Update([FromForm] RelationUpdateVM R)
        {
            var Relation = db.Relation.FirstOrDefault(Relation => Relation.RelationID == R.RelationID);

            if (Relation == null)
            {
                return BadRequest("Relation not found!");
            }

            if (R.RelationOrder > Relation.RelationOrder)
            {
                OrderUpdate1(R, Relation, db.Relation.ToList());
            }
            else
            {
                OrderUpdate2(R, Relation, db.Relation.ToList());
            }

            Relation.RelationName = R.RelationName;
            Relation.RelationOrder = R.RelationOrder;

            db.Relation.Update(Relation);
            db.SaveChanges();
            return Ok($"Relation {Relation.RelationName} succesfully updated!");
        }

        [HttpDelete("{RelationID}")]
        public ActionResult Delete(int RelationID)
        {
            var Relation = db.Relation.FirstOrDefault(R => R.RelationID == RelationID);

            if (Relation == null)
            {
                return BadRequest("Relation not found!");
            }

            db.Relation.Remove(Relation);
            db.SaveChanges();
            Order(db.Relation.ToList());

            return Ok($"Relation {Relation.RelationName} succesfuly removed!");
        }

        private void Order(List<Relation> Relations)
        {
            int i = 0;
            foreach (Relation Relation in Relations.OrderBy(R => R.RelationOrder).ToList())
            {
                Relation.RelationOrder = i++;
            }
            db.SaveChanges();
        }
        private void OrderUpdate1(RelationUpdateVM R, Relation Relation, List<Relation> Relations)
        {
            foreach (var Relation2 in Relations)
            {
                if (Relation2.RelationOrder > Relation.RelationOrder && Relation2.RelationOrder <= R.RelationOrder)
                {
                    Relation2.RelationOrder--;
                }
            }
        }
        private void OrderUpdate2(RelationUpdateVM R, Relation Relation, List<Relation> Relations)
        {
            foreach (var Relation2 in Relations)
            {
                if (Relation2.RelationOrder < Relation.RelationOrder && Relation2.RelationOrder >= R.RelationOrder)
                {
                    Relation2.RelationOrder++;
                }
            }

        }

    }
}
