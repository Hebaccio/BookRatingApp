using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BookClasses
{
    public class BookRecs
    {
        [ForeignKey("Book1_ID")]
        public Book Book1 { get; set; }
        public int Book1_ID { get; set; }

        [ForeignKey("Book2_ID")]
        public Book Book2 { get; set; }
        public int Book2_ID { get; set; }

        public int Total { get; set; }
        public int Agree { get; set; }
        public int Disagree { get; set; }
    }
}
