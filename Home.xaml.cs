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
        List<Car> Collection = ProcessCarFile("cars.csv");
        List<Dealership> DealerCollection = ProcessDealerFile("Dealership.csv");
        public Home()
        {
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
                basicWin.ShowDialog();
            }
            if (next == "Advanced Search" && checker == true)
            {
                AdvancedSearch advWin = new AdvancedSearch(Collection);
                advWin.ShowDialog();
            }
            if(next == "Dealership Search" && checker == true)
            {
                DealershipSearch dealWin = new DealershipSearch(DealerCollection);
                dealWin.ShowDialog();
            }
            if (next == "Make Appointment" && checker == true)
            {
                MakeAppt apptWin = new MakeAppt();
                apptWin.ShowDialog();
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
            basicWin.ShowDialog();
            this.Close();
        }

        private void Advanced(object sender, RoutedEventArgs e)
        {
            AdvancedSearch advWin = new AdvancedSearch(Collection);
            advWin.ShowDialog();
            this.Close();
        }

        private void DealershipSearch(object sender, RoutedEventArgs e)
        {
            DealershipSearch dealWin = new DealershipSearch(DealerCollection);
            dealWin.ShowDialog();
            this.Close();
        }
    }
}
