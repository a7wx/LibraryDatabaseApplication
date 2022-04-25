using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using LibraryApplication.Database;
using System;
namespace LibraryApplication.Repository
#nullable disable
{
    public static class LibraryRepository
    {
        public static LibraryDatabaseContext context = new LibraryDatabaseContext();

        #region Books
        public static long AddBook(BookDTO book)
        {
            Book books = new Book();
            books.Title = book.Title;
            books.Subtitle = book.Subtitle;
            books.Publisher = book.Publisher;
            books.SeriesPos = book.SeriesPos;
            books.SeriesId = book.SeriesId;
            books.Length = book.Length;
            books.Authors.Add(context.Authors.Where(x => x.Name == book.Author).FirstOrDefault());
            context.Authors.Where(x => x.Name == book.Author).FirstOrDefault().Books.Add(books);
            books.Genres.Add(context.Genres.Where(x => x.Genre1 == book.Genre).FirstOrDefault());
            context.Genres.Where(x => x.Genre1 == book.Genre).FirstOrDefault().Books.Add(books);
            context.Series.Where(x => x.Id == book.SeriesId).FirstOrDefault().Books.Add(books);
            context.Add<Book>(books);
            context.SaveChanges();
            return books.Id;
        }
        public static BindingList<BookDTO> GetBooks()
        {
            var authors = context.Authors.OrderBy(y=> y.Id);
            var list = context.Books.OrderBy(x => x.Id).Select(x => new BookDTO
            {
                Id = x.Id,
                Title = x.Title,
                Subtitle = x.Subtitle,
                Length = x.Length,
                Publisher = x.Publisher,
                SeriesId = x.SeriesId,
                SeriesPos = x.SeriesPos,
                SeriesName = context.Series.Where(a => a.Id == x.SeriesId).FirstOrDefault().Name,
                Author = x.Authors.Select(b => b.Name).FirstOrDefault(),
                Genre = x.Genres.Select(g => g.Genre1).FirstOrDefault()//Author = context.Authors.Where(b => b.Books = x.Authors)
            }).ToList();
            return new BindingList<BookDTO>(list);
        }

        public static bool UpdateBook(BookDTO book)
        {
            var bookToUpdate = context.Books.Where(x => x.Id == book.Id).FirstOrDefault();
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Subtitle = book.Subtitle;
                bookToUpdate.Length = book.Length;
                bookToUpdate.Publisher = book.Publisher;
                bookToUpdate.SeriesId = book.SeriesId;
                bookToUpdate.SeriesPos = book.SeriesPos;
                //Series Change will Cause Issues with foriegn key, checkback late if time allows
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteBook(long bookId)
        {
            var bookToDelete = context.Books.Where(x => x.Id == bookId).FirstOrDefault();
            if (bookToDelete == null) return false;
            if (bookToDelete.Orders.Count > 0) return false;
            //var bookToDeleteGenres = context.Genres.Books.Where(g => g.BookId == bookId).FirstOrDefault();
            context.Genres.Where(x => x.Id == bookToDelete.Genres.Select(g => g.Id).FirstOrDefault()).FirstOrDefault().Books.Remove(bookToDelete);//.Select(b => b.Id == bookToDelete.Id).FirstOrDefault();
            context.Authors.Where(x => x.Id == bookToDelete.Authors.Select(g => g.Id).FirstOrDefault()).FirstOrDefault().Books.Remove(bookToDelete);
            context.Series.Where(x => x.Id == bookToDelete.SeriesId).FirstOrDefault().Books.Remove(bookToDelete);
            bookToDelete.Authors.Clear();
            bookToDelete.Genres.Clear();
            context.Remove<Book>(bookToDelete);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Authors

        public static long AddAuthor(AuthorDTO author)
        {
            Author authors = new Author();
            authors.Name = author.Name;
            context.Add<Author>(authors);
            context.SaveChanges();
            return authors.Id;
        }

        public static BindingList<AuthorDTO> GetAuthors()
        {
            var authorlist = context.Authors.OrderBy(x => x.Name).Select(x => new AuthorDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return new BindingList<AuthorDTO>(authorlist);
        }

        public static bool UpdateAuthor(AuthorDTO author)
        {
            var authorToUpdate = context.Authors.Where(x => x.Id == author.Id).FirstOrDefault();
            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteAuthor(AuthorDTO author)
        {
            var authorToDelete = context.Authors.Where(x => x.Id == author.Id).FirstOrDefault();
            if (authorToDelete == null) return false;
            if (authorToDelete.Books.Count() > 0) return false;
            context.Remove(authorToDelete);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Genres

        public static long AddGenre(GenreDTO genre)
        {
            Genre genres = new Genre();
            genres.Genre1 = genre.Genre;
            context.Add<Genre>(genres);
            context.SaveChanges();
            return genres.Id;
        }

        public static BindingList<GenreDTO> GetGenres()
        {
            var genrelist = context.Genres.OrderBy(x => x.Id).Select(x => new GenreDTO
            {
                Id = x.Id,
                Genre = x.Genre1
            }).ToList();
            return new BindingList<GenreDTO>(genrelist);
        }

        public static bool UpdateGenre(GenreDTO genre)
        {
            var genreToUpdate = context.Genres.Where(x => x.Id == genre.Id).FirstOrDefault();
            if (genreToUpdate != null)
            {
                genreToUpdate.Genre1 = genre.Genre;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteGenre(GenreDTO genre)
        {
            var genreToDelete = context.Genres.Where(x => x.Id == genre.Id).FirstOrDefault();
            if (genreToDelete == null) return false;
            context.Remove(genreToDelete);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Orders

        public static long AddOrder(OrderDTO order)
        {
            Order orders = new Order();
            orders.BookId = order.BookId;
            orders.UserId = order.UserId;
            orders.LibrarianId = order.LibrarianId;
            orders.CheckoutDate = order.CheckoutDate;
            orders.ReturnDate = null;

            context.Books.Where(x=> x.Id == order.BookId).FirstOrDefault().Orders.Add(orders);
            context.Users.Where(x => x.Id == order.UserId).FirstOrDefault().Orders.Add(orders);
            context.Librarians.Where(x => x.Id == order.LibrarianId).FirstOrDefault().Orders.Add(orders);
            context.Add<Order>(orders);
            context.SaveChanges();
            return orders.OrderNumber;
        }

        public static BindingList<OrderDTO> GetOrders()
        {
            var orderList = context.Orders.OrderBy(x => x.OrderNumber).Select(x => new OrderDTO
            {
                OrderNumber = x.OrderNumber,
                UserId = x.UserId,
                LibrarianId = x.LibrarianId,
                BookId = x.BookId,
                CheckoutDate = x.CheckoutDate,
                ReturnDate = x.ReturnDate,
                User = context.Users.Where(u => u.Id == x.UserId).FirstOrDefault().Name,
                Librarian = context.Librarians.Where(u => u.Id == x.LibrarianId).FirstOrDefault().Name,
                Book = context.Books.Where(u => u.Id == x.BookId).FirstOrDefault().Title
            }).ToList();
            return new BindingList<OrderDTO>(orderList);
        }

        public static bool UpdateOrder(OrderDTO order)
        {
            var orderToUpdate = context.Orders.Where(x => x.OrderNumber == order.OrderNumber).FirstOrDefault();
            if (orderToUpdate != null)
            {
                orderToUpdate.OrderNumber = order.OrderNumber;
                orderToUpdate.UserId = order.UserId;
                orderToUpdate.LibrarianId = order.LibrarianId;
                orderToUpdate.BookId = order.BookId;
                orderToUpdate.CheckoutDate = order.CheckoutDate;
                orderToUpdate.ReturnDate = order.ReturnDate;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region Users

        public static long AddUser(UserDTO user)
        {
            User users = new User();
            users.Name = user.Name;
            context.Add<User>(users);
            context.SaveChanges();
            return users.Id;
        }

        public static BindingList<UserDTO> GetUsers()
        {
            var userList = context.Users.OrderBy(x => x.Id).Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return new BindingList<UserDTO>(userList);
        }

        public static bool UpdateUser(UserDTO user)
        {
            var userToUpdate = context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Series
        public static long AddSeries(SeriesDTO series1)
        {
            Series series = new Series();
            series.Name = series1.Name;
            context.Add<Series>(series);
            context.SaveChanges();
            return series1.Id;
        }

        public static BindingList<SeriesDTO> GetSeries()
        {
            var seriesList = context.Series.OrderBy(x => x.Id).Select(x => new SeriesDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return new BindingList<SeriesDTO>(seriesList);
        }

        public static bool UpdateSeries(SeriesDTO Series)
        {
            var userToUpdate = context.Series.Where(x => x.Id == Series.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.Name = Series.Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteSeries(SeriesDTO series)
        {
            var seriesToDelete = context.Series.Where(x => x.Id == series.Id).FirstOrDefault();
            if (seriesToDelete == null) return false;
            if (seriesToDelete.Books.Count > 0) return false;
            if (context.Books.Where(x=>x.SeriesId == seriesToDelete.Id).Count() > 0) return false;
            context.Remove(seriesToDelete);
            context.SaveChanges();
            return true;
        }
        #endregion

        #region Librarians

        public static long AddLibrarian(LibrarianDTO librarian)
        {
            Librarian librarians = new Librarian();
            librarians.Name = librarian.Name;
            context.Add<Librarian>(librarians);
            context.SaveChanges();
            return librarians.Id;
        }

        public static BindingList<LibrarianDTO> GetLibrarians()
        {
            var librarianList = context.Librarians.OrderBy(x => x.Id).Select(x => new LibrarianDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return new BindingList<LibrarianDTO>(librarianList);
        }

        public static bool UpdateLibrarian(LibrarianDTO librarian)
        {
            var librarianToUpdate = context.Librarians.Where(x => x.Id == librarian.Id).FirstOrDefault();
            if (librarianToUpdate != null)
            {
                librarianToUpdate.Name = librarian.Name;
                context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
