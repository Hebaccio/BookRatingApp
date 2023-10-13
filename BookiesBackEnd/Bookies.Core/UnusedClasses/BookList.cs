using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BookClasses;

namespace Bookies.Core.UnusedClasses
{
    public class BookList
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ListId")]
        public List List { get; set; }
        public int ListId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("ListStatusId")]
        public ListStatus ListStatus { get; set; }
        public int ListStatusId { get; set; }

        public string Review { get; set; }
        public float Rating { get; set; }
    }
}
