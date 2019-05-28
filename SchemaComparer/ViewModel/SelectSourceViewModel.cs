using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchemaComparer.ViewModel
{
    class SelectSourceViewModel : INotifyPropertyChanged
    {
        //need to implement button click via ICommand wpf style

        //public string serverName;
        private AuthenticationType authenticationType;
        public SelectSourceViewModel()
        {
            
        }

        public ObservableCollection<string> Databases { get; set; }
        public string ServerName
        {
            get;
            set;
        }
        public string UserName { get; set; }
        public string Password { get; set; }

        public void PopulateDatabasList()
        {
            try
            {
                //Databases.Add()
                //cmbsrcDatabase.Items.Clear();
                using (var conn = new ConnectionHelper(ServerName, UserName, Password, authenticationType))
                {
                    using (var reader = new SqlCommand("select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');", conn.GetConnection()).ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Databases.Add(reader["name"].ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    ExMessage = ex.InnerException.Message;
                }
                else
                {
                    ExMessage = ex.Message;
                }
            }
        }

        public string ExMessage { get; set; }

        public bool DatabaseIsChecked { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
