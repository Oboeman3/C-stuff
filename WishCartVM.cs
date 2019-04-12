using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarSearch
{
    public class WishCartVM : INotifyPropertyChanged
    {
        public TabItem SelectedTab { get; set; }

        public WishlistVM Parent { get; set; }
        public WishCart Cart { get; set; }
        public WishCartVM(WishlistVM parent, WishCart cart) { Parent = parent; Cart = cart; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        
        private Car selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WishlistCar"));
            }
        }
        private ObservableCollection<object> _wishContents = new ObservableCollection<object>();
        public ObservableCollection<object> WishContents
        {
            get { return _wishContents; }
            set
            {
                _wishContents = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WishContents"));
            }
        }
        private void Calculate(object obj)
        {
            if (SelectedCar == null)
            {

            }
            else
            {
                WishContents.Add(SelectedCar);
                MonthyPayment month = new MonthyPayment();
                MonthyPaymentVM monthVM = new MonthyPaymentVM(this, month);
                month.DataContext = monthVM;
                month.Show();
            }
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
        
        private void CalculateInsurance (object obj)
        {
            if (SelectedCar == null)
            {

            }
            else
            {
                Insurance month = new Insurance();
                InsuranceVM monthVM = new InsuranceVM(this, month);
                month.DataContext = monthVM;
                month.Show();
            }
        }
        public ICommand CalculateInsuranceCommand
        {
            get
            {
                if (_calculateInsurance == null)
                {
                    _calculateInsurance = new DelegateCommand(CalculateInsurance);
                }

                return _calculateInsurance;
            }
        }
        DelegateCommand _calculateInsurance;
    }
    }

