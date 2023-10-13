using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BasicClasses;
using Bookies.Core.PersonClasses;

namespace Bookies.Core.BookClasses
{
    public class BookStaff
    {
        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int BookID { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }
        public int PersonID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }
        public int RoleID { get; set; }
    }
}
