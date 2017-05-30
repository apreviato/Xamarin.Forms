using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Popup
{
    public class PopupLayout
    {
        static ContentView _fundo;
        static AbsoluteLayout _content;
        static uint _tempoEfeito;
        public static bool IsVisivel { get { return ((ContentPage)App.Current.MainPage).Content == _content; } }
        public async static void ShowPopup(View popup, string corFundo = "#C0808080", uint tempoEfeito = 200)
        {
            _tempoEfeito = tempoEfeito;

            _content = new AbsoluteLayout();

            _content.Children.Add(((ContentPage)App.Current.MainPage).Content);

            ((ContentPage)App.Current.MainPage).Content = _content;

            _fundo = new ContentView();
            _fundo.IsVisible = true;
            _fundo.BackgroundColor = Color.FromHex(corFundo);
            
            _fundo.Content = popup;

            _fundo.GestureRecognizers.Add(new TapGestureRecognizer(async (e) => {
                HidePopup();
            }));

            _content.Children.Add(_fundo, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            await _fundo.FadeTo(0,0);
            await _fundo.FadeTo(1, tempoEfeito);
        }

        public static async void HidePopup()
        {
            try
            {
                if (IsVisivel)
                {
                    await _fundo.FadeTo(0, _tempoEfeito);
                    _fundo.Content = null;
                    ((AbsoluteLayout)((ContentPage)App.Current.MainPage).Content).Children.Remove(_fundo);
                    ((ContentPage)App.Current.MainPage).Content = _content.Children[0];
                }
            }
            catch(Exception ex)
            { }
        }
    }
}
