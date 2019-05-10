using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SchemaComparer.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
        ///Add this to View's using section
        ///xmlns:vml = "clr-namespace:SchemaComparer.VML"
        //xmlns: viewModel = "clr-namespace:SchemaComparer.ViewModel"
        //vml: ViewModelLocator.AutoHookedUpViewModel = "True"

            //cmbsrcDatabase.DropDownOpened += CmbDatabase_DropDownOpened;
            //cmbsrcDatabase.SelectionChanged += CmbDatabase_SelectionChanged;
            //cmbtarDatabase.DropDownOpened += CmbtarDatabase_DropDownOpened;
            //cmbtarDatabase.SelectionChanged += CmbtarDatabase_SelectionChanged;
            //btnCompare.Click += BtnCompare_Click;
            //dgdiff.SelectedCellsChanged += Dgdiff_SelectedCellsChanged;
            //rdbSourceDatabase.Checked += RdbSourceDatabase_Checked;
            //rdbSourcFile.Checked += RdbSourcFile_Checked;
            //btnSourceFileChooser.Click += BtnSourceFileChooser_Click;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    }
}
