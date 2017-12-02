using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace VetApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager fileManager;
        ObservableCollection<Customer> customer;

        public MainWindow()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            todayDate.Content = dt.ToString("dddd, MMMM d, yyyy");
            InitializeFiles(dt);
        }
        /// <summary>
        /// Creates a collection of customers based on date selected
        /// </summary>
        /// <param name="dt">date selected in application</param>
        private void InitializeFiles(DateTime dt)
        {
            customer = new ObservableCollection<Customer>();
            string datetime = dt.ToString("MMddyyyy");
            fileManager = new FileManager(datetime);
            customer = fileManager.Read();
            this.DataContext = customer;
        }
        /// <summary>
        /// The selected date  event handler from provided calender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(Calendar.SelectedDate);
            todayDate.Content = date.ToString("dddd, MMMM d, yyyy");
            fileManager.Save(customer);
            InitializeFiles(date);
        }
        /// <summary>
        /// Forces a save of customer class collection before exiting program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fileManager.Save(customer);
        }

        /// <summary>
        /// Right click action for each appointment time. Then highlights selected group.
        /// Takes the context menu name and changes it to the highlighting rectangle one letter diffrent
        /// between the two so a replacement of the the g and r is needed to highlight correct area.
        /// Switch statment takes the menu header which is the desired color to highlight and performes action
        /// </summary>
        /// <param name="sender">Context menu item</param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem tempMenu = (MenuItem)sender;
            ContextMenu tempContext = (ContextMenu)tempMenu.Parent;
            string temp = tempContext.Name;
            temp = temp.Replace("g", "r");
            Rectangle rectangle = (Rectangle)this.FindName(temp);

            switch ((tempMenu.Header))
            {
                case "Yellow":
                    rectangle.Fill = Brushes.Yellow;
                    break;
                case "Blue":
                    rectangle.Fill = Brushes.Blue;
                    break;
                case "Green":
                    rectangle.Fill = Brushes.Green;
                    break;
                case "Pink":
                    rectangle.Fill = Brushes.Pink;
                    break;
                case "Red":
                    rectangle.Fill = Brushes.Red;
                    break;
                case "Reset":
                    rectangle.Fill = Brushes.Transparent;
                    rectangle.Stroke = Brushes.Black;
                    break;
            }
        }
        /// <summary>
        /// Creates invoice window 
        /// not implemented yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice(customer);
            invoice.Show();
        }
        /// <summary>
        /// Exits program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
