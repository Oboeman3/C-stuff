using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSearch
{
    public class MonthyPaymentVM : INotifyPropertyChanged
    {
        public WishCartVM Parent { get; set; }
        public MonthyPayment Parent2 { get; set; }
        public MonthyPaymentVM(WishCartVM parent, MonthyPayment parent2) { Parent = parent;  Parent2 = parent2; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


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
           if(ans == "24 Months")
            {
                X = int.Parse(Parent.SelectedCar.Price.ToString());
                 X = X / 24;
            }
            if (ans == "36 Months")
            {
                 X = int.Parse(Parent.SelectedCar.Price.ToString());
                X = X / 36;
            }
            if (ans == "48 Months")
            {
               X = int.Parse(Parent.SelectedCar.Price.ToString());
                X = X / 48;
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
