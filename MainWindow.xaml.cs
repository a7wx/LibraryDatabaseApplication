using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LibraryApplication.Repository;

namespace LibraryApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BookView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Visible;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Visible;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Visible;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void OrderView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Visible;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Visible;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void UserView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Visible;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Visible;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void LibrarianView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Visible;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Visible;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void SeriesView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Visible;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Visible;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Visible;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void GenreView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Visible;
            GridAuthorView.Visibility = Visibility.Hidden;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Visible;
            EditAuthorButton.Visibility = Visibility.Hidden;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Hidden;
        }
        private void AuthorView(object sender, RoutedEventArgs e)
        {
            GridBookView.Visibility = Visibility.Hidden;
            GridOrderView.Visibility = Visibility.Hidden;
            GridUserView.Visibility = Visibility.Hidden;
            GridLibrarianView.Visibility = Visibility.Hidden;
            GridSeriesView.Visibility = Visibility.Hidden;
            GridGenreView.Visibility = Visibility.Hidden;
            GridAuthorView.Visibility = Visibility.Visible;

            EditAuthorButton.Visibility = Visibility.Hidden;
            EditOrderButton.Visibility = Visibility.Hidden;
            EditUserButton.Visibility = Visibility.Hidden;
            EditLibrarianButton.Visibility = Visibility.Hidden;
            EditSeriesButton.Visibility = Visibility.Hidden;
            EditGenreButton.Visibility = Visibility.Hidden;
            EditAuthorButton.Visibility = Visibility.Visible;

            DeleteBookButton.Visibility = Visibility.Hidden;
            DeleteSeriesButton.Visibility = Visibility.Hidden;
            DeleteAuthorButton.Visibility = Visibility.Visible;
        }
    }
}
