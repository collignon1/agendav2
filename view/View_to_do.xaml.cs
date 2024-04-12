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
    /// Logique d'interaction pour View_to_do.xaml
    /// </summary>
    public partial class View_to_do : UserControl
    {
        DAOToDoList dAOToDoList;
        public View_to_do()
        {
            InitializeComponent();
            dAOToDoList = new DAOToDoList();

            DG_Contact.ItemsSource = dAOToDoList.GetAllToDoList();
            //   DataContext = this;
        }
        int id = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            id = int.Parse(TB_ID.Text);
            dAOToDoList.DeleteToDoListAndTache(id);
            DG_Contact.ItemsSource = dAOToDoList.GetAllToDoList();
        }
    }
}

