using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSearch
{
    public class BasicSearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        List<Car> CarCollection = ProcessCarFile("cars.csv");
        public BasicSearch Win { get; set; }
        public BasicSearchVM(BasicSearch win) { Win = win; }


        public static List<Car> ProcessCarFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromFile).ToList();
        }


        public void Submit_Click(object sender)
        {
            string ansLow = Win.PriceLow.SelectionBoxItem.ToString();
            string ansHigh = Win.PriceHigh.SelectionBoxItem.ToString();

            int low, high;
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("us-US");
            int.TryParse(ansHigh, style, culture, out high);
            int.TryParse(ansLow, style, culture, out low);

            if (high == 0)
            {
                high = 60000;
            }

            string searchMake = Win.Make.SelectionBoxItem.ToString();
            string searchPriceLow = Win.PriceLow.SelectionBoxItem.ToString();
            string searchPriceHigh = Win.PriceHigh.SelectionBoxItem.ToString();

            if (searchMake != "" && searchPriceHigh != "" && searchPriceLow == "")
            {
                int x;
                int.TryParse(searchPriceHigh, style, culture, out x);
                if (x != 0)
                {
                    List<Car> query1 = CarCollection.Where(c => (c.Price <= x) && c.Make == searchMake).ToList();
                    Win.Results.ItemsSource = query1;
                }
                else
                {
                    List<Car> query1 = CarCollection.Where(c => c.Make == searchMake).ToList();
                    Win.Results.ItemsSource = query1;
                }
            }
            if (searchMake != "" && searchPriceHigh == "" && searchPriceLow == "")
            {
                List<Car> query1 = CarCollection.Where(c => (c.Make == searchMake)).ToList();
                Win.Results.ItemsSource = query1;
            }
            if (searchMake != "" && searchPriceLow != "" && searchPriceHigh == "")
            {
                int y;
                int.TryParse(searchPriceLow, style, culture, out y);

                List<Car> query1 = CarCollection.Where(c => (c.Price >= y) && c.Make == searchMake).ToList();
                Win.Results.ItemsSource = query1;
            }
            if (searchMake == "" && searchPriceHigh != "" && searchPriceLow != "")
            {
                int x;
                int y;

                int.TryParse(searchPriceHigh, style, culture, out x);
                int.TryParse(searchPriceLow, style, culture, out y);

                if (x != 0)
                {
                    List<Car> query1 = CarCollection.Where(c => (c.Price >= y) && (c.Price <= x)).ToList();
                    Win.Results.ItemsSource = query1;
                }
                else
                {
                    List<Car> query1 = CarCollection.Where(c => (c.Price >= y)).ToList();
                    Win.Results.ItemsSource = query1;
                }

            }
            if (searchMake == "" && searchPriceHigh == "" && searchPriceLow != "")
            {
                int y;

                int.TryParse(searchPriceLow, style, culture, out y);

                List<Car> query1 = CarCollection.Where(c => (c.Price >= y)).ToList();
                Win.Results.ItemsSource = query1;
            }
            if (searchMake == "" && searchPriceHigh != "" && searchPriceLow == "")
            {
                int x;

                int.TryParse(searchPriceHigh, style, culture, out x);

                if (x != 0)
                {
                    List<Car> query1 = CarCollection.Where(c => (c.Price <= x)).ToList();
                    Win.Results.ItemsSource = query1;
                }
                else
                {
                    List<Car> query1 = CarCollection.ToList();
                    Win.Results.ItemsSource = query1;
                }

            }
            if (searchMake == "" && searchPriceHigh == "" && searchPriceLow == "")
            {
                Win.Results.ItemsSource = CarCollection;
            }
            if(searchMake != "" && searchPriceHigh != "" && searchPriceLow != "")
            {
                int x;
                int y;
                int.TryParse(searchPriceHigh, style, culture, out x);
                int.TryParse(searchPriceLow, style, culture, out y);

                if (x != 0)
                    {
                        List<Car> query1 = CarCollection.Where(c => (c.Price >= y) && (c.Price <= x) && c.Make == searchMake).ToList();
                        Win.Results.ItemsSource = query1;
                    }
                     else
                      {
                         List<Car> query1 = CarCollection.Where(c => (c.Price >= y) && c.Make == searchMake).ToList();
                        Win.Results.ItemsSource = query1;
                      }
            }
        }


        public ICommand Submitclick
        {
            get
            {
                if (_updateCarEvent == null)
                {
                    _updateCarEvent = new DelegateCommand(Submit_Click);
                }

                return _updateCarEvent;
            }
        }
        DelegateCommand _updateCarEvent;
    }
}
