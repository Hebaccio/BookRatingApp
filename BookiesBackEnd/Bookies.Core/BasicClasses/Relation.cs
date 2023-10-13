using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BasicClasses
{
    public class Relation
    {
        [Key]
        public int RelationID { get; set; }
        public string RelationName { get; set; }
        public int RelationOrder { get; set; }
    }
}
