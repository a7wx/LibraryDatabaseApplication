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
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        public CreateOrderWindow()
        {
            InitializeComponent();
        }
        public string User
        {
            get { return tbUser.Text; }
            set { tbUser.Text = value; }
        }
        public string Librarian
        {
            get { return tbLibrarian.Text; }
            set { tbLibrarian.Text = value; }
        }
        public string CheckoutDate
        {
            get { return tbCheckoutDate.Text; }
            set { tbCheckoutDate.Text = value; }
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
