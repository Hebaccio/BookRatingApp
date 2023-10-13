using Bookies.API.ViewModel.BookVMs;
using Bookies.API.ViewModel.BookVMs;
using Bookies.API.ViewModel.PersonVMs;
using Bookies.Core.BookClasses;
using Bookies.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookies.API.Controllers.BookControllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookStaffController : ControllerBase
    {
        private readonly BookiesContext db;

        public BookStaffController(BookiesContext db)
        {
            this.db = db;
        }

        [HttpGet("{BookID}")]
        public List<BookStaffGetVM> GetBookStaff(int BookID)
        {
            var Staff = db.BookStaff
                 .Include(BS => BS.Book)
                 .Include(BS => BS.Person)
                 .Include(BS => BS.Role)
                 .Where(BS => BS.BookID == BookID)
                 .OrderBy(BS=> BS.Role.Order)
                 .Select(BS => new BookStaffGetVM()
                 {
                     PersonID = BS.PersonID,
                     PersonName = BS.Person.Name,
                     PersonRole = BS.Role.RoleName
                 }).ToList();

            return Staff;
        }

        [HttpPost]
        public ActionResult AddBookStaff([FromForm] BookStaffVM Bs)
        {
            var BookStaff = new BookStaff()
            {
                BookID= Bs.BookID,
                PersonID=Bs.PersonID,
                RoleID = Bs.RoleID
            };

            db.BookStaff.Add(BookStaff);
            db.SaveChanges();
            return Ok($"Relations added to the database!");
        }

        [HttpDelete]
        public ActionResult DeleteBookStaffMember([FromForm] BookStaffVM Bs)
        {
            var BookStaff = db.BookStaff.FirstOrDefault(BS=> BS.BookID == Bs.BookID && BS.PersonID==Bs.PersonID && BS.RoleID==Bs.RoleID);

            db.BookStaff.Remove(BookStaff);
            db.SaveChanges();

            return Ok($"Succesfully removed!");
        }
    }
}
