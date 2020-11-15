﻿using System;
using LaArtistica.Views.AccessView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;

namespace LaArtistica
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UserRepository.Inicializador(filename);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
