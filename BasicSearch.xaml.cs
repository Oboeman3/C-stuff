using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for BasicSearch.xaml
    /// </summary>
    public partial class BasicSearch : Window
    {
        List<Car> importedCollection = new List<Car>();

        public BasicSearch(List<Car>Collection)
        {
            InitializeComponent();
            importedCollection = Collection;
        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //This contains all the prompts needed as well as the quaries
            //If the user does not input a value and wants to continue, then we ignore the user ignored fields
            bool check = true;
            bool priceCheck = true;
            string ans = Make.SelectionBoxItem.ToString();
            if(ans == "")
            {
                check = false;
            }

            string ansLow = PriceLow.SelectionBoxItem.ToString();
            if(ansLow == "")
            {
                check = false;
            }
           string ansHigh = PriceHigh.SelectionBoxItem.ToString();
            if(ansHigh == "")
            {
                check = false;
            }

            int low,high;
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("us-US");
            int.TryParse(ansHigh, style, culture, out high);
            int.TryParse(ansLow, style, culture, out low);

            if(high == 0)
            {
                high = 60000;
            }

            if (low > high)
            {
                priceCheck = false;
                MessageBox.Show("The Minimum Price Cannot Be Higher Than The Maximum Price", "Error");
                
            }
            if (check == false && priceCheck == true)
            {
                Prompt promptWin = new Prompt();
                promptWin.ShowDialog();
                if (promptWin.Yes.IsDefault == true)
                {
                    ResultsPrompt.Visibility = Visibility.Visible;
                    Results.Visibility = Visibility.Visible;
                    PriceHigh.Visibility = Visibility.Collapsed;
                    PriceLow.Visibility = Visibility.Collapsed;
                    PriceToLabel.Visibility = Visibility.Collapsed;
                    Make.Visibility = Visibility.Collapsed;
                    MakeLabel.Visibility = Visibility.Collapsed;
                    Submit.Visibility = Visibility.Collapsed;



                }
            }
            else if (check == true && priceCheck == true)
            {
                ResultsPrompt.Visibility = Visibility.Visible;
                Results.Visibility = Visibility.Visible;
                PriceHigh.Visibility = Visibility.Collapsed;
                PriceLow.Visibility = Visibility.Collapsed;
                PriceToLabel.Visibility = Visibility.Collapsed;
                Make.Visibility = Visibility.Collapsed;
                MakeLabel.Visibility = Visibility.Collapsed;
                Submit.Visibility = Visibility.Collapsed;
            }



        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
