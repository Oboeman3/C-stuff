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
    /// Interaction logic for AdvancedSearch.xaml
    /// </summary>
    public partial class AdvancedSearch : Window
    {
        List<Car> importedCollection = new List<Car>();

        public AdvancedSearch(List<Car> Collection)
        {
            InitializeComponent();
            importedCollection = Collection;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //checks the MPG inputs 
           bool mpgCheck = ValidateMPGInputs();
           bool check = ValidateOtherInputs();

            if(mpgCheck == true && check == false)
            {
                //creates the prompt window which the user selects whether or not they want default values for the broader search
                Prompt promptWin = new Prompt();
                promptWin.ShowDialog();
                if(promptWin.Yes.IsDefault == true)
                {
                    Search();
                }
                
            }
            if(check == true)
            {
                Search();
            }

   

        }
        //This creates all the quaries for each of the entries. If the entry is null, then we ignore that all together and continue down to the next entry
        private void Search()
        {
            Advanced.Visibility = Visibility.Collapsed;
            MakeLabel.Visibility = Visibility.Collapsed;
            Make.Visibility = Visibility.Collapsed;
            PriceHigh.Visibility = Visibility.Collapsed;
            PriceLabel.Visibility = Visibility.Collapsed;
            PriceToLabel.Visibility = Visibility.Collapsed;
            PriceLow.Visibility = Visibility.Collapsed;
            MPGHigh.Visibility = Visibility.Collapsed;
            MPGLow.Visibility = Visibility.Collapsed;
            MPGToLabel.Visibility = Visibility.Collapsed;
            CombinedMPG.Visibility = Visibility.Collapsed;
            Manual.Visibility = Visibility.Collapsed;
            Automatic.Visibility = Visibility.Collapsed;
            Label.Visibility = Visibility.Collapsed;
            ManualLabel.Visibility = Visibility.Collapsed;
            AutomaticLabel.Visibility = Visibility.Collapsed;
            EngineLabel.Visibility = Visibility.Collapsed;
            Engine.Visibility = Visibility.Collapsed;
            Drivetrain.Visibility = Visibility.Collapsed;
            Drivetrains.Visibility = Visibility.Collapsed;
            CarType.Visibility = Visibility.Collapsed;
            Type.Visibility = Visibility.Collapsed;
            FuelType.Visibility = Visibility.Collapsed;
            Electric.Visibility = Visibility.Collapsed;
            ElectricLabel.Visibility = Visibility.Collapsed;
            Gas.Visibility = Visibility.Collapsed;
            GasLabel.Visibility = Visibility.Collapsed;
            Diesel.Visibility = Visibility.Collapsed;
            DieselLabel.Visibility = Visibility.Collapsed;
            Submit.Visibility = Visibility.Collapsed;

            Prompt.Visibility = Visibility.Visible;
            Results.Visibility = Visibility.Visible;



            List<Car> tempQuery = importedCollection;
            // tempQuery = tempQuery.Where(c => c.Make == "Dodge").ToList();
            //tempQuery = tempQuery.Where(c => c.Price > 45000).ToList();
            string ans = Make.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                tempQuery = tempQuery.Where(c => c.Make == ans).ToList();
            }

            ans = PriceLow.SelectionBoxItem.ToString();
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
                tempQuery = tempQuery.Where(c => (c.Price >= x)).ToList();

            }
            ans = PriceHigh.SelectionBoxItem.ToString();
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
                    tempQuery = tempQuery.Where(c => (c.Price <= x)).ToList();

                }
                else
                {

                }
            }

            if (string.IsNullOrWhiteSpace(MPGLow.Text) || MPGLow.Text.Where(x => char.IsDigit(x)).Count() != MPGLow.Text.Length)
            {

            }
            else
            {
                int x = int.Parse(MPGLow.Text);
                if (string.IsNullOrWhiteSpace(MPGHigh.Text) || MPGHigh.Text.Where(c => char.IsDigit(c)).Count() != MPGHigh.Text.Length)
                {

                }
                else
                {
                    int y = int.Parse(MPGHigh.Text);
                    tempQuery = tempQuery.Where(c => (c.MilePerGal >= x) && (c.MilePerGal <= y)).ToList();
                }
            }

            bool? ManualChecked = Manual.IsChecked;
            bool? AutomaticChecked = Automatic.IsChecked;

            if (ManualChecked != true && AutomaticChecked != true)
            {

            }
            else if (ManualChecked == true)
            {
                tempQuery = tempQuery.Where(c => c.Tranmission == "Manual").ToList();
            }
            else if (AutomaticChecked == true)
            {
                tempQuery = tempQuery.Where(c => c.Tranmission == "Automatic").ToList();
            }

            ans = EngineLabel.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                tempQuery = tempQuery.Where(c => c.Engine == ans).ToList();
            }

            ans = Drivetrains.SelectionBoxItem.ToString();

           if (ans == "")
            {

            }
       else
           {
                tempQuery = tempQuery.Where(c => c.Drivetrain == ans).ToList();
            }

            ans = CarType.SelectionBoxItem.ToString();
            if (ans == "")
            {

            }
            else
            {
                tempQuery = tempQuery.Where(c => c.BodyType == ans).ToList();
            }

            bool? gasChecked = Gas.IsChecked;
            bool? dieselChecked = Diesel.IsChecked;
            bool? electricChecked = Electric.IsChecked;

            if (gasChecked != true && dieselChecked != true && electricChecked != true)
            {

            }
            else if (gasChecked == true)
            {
                tempQuery = tempQuery.Where(c => c.Type == "Gasoline").ToList();
            }
            else if (dieselChecked == true)
            {
                tempQuery = tempQuery.Where(c => c.Type == "Diesel").ToList();
            }
            else
            {
                tempQuery = tempQuery.Where(c => c.Type == "Electric").ToList();
            }


            Results.ItemsSource = tempQuery;
        }

        private bool ValidateOtherInputs()
        {
            bool check = true;
            string Ans = Make.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }
            Ans = PriceLow.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }
            Ans = PriceHigh.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }

            bool? ManualChecked = Manual.IsChecked;
            bool? AutomaticChecked = Automatic.IsChecked;

            if (ManualChecked != true && AutomaticChecked != true)
            {
                check = false;
            }

            Ans = EngineLabel.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }
            Ans = Drivetrains.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }
            Ans = CarType.SelectionBoxItem.ToString();
            if (Ans == "")
            {
                check = false;
            }

            bool? GasChecked = Gas.IsChecked;
            bool? DieselChecked = Diesel.IsChecked;
            bool? ElectricChecked = Electric.IsChecked;

            if (GasChecked != true && DieselChecked != true && ElectricChecked != true)
            {
                check = false;
            }
            if(check == false)
            {
                return false;
            }
            return true;
        }
        //Validates the input for the MPG entry
        //Since most entries are textboxes, we do not have to worry about what the user is entering
        private bool ValidateMPGInputs()
        {
             bool check = true;


            if (MPGLow.Text.Where(x => char.IsDigit(x)).Count() != MPGLow.Text.Length || MPGLow.Text.Where(x=> char.IsLetter(x)).Count() > 0)
            {
              int x;
              int.TryParse(MPGLow.Text, out x);
              if(x > 1000 || x < 0)
              {
                check = false;
              }
                check = false;
                MessageBox.Show("Invalid MPG Input", "Error");

                MPGLow.Clear();
            }
            if (MPGHigh.Text.Where(x => char.IsDigit(x)).Count() != MPGHigh.Text.Length || MPGHigh.Text.Where(x => char.IsLetter(x)).Count() > 0)
            {
              int x;
              int.TryParse(MPGHigh.Text, out x);
              if (x > 1000 || x < 0)
              {
                  check = false;
                }
                check = false;
                MessageBox.Show("Invalid MPG Input", "Error");

                MPGHigh.Clear();

            }
            int.TryParse(MPGHigh.Text, out int high);
            int.TryParse(MPGLow.Text, out int low);
            if (high < low)
            {
                MessageBox.Show("The Maximum MPG Cannot Be Lower Than The Minimum MPG", "Error");
                MPGLow.Clear();
                MPGHigh.Clear();
                check = false;
            }
            string ansLow = PriceLow.SelectionBoxItem.ToString();
            string ansHigh = PriceHigh.SelectionBoxItem.ToString();

            bool priceCheck = true;
 
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

            if (low > high)
            {
                priceCheck = false;
                MessageBox.Show("The Minimum Price Cannot Be Higher Than The Maximum Price", "Error");
                MPGLow.Clear();
                MPGHigh.Clear();

            }
            
            if (check == false || priceCheck == false)
            {
                return false;
            }
            return true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
