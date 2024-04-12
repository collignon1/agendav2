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
namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour View_Modify_ToDo.xaml
    /// </summary>
    public partial class View_Modify_ToDo : UserControl
    {
        DAOToDoList dAOToDoList;
        ToDoList toDoList;
        public View_Modify_ToDo()
        {
            InitializeComponent();
            dAOToDoList = new DAOToDoList();
            ToDoList toDoList = new ToDoList();
        }
        int id = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ToDoList toDoList = new ToDoList();
            id = int.Parse(TB_ID.Text);
            toDoList.Name = TB_NAME.Text;
            toDoList.Description = TB_description.Text;
            if (datefin.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = datefin.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                toDoList.EndDate = selectedDate;
            }
            if (date_debut.SelectedDate.HasValue)
            {
                DateTime selectedDateTime = date_debut.SelectedDate.Value.Date;
                DateOnly selectedDate = new DateOnly(selectedDateTime.Year, selectedDateTime.Month, selectedDateTime.Day);
                toDoList.Date = selectedDate;
            }
            dAOToDoList.ModifyToDoList(id, toDoList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB_ID.Text = "";
            TB_description.Text = "";
            datefin.SelectedDate=null;
            date_debut.SelectedDate = null;
            TB_NAME.Text = "";
        }
    }
}
