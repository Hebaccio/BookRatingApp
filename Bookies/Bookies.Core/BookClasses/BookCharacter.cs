using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BookClasses
{
    public class BookCharacter
    {
        [ForeignKey("BookID")]
        public Book Book { get; set; }
        public int BookID { get; set; }

        [ForeignKey("CharacterID")]
        public Character Character { get; set; }
        public int CharacterID { get; set; }

    }
}
