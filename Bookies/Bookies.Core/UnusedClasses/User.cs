using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.UnusedClasses
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime PasswordCreatedAt { get; set; }
        public string Picture { get; set; }
        public string Bio { get; set; }
        public bool IsAdmin { get; set; }
    }
}
