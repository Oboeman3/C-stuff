using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for Reminder.xaml
    /// </summary>
    public partial class Reminder : Window
    {
        User temp;
        DateTime aptTemp;
        public Reminder(User act,DateTime apt)
        {
            temp = act;
            aptTemp = apt;
            InitializeComponent();
      
        }
        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 10000;


            client.Credentials = new System.Net.NetworkCredential("wfink1748@gmail.com", "Phillies2008");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("wfink1748@gmail.com");

            mail.To.Add(temp.Email);
            mail.Subject = "Thank You For for making a appointment!";
            mail.Body = $"Hello {temp.Name}"+
                $"\n"+
                $"Thank you for your business" +
                $"\n"+
                $"Your appointment on {aptTemp}" +
                $"\n"+
                $"Please feel free to stop by anytime between 8:00 am and 6:00 pm" +
                $"\n"+
                $"Make sure to add to your wishlist so we can help you find the right car";
            mail.BodyEncoding = Encoding.UTF8;

            client.Send(mail);

            MessageBox.Show("Check Email", "Success");
            this.Close();
        }
        // Let the users make a local Save as a text file 
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "TXT Files(*.txt)|*.txt";
            saveDialog.InitialDirectory = @"C:";

            if (saveDialog.ShowDialog() == true)
            {
                string localSaveLocation = saveDialog.FileName;

                File.WriteAllText(localSaveLocation, $"Hello {temp.Name}" +
                $"\n" +
                $"Thank you for your business" +
                $"\n" +
                $"Your appointment on {aptTemp}" +
                $"\n" +
                $"Please feel free to stop by anytime between 8:00 am and 6:00 pm" +
                $"\n" +
                $"Make sure to add to your wishlist so we can help you find the right car");

                MessageBox.Show("File Successfully Saved", "Success");
                this.Close();
            }



        }
    }
}