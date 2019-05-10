using Microsoft.SqlServer.Dac;
using Microsoft.SqlServer.Dac.Compare;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
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
using System.Windows.Threading;

namespace SchemaComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            cmbsrcDatabase.DropDownOpened += CmbsrcDatabase_DropDownOpened;
            cmbsrcDatabase.SelectionChanged += CmbsrcDatabase_SelectionChanged;
            cmbtarDatabase.DropDownOpened += CmbtarDatabase_DropDownOpened;
            cmbtarDatabase.SelectionChanged += CmbtarDatabase_SelectionChanged;
            btnCompare.Click += BtnCompare_Click;
            btnGenerateScript.Click += BtnGenerateScript_Click;
            dgdiff.SelectedCellsChanged += Dgdiff_SelectedCellsChanged;
            rdbSourceDatabase.Checked += RdbSourceDatabase_Checked;
            rdbSourceFile.Checked += RdbSourceFile_Checked;
            rdbTargetDatabase.Checked += RdbTargetDatabase_Checked;
            rdbTargetFile.Checked += RdbTargetFile_Checked;
            btnSourceFileChooser.Click += BtnSourceFileChooser_Click;
            SaveCompare.Click += SaveCompareFile;
            SaveGenerateScript.Click += SaveGeneratedScript; 
            SetDefaults();
        }

        #region Public Properties
        public List<DacDeployOptions> DacOptions { get; set; }
        private void SetDefaults()
        {
            rdbSourceDatabase.IsChecked = true;
            rdbTargetDatabase.IsChecked = true;
            OptionsDataGrid.ItemsSource = new DacOptions().GetOptions();

            //DebugGrid.ItemsSource = 
        }
        public SchemaComparisonResult ComparisonResult { get; set; }
        public SchemaComparison Comparison
        {
            get
            {
                return schemaComparison;
            }
            set
            {

                schemaComparison = value;
                OnPropertyChanged("Comparison");
            }
        }
        public SQLCompare Comparer { get; set; }
        public SchemaCompareScriptGenerationResult GeneratedScriptResult { get; set; }
        public string SourceConnectionString { get; set; }
        public string TargetConnectionString { get; set; }
        #endregion
        #region SourcesTab
        #region Private Properties
        private string sourceFilePath;
        private string targetFilePath;
        #endregion
        #region Public Properties
        public string SourceFilePath
        {
            get { return sourceFilePath; }
            set
            {
                sourceFilePath = value;
                OnPropertyChanged("SourceFilePath");
            }
        }
        public string TargetFilePath
        {
            get { return targetFilePath; }
            set
            {
                sourceFilePath = value;
                OnPropertyChanged("TargetFilePath");
            }
        }
        #endregion
        #region Events
        private void BtnSourceFileChooser_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = new OpenFileDialog();
            dialogResult.ShowDialog();
            SourceFilePath = dialogResult.FileName;
            //sourceFilePath = "test2";
        }

        private void RdbSourceFile_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            SourceFileGrid.Visibility = Visibility.Visible;
            SourceDatabaseGrid.Visibility = Visibility.Hidden;
        }

        private void RdbSourceDatabase_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            SourceFileGrid.Visibility = Visibility.Hidden;
            SourceDatabaseGrid.Visibility = Visibility.Visible;

        }

        private void RdbTargetFile_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            TargetFileGrid.Visibility = Visibility.Visible;
            TargetDatabaseGrid.Visibility = Visibility.Hidden;
        }

        private void RdbTargetDatabase_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            TargetFileGrid.Visibility = Visibility.Hidden;
            TargetDatabaseGrid.Visibility = Visibility.Visible;
        }
        private void CmbsrcDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var constr = new ConnectionHelper(txtsrcServerName.Text, txtsrcUserName.Text, txtsrcPassword.Text, e.AddedItems[0].ToString());
            SourceConnectionString = constr.GetSqlConnectionString().ToString();
        }

        private void CmbsrcDatabase_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                cmbsrcDatabase.Items.Clear();
                using (var conn = new ConnectionHelper(txtsrcServerName.Text, txtsrcUserName.Text, txtsrcPassword.Text))
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

        private void CmbtarDatabase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var constr = new ConnectionHelper(txttarServerName.Text, txttarUserName.Text, txttarPassword.Text, e.AddedItems[0].ToString());
            TargetConnectionString = constr.GetSqlConnectionString().ToString();
        }

        private void CmbtarDatabase_DropDownOpened(object sender, EventArgs e)
        {
            using (var conn = new ConnectionHelper(txttarServerName.Text, txttarUserName.Text, txttarPassword.Text))
            {
                using (var reader = new SqlCommand("select name from sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');", conn.GetConnection()).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbtarDatabase.Items.Add(reader["name"].ToString());
                    }
                }

            }
        }
        #endregion
        #endregion
        #region CompareTab
        #region Private Properties
        private SchemaComparison schemaComparison;
        #endregion
        private async void BtnCompare_Click(object sender, RoutedEventArgs e)
        {
            //goto compare tab and start comparing
            MainTabControl.SelectedIndex = 1;

            Comparer = new SQLCompare(SourceConnectionString, TargetConnectionString);
            Comparison = Comparer.Initialize();

            btnCompare.IsEnabled = false;
            CompareStatusLabel.Content = "Loading";
            ComparisonResult = await Task.Run(() => Comparer.Compare());
            btnCompare.IsEnabled = true;
            dgdiff.ItemsSource = ComparisonResult.Differences;
            CompareStatusLabel.Content = "";
        }
        private void Dgdiff_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var diff = (SchemaDifference)dgdiff.SelectedItem;
            if (diff != null)
            {
                //Load source script
                LoadTextDocument(txtSourceScript, diff.SourceObject != null ? diff.SourceObject.GetScript() : "Nothing to see here move a long");
                //load target script
                LoadTextDocument(txtTargetScript, diff.TargetObject != null ? diff.TargetObject.GetScript() : "Nothing to see here move a long");
            }
        }
        private async void BtnGenerateScript_Click(object sender, RoutedEventArgs e)
        {
            DifferenceTab.SelectedIndex = 1;
            GeneratedScriptText.Text = "loading...";
            GeneratedScriptResult = await Task.Run(() => ComparisonResult.GenerateScript("TestingDB"));
            GeneratedScriptText.Text = await Task.Run(() => GeneratedScriptResult.Script);
        }
        private void LoadTextDocument(RichTextBox richTextBox, string text)
        {
            TextRange range;

            range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                range.Load(memoryStream, DataFormats.Text);
            }
        }
        private void SaveCompareFile(object sender, RoutedEventArgs e)
        {
            if (Comparison == null)
            {
                MessageBox.Show("No comparison to save");
                return;
            }

            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "SQL Compare File (*.scmp)|*scmp";
            if (dialog.ShowDialog() == true)
            {
                Comparison.SaveToFile(dialog.FileName, true);
            }

        }
        private void SaveGeneratedScript(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(GeneratedScriptText.Text))
            {
                MessageBox.Show("Nothing to save");
                return;
            }

            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "SQL File (*.sql)|*.sql";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, GeneratedScriptText.Text);
            }
        }
        #endregion
        #region Options Tab
        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
