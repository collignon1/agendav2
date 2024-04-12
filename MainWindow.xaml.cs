using agendav2.service.DAO;
using agendav2.view;
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



namespace agendav2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DAOcontact DAOcontact = new DAOcontact();

            if ( DAOcontact.TestConnection())
            {
                MessageBox.Show("Connection reussi");
            }
            else
            {
                MessageBox.Show("Connection echoué");
            }
        }
        //fonction qui permet de naviguer vers la page d'ajout de contact
        private void btn_navClick(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            AddContactPage addContactPage = new AddContactPage();
            GridContainer.Children.Add(addContactPage);
        }
        //fonction qui permet de naviguer vers la page de contact
        private void BTN_contactClick(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            contactPage contactpage = new contactPage();
            GridContainer.Children.Add(contactpage);
        }
        //fonction qui permet de naviguer vers la page de modification de contact
        private void BTN_modify_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            modify modify = new modify();
            GridContainer.Children.Add(modify);
        }
        //fonction qui permet de naviguer vers la page d'ajout de todolist
        private void BTN_ToDoAdd_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_Add_ToDo view_Add_ToDo = new View_Add_ToDo();
            GridContainer.Children.Add(view_Add_ToDo);
        }
        //fonction qui permet de naviguer vers la page de la todolist
        private void BTN_todo_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_to_do view_To_Do = new View_to_do();
            GridContainer.Children.Add(view_To_Do);
        }
        //fonction qui permet de naviguer vers la page de modification de la todolist
        private void BTN_todomodif_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_Modify_ToDo view_ToDo_Modif = new View_Modify_ToDo();
            GridContainer.Children.Add(view_ToDo_Modif);
        }

        private void BTN_task_add_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_add_taches view_Add_Taches = new View_add_taches();
            GridContainer.Children.Add(view_Add_Taches);
        }

        private void BTN_task_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_tache view_Taches = new View_tache();
            GridContainer.Children.Add(view_Taches);
        }

        private void BTN_task_modif_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_Modify_Task view_modify_Taches = new View_Modify_Task();
            GridContainer.Children.Add(view_modify_Taches);
        }

        private void config_Click(object sender, RoutedEventArgs e)
        {
            GridContainer.Children.Clear();
            View_settings view_Settings = new View_settings();
            GridContainer.Children.Add(view_Settings);
        }
    }
}
