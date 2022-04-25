using System;
using System.Collections.Generic;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
            Authors = new HashSet<Author>();
            Genres = new HashSet<Genre>();
        }

        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Subtitle { get; set; }
        public long Length { get; set; }
        public string Publisher { get; set; }
        public long SeriesId { get; set; }
        public long SeriesPos { get; set; }

        public virtual Series Series { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
