using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.PersonClasses
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime? Birthday { get; set; }
        public string Bio { get; set; }
        public string? Website { get; set; }
    }
}
