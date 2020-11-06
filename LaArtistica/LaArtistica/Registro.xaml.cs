using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaArtistica
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            btnRegistro.Clicked += BtnRegistro_Clicked;
        }

        private void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            if(nombre.Text != null && apellido.Text != null && correo.Text != null)
            {
                if (nombre.Text.Length > 0 && apellido.Text.Length > 0 && correo.Text.Length > 0)
                {
                    registroAlert();
                    Application.Current.MainPage.Navigation.PopAsync();
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

        private async Task registroAlert()
        {
            await DisplayAlert("Registro", "Se ha registrado correctamente", "Aceptar");
        }

        private async Task llenarAlert()
        {
            await DisplayAlert("Registro", "Por favor llene todos los campos correctamente", "Aceptar");
        }
    }
}