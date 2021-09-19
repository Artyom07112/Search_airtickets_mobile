using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace POL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            Anime();  
            Vizov();
        }


        private async void Anime()
        {
            Action<double> forw = input => bdGradient.AnchorY = input;
            Action<double> bask = input => bdGradient.AnchorY = input;

            
            bdGradient.Animate(name: "forw", callback: forw, start: 0, end: 1, length: 2500, easing: Easing.SinIn);
                await Task.Delay(2500);
            
            bdGradient.Animate(name: "bask", callback: forw, start: 1, end: 0, length: 2500, easing: Easing.SinIn);
                await Task.Delay(2500);

             
        }

        public async void Vizov()
        {
            await Task.Delay(5500);

            await Navigation.PushModalAsync(new POL.TabbedPage1());
        }
    }
}
