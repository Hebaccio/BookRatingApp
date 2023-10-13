using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BasicClasses;

namespace Bookies.Core.BookClasses
{
    public class BookTag
    {
        [ForeignKey("TagID")]
        public Tag Tag { get; set; }
        public int TagID { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int BookID { get; set; }
    }
}
