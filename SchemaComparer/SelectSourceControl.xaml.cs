using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace SchemaComparer
{
    /// <summary>
    /// Interaction logic for SQLAuthentication.xaml
    /// </summary>
    public partial class SelectSourceControl : UserControl
    {
        private AuthenticationType authenticationType;
        public SelectSourceControl()
        {
            InitializeComponent();
            rdbSourceDatabase.IsChecked = true;
            cmbAuthentication.ItemsSource = Enum.GetValues(typeof(AuthenticationType)).Cast<AuthenticationType>();
        }

        private void RdbSourceDatabase_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            SourceFileGrid.IsEnabled = false;
            SourceDatabaseGrid.IsEnabled = true;
        }

        private void RdbSourceFile_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            SourceFileGrid.IsEnabled = true;
            SourceDatabaseGrid.IsEnabled = false;
        }

        private void CmbsrcDatabase_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                cmbsrcDatabase.Items.Clear();
                using (var conn = new ConnectionHelper(txtsrcServerName.Text, txtsrcUserName.Text, txtsrcPassword.Text, authenticationType))
                {
                    using (var reader = new SqlCommand("select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');", conn.GetConnection()).ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbsrcDatabase.Items.Add(reader["name"].ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    lblsrcServerStatus.Content = ex.InnerException.Message;
                }
                else
                {
                    lblsrcServerStatus.Content = ex.Message;
                }
            }
        }

        private void CmbAuthentication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            authenticationType = (AuthenticationType)((ComboBox)sender).SelectedItem;
        }
    }

    
}
