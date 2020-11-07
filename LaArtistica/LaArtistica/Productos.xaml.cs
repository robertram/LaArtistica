using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Modelos;

namespace LaArtistica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs args)
        {
            //await DisplayAlert("Alert", "You have been alerted", "OK");

            ((NavigationPage)this.Parent).PushAsync(new Compra());
        }
    }
}