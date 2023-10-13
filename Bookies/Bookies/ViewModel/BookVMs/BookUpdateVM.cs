using Bookies.Core;

namespace Bookies.API.ViewModel.BookVMs
{
    public class BookUpdateVM
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
        public float Rating { get; set; }
    }
}
