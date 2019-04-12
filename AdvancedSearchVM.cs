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
    public class AdvancedSearchVM : INotifyPropertyChanged
    {
        List<Car> CarCollection = ProcessCarFile("cars.csv");
        public AdvancedSearch Win { get; set; }
        public AdvancedSearchVM(AdvancedSearch win) { Win = win; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

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
          
            string ans = Win.Make.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                CarCollection = CarCollection.Where(c => c.Make == ans).ToList();
            }

            ans = Win.PriceLow.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                int x;
                NumberStyles style;
                CultureInfo culture;
                style = NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("us-US");
                int.TryParse(ans, style, culture, out x);
                CarCollection = CarCollection.Where(c => (c.Price >= x)).ToList();

            }
            ans = Win.PriceHigh.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                int x;
                NumberStyles style;
                CultureInfo culture;
                style = NumberStyles.AllowThousands | NumberStyles.AllowCurrencySymbol;
                culture = CultureInfo.CreateSpecificCulture("us-US");
                int.TryParse(ans, style, culture, out x);

                if (x != 0)
                {
                    CarCollection = CarCollection.Where(c => (c.Price <= x)).ToList();

                }
                else
                {

                }
            }

            if (string.IsNullOrWhiteSpace(Win.MPGLow.Text) || Win.MPGLow.Text.Where(x => char.IsDigit(x)).Count() != Win.MPGLow.Text.Length)
            {

            }
            else
            {
                int x = int.Parse(Win.MPGLow.Text);
                if (string.IsNullOrWhiteSpace(Win.MPGHigh.Text) || Win.MPGHigh.Text.Where(c => char.IsDigit(c)).Count() != Win.MPGHigh.Text.Length)
                {

                }
                else
                {
                    int y = int.Parse(Win.MPGHigh.Text);
                    CarCollection = CarCollection.Where(c => (c.MilePerGal >= x) && (c.MilePerGal <= y)).ToList();
                }
            }

            bool? ManualChecked = Win.Manual.IsChecked;
            bool? AutomaticChecked = Win.Automatic.IsChecked;

            if (ManualChecked != true && AutomaticChecked != true)
            {

            }
            else if (ManualChecked == true)
            {
                CarCollection = CarCollection.Where(c => c.Tranmission == "Manual").ToList();
            }
            else if (AutomaticChecked == true)
            {
                CarCollection = CarCollection.Where(c => c.Tranmission == "Automatic").ToList();
            }

            ans = Win.EngineLabel.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                CarCollection = CarCollection.Where(c => c.Engine == ans).ToList();
            }

            ans = Win.Drivetrains.SelectionBoxItem.ToString();

            if (ans == "")
            {

            }
            else
            {
                CarCollection = CarCollection.Where(c => c.Drivetrain == ans).ToList();
            }

            ans = Win.CarType.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                CarCollection = CarCollection.Where(c => c.BodyType == ans).ToList();
            }

            bool? gasChecked = Win.Gas.IsChecked;
            bool? dieselChecked = Win.Diesel.IsChecked;
            bool? electricChecked = Win.Electric.IsChecked;

            if (gasChecked != true && dieselChecked != true && electricChecked != true)
            {

            }
            else if (gasChecked == true)
            {
                CarCollection = CarCollection.Where(c => c.Type == "Gasoline").ToList();
            }
            else if (dieselChecked == true)
            {
                CarCollection = CarCollection.Where(c => c.Type == "Diesel").ToList();
            }
            else
            {
                CarCollection = CarCollection.Where(c => c.Type == "Electric").ToList();
            }


            Win.Results.ItemsSource = CarCollection;
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

