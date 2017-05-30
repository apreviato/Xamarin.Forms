using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Popup
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            var s = new StackLayout();
            s.BackgroundColor = Color.White;
            s.HeightRequest = 175;
            s.WidthRequest = 300;
            s.HorizontalOptions = LayoutOptions.Center;
            s.VerticalOptions = LayoutOptions.Start;
            s.Margin = new Thickness(0, 20, 0, 0);

            var b = new Button();
            b.Text = "Fechar";
            s.VerticalOptions = LayoutOptions.Center;
            b.Clicked += delegate {
                PopupLayout.HidePopup();
            };

            s.Children.Add(b);
            
            PopupLayout.ShowPopup(s);
        }
        
    }
}
