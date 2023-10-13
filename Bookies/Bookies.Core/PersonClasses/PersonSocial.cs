using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookies.Core.BasicClasses;

namespace Bookies.Core.PersonClasses
{
    public class PersonSocial
    {
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
        public int PersonID { get; set; }

        [ForeignKey("SocialMediaID")]
        public virtual SocialMedia SocialMedia { get; set; }
        public int SocialMediaID { get; set; }
        public int Count { get; set; }
        public string URL { get; set; }
    }
}
