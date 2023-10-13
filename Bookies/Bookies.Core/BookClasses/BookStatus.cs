using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BookClasses
{
    public class BookStatus
    {
        [Key]
        public int BookStatusId { get; set; }
        public string BookStatusName { get; set; }
    }
}
