using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaComparer.Models
{
    class SelectSourceModel : INotifyPropertyChanged
    {
        public SelectSourceModel()
        {

        }



        protected void OnPropertyChanged(object obj)
        {
            var name = nameof(obj);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
