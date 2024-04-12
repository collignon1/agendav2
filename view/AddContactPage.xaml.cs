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
using agendav2.contactDB;
using agendav2.service.DAO;


namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour view_Add.xaml
    /// </summary>
    public partial class AddContactPage : UserControl
    {
        public DAOcontact DAOContact;
        public AddContactPage()
        {
            InitializeComponent();
            combo();
            
            DAOContact = new DAOcontact();
            Contact contact = new Contact();
        }
        
        //string chemin = "C:ressource/sex.txt";
        string[] lignes = File.ReadAllLines("D:ressource/sex.txt");
        public void combo()
        {
            foreach (string ligne in lignes)
            {
                CB_sex.Items.Add(ligne);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_Mail.Text = "";
            TB_Nom.Text = "";
            TB_prenom.Text = "";
            TB_tel.Text = "";
            date.SelectedDate = null;
            RB_amis.IsChecked = false;
            RB_autre.IsChecked = false;
            RB_collegue.IsChecked = true;
            RB_famille.IsChecked = false;
            CB_sex.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact();

            if(RB_collegue.IsChecked == true)
            {
                contact.Status = "COLLEGUE";
            }
            if (RB_amis.IsChecked == true)
            {
                contact.Status = "AMI";
            }
            if (RB_autre.IsChecked == true)
            {
                contact.Status = "AUTRE";
            }
            if (RB_famille.IsChecked == true)
            {
                contact.Status = "FAMILLE";
            }
            contact.Name = TB_prenom.Text;
            contact.LastName = TB_Nom.Text;
            contact.Mail = TB_Mail.Text;
            contact.PhoneNumber = TB_tel.Text;
            //contact.PhoneNumber = TB_phone.Text;

            contact.Sex = CB_sex.Text;

            if (date.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                contact.Birth = selectedDate;
            }
            DAOContact.addContact(contact);
        }
    }
}
