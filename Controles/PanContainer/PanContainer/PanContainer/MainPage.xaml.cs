using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PanContainer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected void SwipLeft_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para a esquerda!", "Ok");
        }

        protected void SwipRight_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para a direita!", "Ok");
        }

        protected void SwipUp_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para cima!", "Ok");
        }

        protected void SwipDown_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para baixo!", "Ok");
        }
    }
}
