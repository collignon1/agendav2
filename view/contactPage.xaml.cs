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
using System.Windows.Navigation;
using System.Windows.Shapes;

using agendav2.service.DAO;

namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour contact.xaml
    /// </summary>
    public partial class contactPage : UserControl
    {
        DAOcontact dAOContact;
        public contactPage()
        {
            InitializeComponent();
            dAOContact = new DAOcontact();

            DG_Contact.ItemsSource = dAOContact.GetAllContacts();
         //   DataContext = this;
        }
        int id = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(TB_ID.Text);
            dAOContact.removeContact(id);
        }
    }
}
