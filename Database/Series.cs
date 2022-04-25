using System;
using System.Collections.Generic;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class Series
    {
        public Series()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
