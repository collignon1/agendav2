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
using agendav2.contactDB;
using agendav2.service.DAO;
using System.IO;

namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour modify.xaml
    /// </summary>
    public partial class modify : UserControl
    {
        public DAOcontact DAOContact;
        public modify()
        {
            InitializeComponent();
            combo();

            DAOContact = new DAOcontact();
            Contact contact = new Contact();
        }
        int id = 0;
        string[] lignes = File.ReadAllLines("D:ressource/sex.txt");
        public void combo()
        {
            foreach (string ligne in lignes)
            {
                CB_sex.Items.Add(ligne);
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            id = int.Parse(TB_ID.Text);
            Contact contact = new Contact();

            if (RB_collegue.IsChecked == true)
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
            contact.LastName = TB_nom.Text;
            contact.Mail = TB_mail.Text;
            contact.PhoneNumber = TB_Tel.Text;
            //contact.PhoneNumber = TB_phone.Text;

            contact.Sex = CB_sex.Text;

            if (date.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = date.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                contact.Birth = selectedDate;
            }
            DAOContact.updateContact(id, contact);
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            TB_ID.Text = "";
            TB_prenom.Text = "";
            TB_nom.Text = "";
            TB_mail.Text = "";
            TB_Tel.Text = "";
            RB_amis.IsChecked = false;
            RB_autre.IsChecked = false;
            RB_collegue.IsChecked = false;
            RB_famille.IsChecked = false;
            CB_sex.Text = "";
            date.SelectedDate = null;

        }
    }
}
