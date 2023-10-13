using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BookClasses;

namespace Bookies.Core.UnusedClasses
{
    public class BookSeries
    {
        [ForeignKey("SeriesID")]
        public Series Series { get; set; }
        public int SeriesID { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int BookID { get; set; }
    }
}
