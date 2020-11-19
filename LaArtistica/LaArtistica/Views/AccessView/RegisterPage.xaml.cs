﻿using System;
using System.Collections.Generic;
using System.IO;
using LaArtistica.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace LaArtistica.Views.AccessView
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            btnRegister.Clicked += BtnRegister_Clicked;
            btnLogIn.Clicked += BtnLogIn_Clicked;
        }

        private void BtnLogIn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                if(txtPassword.Text.Length < 8)
                {
                    passwordSize();
                }
                else
                {
                    UserRepository.Instancia.AddNewUser(txtEmail.Text,txtPassword.Text);
                    if (UserRepository.Instancia.EstadoMensaje.Equals("Insertado"))
                    {
                        succesfulRegistered();
                        Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        errorRegister();
                    }
                }
            }
            else
            {
                noDataAlert();
            }
        }

        private async Task errorRegister()
        {
            await DisplayAlert("La Artistica", "Hubo un error al registrar", "Aceptar");
        }

        private async Task succesfulRegistered()
        {
            await DisplayAlert("La Artistica", "Se registro con exito", "Aceptar");
        }

        private async Task passwordSize()
        {
            await DisplayAlert("La Artistica", "La contraseña debe tener al menos 8 caracteres", "Aceptar");
        }

        private async Task noDataAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca todos los datos", "Aceptar");
        }
    }
}
