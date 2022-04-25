using System;
using System.Collections.Generic;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Genre1 { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
