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
    public class RelatedBooks
    {
        [ForeignKey("Book1_ID")]
        public Book Book1 { get; set; }
        public int Book1_ID { get; set; }

        [ForeignKey("Book2_ID")]
        public Book Book2 { get; set; }
        public int Book2_ID { get; set; }

        [ForeignKey("RelationID")]
        public Relation Relation { get; set; }
        public int RelationID { get; set; }
    }
}
