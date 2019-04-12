using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace CarSearch
{
    /// <summary>
    /// Interaction logic for AccountCreation.xaml
    /// </summary>
    public partial class AccountCreation : Window
    {
        List<User> userList = new List<User>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
        public AccountCreation(List<User> users )
        {
            InitializeComponent();
            userList = users;
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            User account = new User();
            bool checker = true;

            if(string.IsNullOrWhiteSpace(NameEntry.Text) || NameEntry.Text.Where(x => char.IsDigit(x)).Count() > 0)
            {
                MessageBox.Show("Please Enter A Valid Name","Error");
                checker = false;
                NameEntry.Clear();
            }
            else
            {
                account.Name = NameEntry.Text;
            }
            if (string.IsNullOrWhiteSpace(UserNameEntry.Text) || UserNameEntry.Text.Where(x => char.IsLetterOrDigit(x)).Count() != UserNameEntry.Text.Length)
            {
                MessageBox.Show("Please Enter A Valid User Name","Error");
                checker = false;
                UserNameEntry.Clear();
            }
            else
            {
                account.UserName = UserNameEntry.Text;
            }
            if (string.IsNullOrWhiteSpace(PasswordEntry.Password) || PasswordEntry.Password.Where(x => char.IsLetterOrDigit(x)).Count() < 8 || PasswordEntry.Password.Where(x => char.IsLetterOrDigit(x)).Count() > 23)
            {
                MessageBox.Show("Please Enter A Valid Password (Must Be of Length 8-23)", "Error");
                checker = false;
                PasswordEntry.Clear();
            }
            else
            {
                account.Password = PasswordEntry.Password;
            }
            if (string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                MessageBox.Show("Please Enter A Valid Email", "Error");
                checker = false;
                EmailEntry.Clear();
            }
            else
            {
                account.Email = EmailEntry.Text;
            }

            if(checker == true)
            {
                userList.Add(account);
                string path = "Users.xml";
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    serializer.Serialize(fs, userList);
                    MessageBox.Show("Account Created", "Success");
                }
                this.Close();
                this.Close();
                Home homeMenu = new Home(account);      
                homeMenu.ShowDialog();
            }

        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
