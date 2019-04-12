using System;
using System.Collections.Generic;
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
    /// Interaction logic for MakeAppt.xaml
    /// </summary>
    public partial class MakeAppt : Window
    {
        User temp;
        DateTime x;
        public MakeAppt(User act)
        {
            temp = act;
            InitializeComponent();
            ApptDate.DisplayDateStart = DateTime.Today;
            ApptDate.DisplayDateEnd = DateTime.Today.AddMonths(3);
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if(ApptDate.SelectedDate == null || ApptDate.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Please Select a Date For Your Appointment", "Error");
            }
            else
            {
               x = ApptDate.SelectedDate.Value;
                this.Close();
                Reminder remindtWin = new Reminder(temp,x);
                remindtWin.ShowDialog();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
