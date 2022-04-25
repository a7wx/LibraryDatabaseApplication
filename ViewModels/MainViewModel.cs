using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Windows;
using LibraryApplication.Repository;
using LibraryApplication.Database;
namespace LibraryApplication.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        private BindingList<BookDTO> _Books;
        private BookDTO _SelectedBook;
        private BindingList<AuthorDTO> _Authors;
        private AuthorDTO _SelectedAuthor;
        private BindingList<GenreDTO> _Genres;
        private GenreDTO _SelectedGenre;
        private BindingList<UserDTO> _Users;
        private UserDTO _SelectedUser;
        private BindingList<LibrarianDTO> _Librarians;
        private LibrarianDTO _SelectedLibrarian;
        private BindingList<OrderDTO> _Orders;
        private OrderDTO _SelectedOrder;
        private BindingList<SeriesDTO> _Series;
        private SeriesDTO _SelectedSeries;
        #endregion

        #region Public Properties

        #region Books
        public BindingList<BookDTO> Books
        {
            get { return _Books; }
            set
            {
                SetField<BindingList<BookDTO>>(ref _Books, value);
                SelectedBook = Books != null && Books.Count > 0 ? Books[0] : null;
            }
        }

        public BookDTO SelectedBook
        {
            get { return _SelectedBook;  }
            set
            {
                SetField<BookDTO>(ref _SelectedBook, value);
                if (_SelectedBook != null)
                {

                }
            }
        }
        #endregion

        #region Authors
        public BindingList<AuthorDTO> Authors
        {
            get { return _Authors; }
            set
            {
                SetField<BindingList<AuthorDTO>>(ref _Authors, value);
                SelectedAuthor = Authors != null && Authors.Count > 0 ? Authors[0] : null;
            }
        }
        public AuthorDTO SelectedAuthor
        {
            get { return _SelectedAuthor; }
            set 
            { SetField<AuthorDTO>(ref _SelectedAuthor, value); 
            if (_SelectedAuthor != null)
                {

                }
            }  
        }

        #endregion

        #region Genres

        public BindingList<GenreDTO> Genres
        {
            get { return _Genres; }
            set
            {
                SetField<BindingList<GenreDTO>>(ref _Genres, value);
                SelectedGenre = Genres != null && Genres.Count > 0 ? Genres[0] : null;
            }
        }

        public GenreDTO SelectedGenre
        {
            get { return _SelectedGenre; }
            set
            {
                SetField<GenreDTO>(ref _SelectedGenre, value);
                if (_SelectedGenre != null)
                {

                }
            }
        }

        #endregion

        #region Users

        public BindingList<UserDTO> Users
        {
            get { return _Users; }
            set
            {
                SetField<BindingList<UserDTO>>(ref _Users, value);
                SelectedUser = Users != null && Users.Count > 0 ? Users[0] : null;
            }
        }

        public UserDTO SelectedUser
        {
            get { return _SelectedUser; }
            set
            {
                SetField<UserDTO>(ref _SelectedUser, value);
                if (_SelectedUser != null)
                {

                }
            }
        }
        #endregion

        #region Orders

        public BindingList<OrderDTO> Orders
        {
            get { return _Orders; }
            set
            {
                SetField<BindingList<OrderDTO>>(ref _Orders, value);
                SelectedOrder = Orders != null && Orders.Count > 0 ? Orders[0] : null;
            }
        }

        public OrderDTO SelectedOrder
        {
            get { return _SelectedOrder; }
            set
            {
                SetField<OrderDTO>(ref _SelectedOrder, value);
                if (_SelectedOrder != null)
                {

                }
            }
        }
        #endregion

        #region Librarians

        public BindingList<LibrarianDTO> Librarians
        {
            get { return _Librarians; }
            set
            {
                SetField<BindingList<LibrarianDTO>>(ref _Librarians, value);
                SelectedLibrarian = Librarians != null && Librarians.Count > 0 ? Librarians[0] : null;
            }
        }

        public LibrarianDTO SelectedLibrarian
        {
            get { return _SelectedLibrarian; }
            set
            {
                SetField<LibrarianDTO>(ref _SelectedLibrarian, value);
                if (_SelectedLibrarian != null)
                {

                }
            }
        }
        #endregion

        #region Series
        public BindingList<SeriesDTO> Series
        {
            get { return _Series; }
            set
            {
                SetField<BindingList<SeriesDTO>>(ref _Series, value);
                SelectedSeries = Series != null && Series.Count > 0 ? Series[0] : null;
            }
        }

        public SeriesDTO SelectedSeries
        {
            get { return _SelectedSeries; }
            set
            {
                SetField<SeriesDTO>(ref _SelectedSeries, value);
                if (SelectedSeries != null)
                {

                }
            }
        }
        #endregion

        #region Delegate Commands

        #region Create
        public DelegateCommand<object> NewAuthorCommand { get; set; }
        public DelegateCommand<object> NewBookCommand { get; set; }
        public DelegateCommand<object> NewOrderCommand { get; set; }
        public DelegateCommand<object> NewSeriesCommand { get; set; }
        public DelegateCommand<object> NewGenreCommand { get; set; }
        public DelegateCommand<object> NewUserCommand { get; set; }
        public DelegateCommand<object> NewLibrarianCommand { get; set; }
        #endregion

        #region update
        public DelegateCommand<object> EditAuthorCommand { get; set; }
        public DelegateCommand<object> EditBookCommand { get; set; }
        public DelegateCommand<object> EditOrderCommand { get; set; }
        public DelegateCommand<object> EditSeriesCommand { get; set; }
        public DelegateCommand<object> EditGenreCommand { get; set; }
        public DelegateCommand<object> EditUserCommand { get; set; }
        public DelegateCommand<object> EditLibrarianCommand { get; set; }
        #endregion

        #region Delete
        public DelegateCommand<object> DeleteAuthorCommand { get; set; }
        public DelegateCommand<object> DeleteBookCommand { get; set; }
        public DelegateCommand<object> DeleteSeriesCommand { get; set; }
        #endregion
        #endregion
        #endregion
        #region Constructor

        public MainViewModel()
        {
            Books = LibraryRepository.GetBooks();
            SelectedBook = Books[0];

            Authors = LibraryRepository.GetAuthors();
            SelectedAuthor = Authors[0];

            Genres = LibraryRepository.GetGenres();
            SelectedGenre = Genres[0];

            Orders = LibraryRepository.GetOrders();
            SelectedOrder = Orders[0];

            Series = LibraryRepository.GetSeries();
            SelectedSeries = Series[0];
            
            Users = LibraryRepository.GetUsers();
            SelectedUser = Users[0];

            Librarians = LibraryRepository.GetLibrarians();
            SelectedLibrarian = Librarians[0];

            NewAuthorCommand = new DelegateCommand<object>(ClickNewAuthor, (object o) => true);
            NewBookCommand = new DelegateCommand<object>(ClickNewBook, (object o) => true);
            NewGenreCommand = new DelegateCommand<object>(ClickNewGenre, (object o) => true);
            NewSeriesCommand = new DelegateCommand<object>(ClickNewSeries, (object o) => true);
            NewUserCommand = new DelegateCommand<object>(ClickNewUser, (object o) => true);
            NewLibrarianCommand = new DelegateCommand<object>(ClickNewLibrarian, (object o) => true);
            NewOrderCommand = new DelegateCommand<object>(ClickNewOrder, (object o) => true);

            EditAuthorCommand = new DelegateCommand<object>(ClickEditAuthor, (object o) => true);
            EditSeriesCommand = new DelegateCommand<object>(ClickEditSeries, (object o) => true);
            EditGenreCommand = new DelegateCommand<object> (ClickEditGenre, (object o) => true);
            EditUserCommand = new DelegateCommand<object>(ClickEditUser, (object o) => true);
            EditLibrarianCommand = new DelegateCommand<object>(ClickEditLibrarian, (object o) => true);
            EditOrderCommand = new DelegateCommand<object>(ClickEditOrder, (object o) => true);

            DeleteBookCommand = new DelegateCommand<object>(ClickDeleteBook, (object o) => true);
            DeleteAuthorCommand = new DelegateCommand<object>(ClickDeleteAuthor, (object o) => true);
            DeleteSeriesCommand = new DelegateCommand<object>(ClickDeleteSeries, (object o) => true);
        }
        #endregion

        #region Create Functionality

        private void ClickNewAuthor(object o)
        {
            AddAuthor authorDialog = new AddAuthor();
            authorDialog.AuthorName = "";
            authorDialog.ShowDialog();
            if (authorDialog.DialogResult == true)
            {
                AuthorDTO author = new AuthorDTO()
                {
                    Name = authorDialog.AuthorName
                };
                long newId = LibraryRepository.AddAuthor(author);
                Authors = LibraryRepository.GetAuthors();
                var a = Authors.Single(s => s.Id == newId);
                if (a != null)
                    SelectedAuthor = a;
                else
                    SelectedAuthor = Authors[0];
            }
        }

        private void ClickNewBook(object o)
        {
            AddBookWindow addBookDialog = new AddBookWindow();
            addBookDialog.BookTitle = "";
            addBookDialog.BookSubtitle = "";
            addBookDialog.BookLength = "";
            addBookDialog.BookPublisher = "";
            addBookDialog.BookSeries = "";
            addBookDialog.BookSeriesPos = "";
            addBookDialog.BookGenre = "";
            addBookDialog.BookAuthor = "";
            addBookDialog.ShowDialog();
            if (addBookDialog.DialogResult == true)
            {
                var BookSeriesId = LibraryRepository.context.Series.Where(x => x.Name == addBookDialog.BookSeries).FirstOrDefault();
                var AuthorName = LibraryRepository.context.Authors.Where(x=> x.Name == addBookDialog.BookAuthor).FirstOrDefault();
                var Genre = LibraryRepository.context.Genres.Where(x => x.Genre1 == addBookDialog.BookGenre).FirstOrDefault();
                if (AuthorName != null)
                {
                    if (Genre != null)
                    {
                        if (BookSeriesId != null)
                        {
                            BookDTO book = new BookDTO()
                            {
                                Title = addBookDialog.BookTitle,
                                Subtitle = addBookDialog.BookSubtitle,
                                Length = long.Parse(addBookDialog.BookLength),
                                SeriesId = BookSeriesId.Id,
                                SeriesPos = long.Parse(addBookDialog.BookSeriesPos),
                                Publisher = addBookDialog.BookPublisher,
                                Author = addBookDialog.BookAuthor,
                                Genre = addBookDialog.BookGenre
                            };
                            long newId = LibraryRepository.AddBook(book);
                            Books = LibraryRepository.GetBooks();
                            var b = Books.Single(s => s.Id == newId);
                            if (b != null)
                                SelectedBook = b;
                            else
                                SelectedBook = Books[0];
                        }
                        else
                            MessageBox.Show("That Series Does Not Exist");
                    }
                    else
                        MessageBox.Show("You are trying to add a book to a genre that does not exist");
                }
                else
                    MessageBox.Show("That Author Does Not Exist");
            }
        }
        private void ClickNewGenre(object o)
        {
            AddGenre genreDialog = new AddGenre();
            genreDialog.GenreName = "";
            genreDialog.ShowDialog();
            if (genreDialog.DialogResult == true)
            {
                GenreDTO genre = new GenreDTO()
                {
                    Genre = genreDialog.GenreName
                };
                long newId = LibraryRepository.AddGenre(genre);
                Genres = LibraryRepository.GetGenres();
                var g = Genres.Single(s => s.Id == newId);
                if (g != null)
                    SelectedGenre = g;
                else
                    SelectedGenre=Genres[0];
            }
        }
        private void ClickNewSeries(object o)
        {
            AddSeries seriesDialog = new AddSeries();
            seriesDialog.SeriesName = "";
            seriesDialog.ShowDialog();
            if (seriesDialog.DialogResult == true)
            {
                SeriesDTO series = new SeriesDTO()
                {
                    Name = seriesDialog.SeriesName
                };
                long newId = LibraryRepository.AddSeries(series);
                Series = LibraryRepository.GetSeries();
                var s = Series.Single(x => x.Id == newId);
                if (s != null)
                    SelectedSeries = s;
                else
                    SelectedSeries=Series[0];
            }
        }
        private void ClickNewUser(object o)
        {
            AddUser userDialog = new AddUser();
            userDialog.UserName = "";
            userDialog.ShowDialog();
            if (userDialog.DialogResult == true)
            {
                UserDTO user = new UserDTO()
                {
                    Name = userDialog.UserName
                };
                long newId = LibraryRepository.AddUser(user);
                Users = LibraryRepository.GetUsers();
                var u = Users.Single(x => x.Id == newId);
                if (u != null)
                    SelectedUser = u;
                else
                    SelectedUser = Users[0];
            }
        }
        private void ClickNewLibrarian(object o)
        {
            AddLibrarian librarianDialog = new AddLibrarian();
            librarianDialog.LibrarianName = "";
            librarianDialog.ShowDialog();
            if (librarianDialog.DialogResult == true)
            {
                LibrarianDTO librarian = new LibrarianDTO()
                {
                    Name = librarianDialog.LibrarianName
                };
                long newId = LibraryRepository.AddLibrarian(librarian);
                Librarians = LibraryRepository.GetLibrarians();
                var l = Librarians.Single(x => x.Id == newId);
                if (l != null)
                    SelectedLibrarian = l;
                else
                    SelectedLibrarian = Librarians[0];
            }
        }
        private void ClickNewOrder(object o)
        {
            CreateOrderWindow orderDialog = new CreateOrderWindow();
            orderDialog.Librarian = "";
            orderDialog.User = "";
            orderDialog.CheckoutDate = "";
            orderDialog.ShowDialog();
            if(orderDialog.DialogResult == true)
            {
                var userId = LibraryRepository.context.Users.Where(x => x.Name == orderDialog.User).FirstOrDefault();
                var librarianId = LibraryRepository.context.Librarians.Where(x => x.Name == orderDialog.Librarian).FirstOrDefault();
                if (userId !=null)
                {
                    if (librarianId != null)
                    {
                        OrderDTO order = new OrderDTO()
                        {
                            BookId = SelectedBook.Id,
                            UserId = userId.Id,
                            LibrarianId = librarianId.Id,
                            CheckoutDate = orderDialog.CheckoutDate,
                            ReturnDate = null
                        };
                        long newId = LibraryRepository.AddOrder(order);
                        Orders = LibraryRepository.GetOrders();
                        var r = Orders.Single(x => x.OrderNumber == newId);
                        if (r != null)
                            SelectedOrder = r;
                        else
                            SelectedOrder = Orders[0];
                    }
                    else
                        MessageBox.Show("That Librarian Doesn't Exist");
                }
                else
                    MessageBox.Show("That User Doesn't Exist");

            }
        }
        //TODO BUILD CREATE FUNCTIONALITY FOR ORDERS
        #endregion

        #region Update Functionality
        private void ClickEditAuthor(object o)
        {
            AddAuthor authorDialog = new AddAuthor();
            authorDialog.AuthorName = SelectedAuthor.Name;
            authorDialog.ShowDialog();
            if (authorDialog.DialogResult == true)
            {
                SelectedAuthor.Name = authorDialog.AuthorName;
                LibraryRepository.UpdateAuthor(SelectedAuthor);
            }
        }
        private void ClickEditGenre(object o)
        {
            AddGenre genreDialog = new AddGenre();
            genreDialog.GenreName = SelectedGenre.Genre;
            genreDialog.ShowDialog();
            if (genreDialog.DialogResult == true)
            {
                SelectedGenre.Genre = genreDialog.GenreName;
                LibraryRepository.UpdateGenre(SelectedGenre);
            }
        }
        private void ClickEditSeries(object o)
        {
            AddSeries seriesDialog = new AddSeries();
            seriesDialog.SeriesName = SelectedSeries.Name;
            seriesDialog.ShowDialog();
            if (seriesDialog.DialogResult == true)
            {
                SelectedSeries.Name = seriesDialog.SeriesName;
                LibraryRepository.UpdateSeries(SelectedSeries);
            }
        }
        private void ClickEditUser(object o)
        {
            AddUser userDialog = new AddUser();
            userDialog.UserName = SelectedUser.Name;
            userDialog.ShowDialog();
            if (userDialog.DialogResult == true)
            {
                SelectedUser.Name = userDialog.UserName;
                LibraryRepository.UpdateUser(SelectedUser);
            }
        }
        private void ClickEditLibrarian(object o)
        {
            AddLibrarian librarianDialog = new AddLibrarian();
            librarianDialog.LibrarianName = SelectedLibrarian.Name;
            librarianDialog.ShowDialog();
            if (librarianDialog.DialogResult == true)
            {
                librarianDialog.Name = librarianDialog.LibrarianName;
                LibraryRepository.UpdateLibrarian(SelectedLibrarian);
            }
        }
        private void ClickEditOrder(object o)
        {
            FinishOrder finishOrderDialog = new FinishOrder();
            finishOrderDialog.ReturnDate = "";
            finishOrderDialog.ShowDialog();
            if (finishOrderDialog.DialogResult == true)
            {
                SelectedOrder.ReturnDate = finishOrderDialog.ReturnDate;
                LibraryRepository.UpdateOrder(SelectedOrder);
            }
        }
        //TODO: Implement Edit Book Functionality
        //TODO: Implement Edit Order Functionality
        #endregion

        #region Delete Functionality
        private void ClickDeleteBook(object o)
        {
            if(!LibraryRepository.DeleteBook(_SelectedBook.Id))
            {
                MessageBox.Show("This Book has an order history and cannot be delted");
            }
            else
            {
                Books = LibraryRepository.GetBooks();
            }
        }

        private void ClickDeleteAuthor(object o)
        {
            if (!LibraryRepository.DeleteAuthor(_SelectedAuthor))
            {
                MessageBox.Show("There are books written by this author so they cannot be removed");
            }
            else
            {
                Authors = LibraryRepository.GetAuthors();
            }
        }
        
        private void ClickDeleteSeries(object o)
        {
            if (!LibraryRepository.DeleteSeries(_SelectedSeries))
            {
                MessageBox.Show("There are books in this series so it cannot be deleted");
            }
            else
            {
                Series = LibraryRepository.GetSeries();
            }
        }
        #endregion

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
