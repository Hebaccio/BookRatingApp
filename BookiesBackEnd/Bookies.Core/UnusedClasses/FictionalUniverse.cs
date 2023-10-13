using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.UnusedClasses
{
    public class FictionalUniverse
    {
        [Key]
        public int UniverseID { get; set; }
        public string UniverseName { get; set; }
        public string UniverseDescription { get; set; }
        public string? UniverseNotes { get; set; }
    }
}
