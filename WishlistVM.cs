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
    public class WishlistVM : INotifyPropertyChanged
    {
        public TabItem SelectedTab { get; set; }

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

        public WishlistVM()
        {

        }
        
        private void AddToWishlist(object obj)
        {
            ContentControl cc = SelectedTab.Content as ContentControl;
            ListBox lb = cc.Content as ListBox;
            Car selectedCar = lb.SelectedItem as Car;
            if(SelectedTab.Header.ToString() == "Cars")
            {
                WishContents.Add(selectedCar as object);
            }
        }
        public ICommand AddToWishlistCommand
        {
            get
            {
                if (_addToWishEvent == null)
                {
                    _addToWishEvent = new DelegateCommand(AddToWishlist);
                }

                return _addToWishEvent;
            }
        }

        DelegateCommand _addToWishEvent;

        private void showList(object obj)
        {
            WishCart cart = new WishCart();
            WishCartVM wishCart = new WishCartVM(this,cart);
            cart.DataContext = wishCart;
            cart.Show();
        }
        public ICommand OpenCartCommand
        {
            get
            {
                if (_openCartEvent == null)
                {
                    _openCartEvent = new DelegateCommand(showList);
                }

                return _openCartEvent;
            }
        }
        DelegateCommand _openCartEvent;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
