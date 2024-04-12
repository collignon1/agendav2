using agendav2.contactDB;
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
    /// Logique d'interaction pour View_add_taches.xaml
    /// </summary>
    public partial class View_add_taches : UserControl
    {
        DAOTache dAOTaches;
        public View_add_taches()
        {
            InitializeComponent();
            dAOTaches = new DAOTache();
            Tache tache = new Tache();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tache tache = new Tache();
            if (RB_FAIT.IsChecked == true)
            {
                tache.Check = "FAIT";
            }
            if (RB_PAS_FAIT.IsChecked == true)
            {
                tache.Check = "PAS_FAIT";
            }
            tache.ToDoListIdtoDo = int.Parse(TB_ID_TODO.Text);
            tache.Name = TB_Name.Text;
            tache.Description = TB_descrition.Text;
         
            
            dAOTaches.AddTache(tache);


            TB_ID_TODO.Text = "";
            TB_Name.Text = "";
            TB_descrition.Text = "";
            RB_FAIT.IsChecked = false;
            RB_PAS_FAIT.IsChecked = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_ID_TODO.Text = "";
            TB_Name.Text = "";
            TB_descrition.Text = "";
            RB_FAIT.IsChecked = false;
            RB_PAS_FAIT.IsChecked = false;
        }
    }
}
