using System;
using System.Collections.Generic;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class Librarian
    {
        public Librarian()
        {
            Orders = new HashSet<Order>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
