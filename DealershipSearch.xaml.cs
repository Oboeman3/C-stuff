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
    /// Interaction logic for DealershipSearch.xaml
    /// </summary>
    public partial class DealershipSearch : Window
    {

        List<Dealership> importedCollection = new List<Dealership>();

        public DealershipSearch(List<Dealership> Collection)
        {
            InitializeComponent();
            importedCollection = Collection;
        }


        private void MakeAppt_Click(object sender, RoutedEventArgs e)
        {
            MakeAppt makeWin = new MakeAppt();
            makeWin.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static List<Dealership> ProcessFuelFile1(string path)
        {
            return 
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Dealership.ParseFromFile).ToList();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Prompt.Visibility = Visibility.Collapsed;
            Prompt2.Visibility = Visibility.Collapsed;
            Results.Visibility = Visibility.Visible;
            MakeList.Visibility = Visibility.Collapsed;
            Dealerships.Visibility = Visibility.Visible;
            Submit.Visibility = Visibility.Collapsed;

            //string ans = MakeList.SelectionBoxItem.ToString();

            List<Dealership> query1 = importedCollection.Where(c => c.Make == MakeList.SelectionBoxItem.ToString())
                .ToList();
            Dealerships.ItemsSource = query1;
        }
    }
}
