using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PanContainer
{
    public class PanContainerView : ContentView
    {
        public Boolean IsPanUpdate = false;
        double inicioX, fimX, inicioY, fimY;

        public event EventHandler Direita;
        public event EventHandler Esquerda;
        public event EventHandler Cima;
        public event EventHandler Baixo;

        public PanContainerView()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            this.IsPanUpdate = true;
            if (e.StatusType == GestureStatus.Started)
                inicioX = fimX = inicioY = fimY = 0;
            else if (e.StatusType == GestureStatus.Running)
            {
                if (inicioX == 0)
                    inicioX = e.TotalX;
                else
                    fimX = e.TotalX;

                if (inicioY == 0)
                    inicioY = e.TotalY;
                else
                    fimY = e.TotalY;
            }
            else if (e.StatusType == GestureStatus.Completed)
            {
                if (inicioX == inicioY)
                {
                    this.IsPanUpdate = false;
                }
                else
                {
                    var difHorizontal = fimX - inicioX;

                    if (difHorizontal < 0)
                        difHorizontal *= -1;

                    var difVertical = fimY - inicioY;

                    if (difVertical < 0)
                        difVertical *= -1;

                    if (difHorizontal > difVertical)
                    {
                        if (inicioX < fimX) // Direita
                        {
                            if (Direita != null)
                                Direita(null, new EventArgs());
                        }
                        else if (inicioX > fimX) // Esquerda
                        {
                            if (Esquerda != null)
                                Esquerda(null, new EventArgs());
                        }
                    }
                    else
                    {
                        if (inicioY < fimY) // Baixo
                        {
                            if (Baixo != null)
                                Baixo(null, new EventArgs());
                        }
                        else if (inicioY > fimY) // Cima
                        {
                            if (Cima != null)
                                Cima(null, new EventArgs());
                        }
                    }
                }

                inicioX = fimX = inicioY = fimY = 0;
            }
        }
    }
}