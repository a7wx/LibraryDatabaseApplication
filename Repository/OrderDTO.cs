namespace LibraryApplication.Repository
#nullable disable
{
    public class OrderDTO : BaseDTO
    {
        private long _OrderNumber;
        private long _UserId;
        private long _LibrarianId;
        private long _BookId;
        private string _CheckoutDate;
        private string _ReturnDate;
        private string _Librarian;
        private string _User;
        private string _Book;

        public long OrderNumber
        {
            get { return _OrderNumber; }
            set { SetField(ref _OrderNumber, value); }
        }

        public long UserId
        {
            get { return _UserId; }
            set { SetField(ref _UserId, value); }
        }

        public long LibrarianId
        {
            get { return _LibrarianId; }
            set { SetField(ref _LibrarianId, value); }
        }

        public long BookId
        {
            get { return _BookId; }
            set { SetField(ref _BookId, value); }
        }

        public string CheckoutDate
        {
            get { return _CheckoutDate; }
            set { SetField(ref _CheckoutDate, value); }
        }

        public string ReturnDate
        {
            get { return _ReturnDate; }
            set { SetField(ref _ReturnDate, value); }
        }
        public string Librarian
        {
            get { return _Librarian; }
            set { SetField(ref _Librarian, value); }
        }
        public string User
        {
            get { return _User; }
            set { SetField(ref _User, value); }
        }
        public string Book
        {
            get { return _Book; }
            set { SetField(ref _Book, value); }
        }
        public override string ToString()
        {
            return "Order nuber: " + _OrderNumber + " BookId: " + _BookId  + " User: " + _UserId;
        }

    }
}
