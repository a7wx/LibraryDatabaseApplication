using System.Windows;

namespace LibraryApplication
{
    /// <summary>
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    public partial class AddAuthor : Window
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        public string AuthorName
        {
            get { return tbAuthorName.Text; }
            set { tbAuthorName.Text = value; }
        }
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }


}
