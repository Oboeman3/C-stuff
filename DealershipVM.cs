using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarSearch
{
    public class DealershipVM : INotifyPropertyChanged
    {
        List<Dealership> DealerCollection = ProcessDealerFile("Dealership.csv");
        public DealershipSearch Win { get; set; }
        public DealershipVM(DealershipSearch win) { Win = win; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static List<Dealership> ProcessDealerFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Dealership.ParseFromFile).ToList();
        }

       

        public void Submit_Click(object sender)
        {
            //string ans = MakeList.SelectionBoxItem.ToString();

             List<Dealership> query1 = DealerCollection.Where(c => c.Make == Win.MakeList.SelectionBoxItem.ToString())
               .ToList();
            Win.Dealerships.ItemsSource = query1;
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
