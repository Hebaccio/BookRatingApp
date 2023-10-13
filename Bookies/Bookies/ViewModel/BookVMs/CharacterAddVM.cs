using Bookies.Core;

namespace Bookies.API.ViewModel.BookVMs
{
    public class CharacterAddVM
    {
        public string Name { get; set; }
        public string? Picture { get; set; }
        public string About { get; set; }
        public int? Age { get; set; }
    }
}
