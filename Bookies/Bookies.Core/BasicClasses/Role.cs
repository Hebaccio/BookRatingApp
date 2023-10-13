using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BasicClasses
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int Order { get; set; }
    }
}
