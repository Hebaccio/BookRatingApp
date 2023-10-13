using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.UnusedClasses
{
    public class Series
    {
        [Key]
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public string SeriesDescription { get; set; }
        public string? SeriesNotes { get; set; }

        [ForeignKey("FictionalUniverseID")]
        public virtual FictionalUniverse Universe { get; set; }
        public int UniverseID { get; set; }
    }
}
