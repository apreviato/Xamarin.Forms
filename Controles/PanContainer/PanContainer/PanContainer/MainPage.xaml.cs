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

        protected void SwipeLeft_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para a esquerda!", "Ok");
            MoveContainer((PanContainerView)sender, 0, 0);
        }

        protected void SwipeRight_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para a direita!", "Ok");
            MoveContainer((PanContainerView)sender, 0, 0);
        }

        protected void SwipeUp_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para cima!", "Ok");
            MoveContainer((PanContainerView)sender, 0, 0);
        }

        protected void SwipeDown_Event(object sender, EventArgs e)
        {
            DisplayAlert("Evento", "Deslizou para baixo!", "Ok");
            MoveContainer((PanContainerView)sender, 0, 0);
        }

        protected void SwipeUpdate_Event(object sender, EventArgs e)
        {
            var evento = (PanUpdatedEventArgs)e;
            MoveContainer((PanContainerView)sender, evento.TotalX, evento.TotalY);
        }

        private void MoveContainer(PanContainerView container, double x, double y)
        {
            container.TranslationX = x;
            container.TranslationY = y;
        }
    }
}
