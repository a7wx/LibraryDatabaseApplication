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

namespace LibraryApplication
{
    /// <summary>
    /// Interaction logic for AddLibrarian.xaml
    /// </summary>
    public partial class AddLibrarian : Window
    {
        public AddLibrarian()
        {
            InitializeComponent();
        }

        public string LibrarianName
        {
            get { return tbLibrarianName.Text; }
            set { tbLibrarianName.Text = value; }
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
