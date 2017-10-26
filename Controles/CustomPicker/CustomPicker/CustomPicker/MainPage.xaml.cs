using CustomPicker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomPicker
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            
            vm = new MainPageViewModel();

            vm.lstObjetos = new System.Collections.ObjectModel.ObservableCollection<ViewModel.Objeto>() {
                new Objeto()
                {
                    Descricao = "Item 1",
                    Valor = 1001
                },
                new Objeto()
                {
                    Descricao = "Item 2",
                    Valor = 1002
                }
            };

            BindingContext = vm;
        }

        protected void btnVerificar_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Item selecionado", (vm.Selecionado != null ? "Descrição: " + vm.Selecionado.Descricao + "\nValor: " + vm.Selecionado.Valor : "Nenhum item selecionado."), "Ok");
        }
    }
}
