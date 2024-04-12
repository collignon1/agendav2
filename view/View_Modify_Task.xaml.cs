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
    /// Logique d'interaction pour View_Modify_Task.xaml
    /// </summary>
    public partial class View_Modify_Task : UserControl
    {
        DAOTache dAOTaches;
        public View_Modify_Task()
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
            if (TB_ID.Text != "")
            {
                tache.Idtache = int.Parse(TB_ID.Text);
            }
            if (TB_Name.Text != "")
            {
                tache.Name = TB_Name.Text;
            }   
            if (TB_descrition.Text != "")
            {
                tache.Description = TB_descrition.Text;
            }
            
            dAOTaches.UpdateTache(tache);
            TB_descrition.Text = "";
            TB_Name.Text = "";
            RB_FAIT.IsChecked = false;
            RB_PAS_FAIT.IsChecked = false;
            TB_ID.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_descrition.Text = "";
            TB_Name.Text = "";
            RB_FAIT.IsChecked = false;
            RB_PAS_FAIT.IsChecked = false;
            TB_ID.Text = "";
        }
    }
}
