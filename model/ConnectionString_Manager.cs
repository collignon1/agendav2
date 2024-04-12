using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace agendav2.model
{
    public class ConnectionString_Manager
    {
        public string host { get; set; }
        public string port { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string database { get; set; }

        public string ConString { get { return string.Format("server={0};port={1};user={2};password={3};database={4}", host, port, user, password, database); } }

        public ConnectionString_Manager()
        {
            host = ConfigurationManager.AppSettings["host"];
            port = ConfigurationManager.AppSettings["port"];
            user = ConfigurationManager.AppSettings["user"];
            password = ConfigurationManager.AppSettings["password"];
            database = ConfigurationManager.AppSettings["database"];
        }
        //fonction qui enregistre les paramètres de connexion
        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["host"].Value = host;
            config.AppSettings.Settings["port"].Value = port;
            config.AppSettings.Settings["user"].Value = user;
            config.AppSettings.Settings["password"].Value = password;
            config.AppSettings.Settings["database"].Value = database;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
