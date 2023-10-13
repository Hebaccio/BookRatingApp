using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookies.Core.BasicClasses
{
    public class SocialMedia
    {
        [Key]
        public int ID { get; set; }
        public string SocialMediaName { get; set; }
        public string Picture { get; set; }
    }
}
