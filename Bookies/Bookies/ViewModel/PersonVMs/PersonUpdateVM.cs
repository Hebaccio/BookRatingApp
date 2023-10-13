using Bookies.Core;

namespace Bookies.API.ViewModel.PersonVMs
{
    public class PersonUpdateVM
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime Birthday { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
