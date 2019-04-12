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
            if(check == false && priceCheck == true)
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


                    string searchMake = Make.SelectionBoxItem.ToString();
                    string searchPriceLow = PriceLow.SelectionBoxItem.ToString();
                    string searchPriceHigh = PriceHigh.SelectionBoxItem.ToString();

                    if(searchMake != "" && searchPriceHigh != "" && searchPriceLow == "")
                    {
                        int x;
                        int.TryParse(searchPriceHigh, style, culture, out x);
                        if (x != 0)
                        {
                            List<Car> query1 = importedCollection.Where(c => (c.Price <= x) && c.Make == searchMake).ToList();
                            Results.ItemsSource = query1;
                        }
                        else
                        {
                            List<Car> query1 = importedCollection.Where(c => c.Make == searchMake).ToList();
                            Results.ItemsSource = query1;
                        }
                    }
                    if(searchMake != "" && searchPriceHigh == "" && searchPriceLow == "")
                    {
                        List<Car> query1 = importedCollection.Where(c => (c.Make == searchMake)).ToList();
                        Results.ItemsSource = query1;
                    }
                    if(searchMake != "" && searchPriceLow != "" && searchPriceHigh == "")
                    {
                        int y;
                        int.TryParse(searchPriceLow, style, culture, out y);

                        List<Car> query1 = importedCollection.Where(c => (c.Price >= y)  && c.Make == searchMake).ToList();
                        Results.ItemsSource = query1;
                    }
                    if(searchMake == "" && searchPriceHigh != "" && searchPriceLow != "")
                    {
                        int x;
                        int y;
                      
                        int.TryParse(searchPriceHigh, style, culture, out x);
                        int.TryParse(searchPriceLow, style, culture, out y);

                        if(x != 0)
                        {
                            List<Car> query1 = importedCollection.Where(c => (c.Price >= y) && (c.Price <= x)).ToList();
                            Results.ItemsSource = query1;
                        }
                        else
                        {
                            List<Car> query1 = importedCollection.Where(c => (c.Price >= y)).ToList();
                            Results.ItemsSource = query1;
                        }
                        
                    }
                    if(searchMake =="" && searchPriceHigh =="" && searchPriceLow !="")
                    {
                        int y;

                        int.TryParse(searchPriceLow, style, culture, out y);

                        List<Car> query1 = importedCollection.Where(c => (c.Price >= y)).ToList();
                        Results.ItemsSource = query1;
                    }
                    if(searchMake =="" && searchPriceHigh != "" && searchPriceLow =="")
                    {
                        int x;
                       
                        int.TryParse(searchPriceHigh, style, culture, out x);

                        if(x != 0)
                        {
                            List<Car> query1 = importedCollection.Where(c => (c.Price <= x)).ToList();
                            Results.ItemsSource = query1;
                        }
                        else
                        {
                            List<Car> query1 = importedCollection.ToList();
                            Results.ItemsSource = query1;
                        }
                        
                    }
                    if(searchMake =="" && searchPriceHigh =="" && searchPriceLow =="")
                    {
                        Results.ItemsSource = importedCollection;
                    }
                }
            }
            else if(check == true && priceCheck == true)
            {
                ResultsPrompt.Visibility = Visibility.Visible;
                Results.Visibility = Visibility.Visible;
                PriceHigh.Visibility = Visibility.Collapsed;
                PriceLow.Visibility = Visibility.Collapsed;
                PriceToLabel.Visibility = Visibility.Collapsed;
                Make.Visibility = Visibility.Collapsed;
                MakeLabel.Visibility = Visibility.Collapsed;
                Submit.Visibility = Visibility.Collapsed;


                string searchMake = Make.SelectionBoxItem.ToString();
                string searchPriceLow = PriceLow.SelectionBoxItem.ToString();
                string searchPriceHigh = PriceHigh.SelectionBoxItem.ToString();


                    int x;
                    int y;
                    int.TryParse(searchPriceHigh, style, culture, out x);
                    int.TryParse(searchPriceLow, style, culture, out y);

                    if(x != 0)
                    {
                        List<Car> query1 = importedCollection.Where(c => (c.Price >= y) && (c.Price <= x) && c.Make == searchMake).ToList();
                        Results.ItemsSource = query1;
                    }
                     else
                      {
                         List<Car> query1 = importedCollection.Where(c => (c.Price >= y) && c.Make == searchMake).ToList();
                        Results.ItemsSource = query1;
                      }
                    


            }

        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
