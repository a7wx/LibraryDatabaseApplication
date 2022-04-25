using System;
using System.Collections.Generic;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class Order
    {
        public long OrderNumber { get; set; }
        public long UserId { get; set; }
        public long LibrarianId { get; set; }
        public long BookId { get; set; }
        public string CheckoutDate { get; set; }
        public string ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Librarian Librarian { get; set; }
        public virtual User User { get; set; }
    }
}
