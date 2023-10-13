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
    public class BookGenre
    {
        [ForeignKey("GenreID")]
        public Genre Genre { get; set; }
        public int GenreID { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int BookID { get; set; }
    }
}
