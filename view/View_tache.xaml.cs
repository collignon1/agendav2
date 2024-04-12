using agendav2.service.DAO;
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

namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour View_tache.xaml
    /// </summary>
    public partial class View_tache : UserControl
    {
        DAOTache dAOTaches;
        public View_tache()
        {
            InitializeComponent();
            dAOTaches = new DAOTache();

            DG_Contact.ItemsSource = dAOTaches.GetAllTaches();
            //   DataContext = this;
        }
        int id = 0;
        int id_delete = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            id_delete = int.Parse(TB_ID.Text);
            dAOTaches.DeleteTache(id_delete);
            DG_Contact.ItemsSource = dAOTaches.GetAllTaches();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id = int.Parse(TB_IDtodo.Text);
            DG_Contact.ItemsSource = dAOTaches.GetTacheByToDoList(id);
        }
    }
}
