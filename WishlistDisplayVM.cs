using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSearch
{
    public class WishlistDisplayVM : INotifyPropertyChanged
    {
        public List<Car> CarCollection { get; set; } = new List<Car>();

        private Car wishlistCar;
        public Car WishlistCar
        {
            get { return wishlistCar; }
            set
            {
                wishlistCar = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WishlistCar"));
            }
        }
        public WishlistDisplayVM()
        {
            CarCollection = ProcessCarFile("cars.csv");
        }

       
        public static List<Car> ProcessCarFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromFile).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
