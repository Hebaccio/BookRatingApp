using Bookies.API.ViewModel.BasicVMs;
using Bookies.Core.BasicClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bookies.API.Controllers.BasicController
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly BookiesContext db;

        public RolesController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Role> GetAllRoles()
        {
            var Role = db.Role.OrderBy(r => r.Order).ToList();
            return Role;
        }

        [HttpPost]
        public ActionResult Add([FromBody] RoleAddVM R)
        {

            var Role = new Role();
            Role.RoleName = R.RoleName;
            Role.Order = R.Order;

            foreach (var Role2 in db.Role.ToList())
            {
                if (Role2.Order >= Role.Order)
                {
                    Role2.Order++;
                }
            }

            db.Role.Add(Role);
            db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult Update([FromBody] RoleUpdateVM R)
        {
            var Role = db.Role.FirstOrDefault(ROLE=>ROLE.RoleID==R.RoleID);

            if (Role == null)
            {
                return BadRequest();
            }

            if (R.Order > Role.Order)
            {
                OrderUpdate1(R, Role, db.Role.ToList());
            }
            else
            {
                OrderUpdate2(R, Role, db.Role.ToList());
            }

            Role.RoleName = R.RoleName;
            Role.Order = R.Order;

            db.Role.Update(Role);
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{RoleID}")]
        public ActionResult Delete(int RoleID)
        {
            var Role = db.Role.FirstOrDefault(R => R.RoleID == RoleID);

            if (Role == null)
            {
                return BadRequest();
            }

            db.Role.Remove(Role);
            db.SaveChanges();
            Order(db.Role.ToList());

            return Ok();
        }

        private void Order(List<Role> Roles)
        {
            int i = 0;
            foreach (Role Role in Roles.OrderBy(R=>R.Order).ToList())
            {
                Role.Order = i++;
            }
            db.SaveChanges();
        }
        private void OrderUpdate1(RoleUpdateVM R, Role Role, List<Role> Roles)
        {
            foreach (var Role2 in Roles)
            {
                if (Role2.Order > Role.Order && Role2.Order <= R.Order)
                {
                    Role2.Order--;
                }
            }
        }
        private void OrderUpdate2(RoleUpdateVM R, Role Role, List<Role> Roles)
        {
            foreach (var Role2 in Roles)
            {
                if (Role2.Order < Role.Order && Role2.Order >= R.Order)
                {
                    Role2.Order++;
                }
            }

        }
    }
}
