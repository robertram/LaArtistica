using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using LaArtistica.Models;
using LaArtistica.Views.ProductsView;

namespace LaArtistica.Views.AccessView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();
            btnChangePass.Clicked += BtnChangePass_Clicked;
            btnCancelChangePass.Clicked += BtnCancelChangePass_Clicked;
        }

        private void BtnCancelChangePass_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnChangePass_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtRePassword1.Text) || !string.IsNullOrEmpty(txtRePassword2.Text))
            {
                List<User> users = UserRepository.Instancia.GetAllUsers().ToList();
                bool canChange = false;

                foreach(User user in users)
                {
                    if (txtEmail.Text.Equals(user.Email))
                    {
                        canChange = true;
                    }
                }
                if (canChange)
                {
                    if (txtRePassword1.Text.Equals(txtRePassword2.Text))
                    {
                        foreach (User user in users)
                        {
                            if (txtEmail.Text.Equals(user.Email))
                            {
                                passChanged();
                                UserRepository.Instancia.getUser(txtRePassword1.Text, txtEmail.Text);
                                Application.Current.MainPage.Navigation.PopAsync();
                            }
                        }
                    }
                    else
                    {
                        wrongPass();
                    }
                }
            }
            else
            {
                empty();
            }
        }

        private async Task empty()
        {
            await DisplayAlert("La Artistica", "Debes llenar los datos para poder cambiar tu contraseña, intentalo de nuevo", "Aceptar");
        }

        private async Task wrongPass()
        {
            await DisplayAlert("La Artistica", "Las contraseñas ingresadas no son las mismas, intentalo de nuevo", "Aceptar");
        }

        private async Task passChanged()
        {
            await DisplayAlert("La Artistica", "Contraseña cambiada!", "Aceptar");
        }

    }
}