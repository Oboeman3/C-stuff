using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSearch
{
    public class ResultsWinVM : INotifyPropertyChanged
    {
        public MonthyPaymentVM Parent2 { get; set; }
        public InsuranceVM Parent { get; set; }
        public ResultsWinVM (MonthyPaymentVM parent2) { Parent2 = parent2; }
        public ResultsWinVM (InsuranceVM parent) { Parent = parent; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
