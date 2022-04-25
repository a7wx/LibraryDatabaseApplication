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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LibraryApplication
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }
        public string BookTitle
        {
            get { return tbTitle.Text; }
            set { tbTitle.Text = value; }
        }
        public string BookSubtitle
        {
            get { return tbSubtitle.Text; }
            set { tbSubtitle.Text = value; }
        }
        public string BookGenre
        {
            get { return tbGenre.Text; }
            set { tbGenre.Text = value; }
        }
        public string BookAuthor
        {
            get { return tbAuthor.Text; }
            set { tbAuthor.Text = value; }
        }
        public string BookLength
        {
            get { return tbLength.Text; }
            set { tbLength.Text = value; }
        }
        public string BookPublisher
        {
            get { return tbPublisher.Text; }
            set { tbPublisher.Text = value; }
        }
        public string BookSeries
        {
            get { return tbSeries.Text; }
            set { tbSeries.Text = value; }
        }
        public string BookSeriesPos
        {
            get { return tbSeriesPos.Text; }
            set { tbSeriesPos.Text = value; }
        }
        private void btAddBook_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
