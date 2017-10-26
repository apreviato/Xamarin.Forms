using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPicker.ViewModel
{
    public class MainPageViewModel : MainViewModel
    {
        private ObservableCollection<Objeto> _lstObjetos;

        public ObservableCollection<Objeto> lstObjetos
        {
            get { return _lstObjetos; }
            set { _lstObjetos = value; RaisePropertyChanged("lstObjetos"); }
        }

        private Objeto _selecionado;

        public Objeto Selecionado
        {
            get { return _selecionado; }
            set { _selecionado = value; RaisePropertyChanged("Selecionado"); }
        }
    }

    public class Objeto
    {
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
