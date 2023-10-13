using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.UnusedClasses
{
    public class ListStatus
    {
        [Key]
        public int ListStatusId { get; set; }
        public string ListStatusName { get; set; }
    }
}
