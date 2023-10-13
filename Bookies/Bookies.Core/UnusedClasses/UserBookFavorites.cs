using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BookClasses;

namespace Bookies.Core.UnusedClasses
{
    public class UserBookFavorites
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
