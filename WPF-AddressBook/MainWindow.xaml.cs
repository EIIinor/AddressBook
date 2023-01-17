using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPF_AddressBook.Models;
using WPF_AddressBook.Services;

namespace WPF_AddressBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        private readonly FileService file = new(); 


        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\ContactsList.json";

            PopulateContactsList();   
        }

        private void PopulateContactsList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());
                if (items != null)
                    contacts = items;
            }
            catch { }

            lv_Contacts.ItemsSource= contacts;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Phone = tb_Phone.Text,
                StreetName = tb_StreetName.Text,
                City = tb_City.Text,
                PostalCode = tb_PostalCode.Text,
            });

            file.Save(JsonConvert.SerializeObject(contacts));
            ClearForm();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
           tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phone.Text = "";
            tb_StreetName.Text = "";
            tb_City.Text = "";
            tb_PostalCode.Text = "";
        }
    }
}
