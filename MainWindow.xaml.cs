using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CarSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> Users { get; set; } = new List<User>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<User>));

        public MainWindow()
        {
            InitializeComponent();
            ReadInUsers();
        }

        private void ReadInUsers()
        {
            string path = "Users.xml";

            if (File.Exists(path))
            {
                using (FileStream rs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Users = xmler.Deserialize(rs) as List<User>;
                }
            }
        }

        private void LoginCommand(object sender, RoutedEventArgs e)
        {
            bool check = true;

            if (ValidatAllEntries())
            {
                User act = Users.FirstOrDefault(x => x.UserName == UserNameEntry.Text);
                if(act == null)
                {
                    MessageBox.Show("Invalid User Name. Please Try Again", "Error");
                    UserNameEntry.Clear();
                    check = false;
                }
                if (check == true)
                {
                    if(act.Password == PasswordEntry.Password)
                    {
                        Home homeMenu = new Home(act);
                        this.Close();
                        homeMenu.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password. Please Try Again", "Error");
                        PasswordEntry.Clear();

                    }
                }

                else
                {
                    MessageBox.Show("Invalid Password. Please Try Again", "Error");
                }
            }
        }

        private bool ValidatAllEntries()
        {
            if (string.IsNullOrWhiteSpace(UserNameEntry.Text))
            {
                MessageBox.Show("Please Enter Your UserName", "Error");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordEntry.Password))
            {
                MessageBox.Show("Please Enter Your Password", "Error");
                return false;
            }

            return true;

        }

        private void CancelCommand(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CreateCommand(object sender, RoutedEventArgs e)
        {
            AccountCreation act = new AccountCreation(Users);
            act.ShowDialog();
            if (act.Login.IsDefault == true)
            {
                ReadInUsers();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
