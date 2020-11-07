using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaArtistica
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnIngresar.Clicked += BtnIngresar_Clicked;
            btnRegristrarse.Clicked += BtnRegristrarse_Clicked;
        }

        private void BtnRegristrarse_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if(username.Text != null && password.Text != null)
            {
                if(username.Text.Length > 0 && password.Text.Length > 0)
                {
                    Console.WriteLine("Ingreso");
                    if ((username.Text == "admin") && (password.Text == "123"))
                    {
                        Application.Current.MainPage = new Productos();
                    }
                }
                else
                {
                    llenarAlert();
                }
            }
            else
            {
                llenarAlert();
            }
        }

        private async Task llenarAlert()
        {
            await DisplayAlert("La Artistica", "Por favor ingrese su usuario y contraseña", "Aceptar");
        }

    }
}
