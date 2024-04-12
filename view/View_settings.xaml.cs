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
using agendav2.model;

namespace agendav2.view
{
    /// <summary>
    /// Logique d'interaction pour View_settings.xaml
    /// </summary>
    public partial class View_settings : UserControl
    {
        ConnectionString_Manager ConnectionString_Manager;
        public View_settings()
        {
            InitializeComponent();
            ConnectionString_Manager = new ConnectionString_Manager();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConnectionString_Manager.host = TB_host.Text;
            ConnectionString_Manager.port = TB_port.Text;
            ConnectionString_Manager.user = TB_user.Text;
            ConnectionString_Manager.password = TB_password.Text;
            ConnectionString_Manager.database = TB_database.Text;
            ConnectionString_Manager.Save();
        }
    }
}
