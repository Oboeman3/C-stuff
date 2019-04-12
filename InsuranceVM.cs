using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSearch
{
   public class InsuranceVM : INotifyPropertyChanged
    {


        public WishCartVM Parent { get; set; }
        public Insurance Parent2 { get; set; }
        public InsuranceVM(WishCartVM parent, Insurance parent2) { Parent = parent; Parent2 = parent2; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        int x = 80;

        private int payment;
        public int Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WishlistCar"));
            }
        }
        private void Calculate(object obj)
        {
            int X = 0;
            string ans = Parent2.Months.SelectionBoxItem.ToString();
            // Console.Write(Parent.SelectedCar.Price);
            if (ans == "16-24 Years Old")
            { 
                X = int.Parse(Parent.SelectedCar.Price.ToString()); 
                double y = X * .001; 
                X = (int)y + x;
                X = X * 2;
            }
            if (ans == "25-34 Years Old")
            {
                X = int.Parse(Parent.SelectedCar.Price.ToString());
                double y = X * .001;
                X = (int)y + x;
                y = X * .5;
                X = X + (int)y;
            }
            if (ans == "35-44 Years Old")
            {
                X = int.Parse(Parent.SelectedCar.Price.ToString());
                double y = X * .001;
                X = (int)y + x;
                y = X * .25;
                X = X + (int)y;
            }
            if(ans == "45+ Years Old")
            {
                X = int.Parse(Parent.SelectedCar.Price.ToString());
                double y = X * .001;
                X = (int)y + x;
                y = X * .1;
                X = X + (int)y;
            }
            Payment = X;

            ResultsWin month = new ResultsWin();
            ResultsWinVM monthVM = new ResultsWinVM(this);
            month.DataContext = monthVM;
            month.Show();

        }
        public ICommand CalculateCommand
        {
            get
            {
                if (_calculateEvent == null)
                {
                    _calculateEvent = new DelegateCommand(Calculate);
                }

                return _calculateEvent;
            }
        }
        DelegateCommand _calculateEvent;
    }
}
