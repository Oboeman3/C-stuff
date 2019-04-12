using System;
using System.Collections.Generic;
using System.IO;
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

namespace CarSearch
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        User Act;
        List<Car> Collection = ProcessCarFile("cars.csv");
        List<Dealership> DealerCollection = ProcessDealerFile("Dealership.csv");
        public Home(User act)
        {
            Act = act;
            InitializeComponent();
           
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            string next = Options.SelectionBoxItem.ToString();
            bool checker = true;
            if(next == "")
            {
                MessageBox.Show("Please Select A Function", "Error");
                checker = false;
            }
            if(next == "Basic Search" && checker == true)
            {
                BasicSearch basicWin = new BasicSearch(Collection);
                BasicSearchVM basicWinVm = new BasicSearchVM(basicWin);
                basicWin.DataContext = basicWinVm;
                basicWin.ShowDialog();
            }
            if (next == "Advanced Search" && checker == true)
            {
                AdvancedSearch advWin = new AdvancedSearch(Collection);
                AdvancedSearchVM advWinVm = new AdvancedSearchVM(advWin);
                advWin.DataContext = advWinVm;
                advWin.ShowDialog();
            }
            if(next == "Dealership Search" && checker == true)
            {
                DealershipSearch dealWin = new DealershipSearch(Act);
                DealershipVM dealershipVM = new DealershipVM(dealWin);
                dealWin.DataContext = dealershipVM;
                dealWin.ShowDialog();
            }
            if (next == "Make Appointment" && checker == true)
            {
                MakeAppt apptWin = new MakeAppt(Act);
                apptWin.ShowDialog();
            }
            if(next == "Wishlist" && checker == true)
            {
                Wishlist wish = new Wishlist();
                WishlistVM wishVM = new WishlistVM();
                wish.DataContext = wishVM;
                wish.ShowDialog();
            }
        }
        public static List<Car> ProcessCarFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromFile).ToList();
        }

        public static List<Dealership> ProcessDealerFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Dealership.ParseFromFile).ToList();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Basic(object sender, RoutedEventArgs e)
        {
            BasicSearch basicWin = new BasicSearch(Collection);
            BasicSearchVM basicWinVm = new BasicSearchVM(basicWin);
            basicWin.DataContext = basicWinVm;
            basicWin.ShowDialog();
        }

        private void Advanced(object sender, RoutedEventArgs e)
        {
            AdvancedSearch advWin = new AdvancedSearch(Collection);
            AdvancedSearchVM advWinVm = new AdvancedSearchVM(advWin);
            advWin.DataContext = advWinVm;
            advWin.ShowDialog();
        }

        private void DealershipSearch(object sender, RoutedEventArgs e)
        {
            DealershipSearch dealWin = new DealershipSearch( Act);
            DealershipVM dealershipVM = new DealershipVM(dealWin);
            dealWin.ShowDialog();
        }

        private void WishlistClick(object sender, RoutedEventArgs e)
        {
            Wishlist wish = new Wishlist();
            WishlistVM wishVM = new WishlistVM();
            wish.DataContext = wishVM;
            wish.ShowDialog();
            
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow log = new MainWindow();
            this.Close();
            log.ShowDialog();
        }
    }
}
