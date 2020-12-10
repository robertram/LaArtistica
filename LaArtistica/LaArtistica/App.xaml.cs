using System;
using LaArtistica.Views.AccessView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;
using System.Linq;
using System.Threading.Tasks;
using LaArtistica.Services;
using System.Collections.Generic;
using LaArtistica.Views;
using LaArtistica.Views.ProductsView;

namespace LaArtistica
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            InitNavigation();
            UserRepository.Inicializador(filename);
            //VentaRepository.Inicializador(filename);
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new ArtisticaView());

            Task InitNavigation()
            {
                return NavigationService.Instance.InitializeAsync();
            }
            List<Products> products = UserRepository.Instancia.GetAllProducts().ToList();

            if (products.Count()> 0)
            {
               /* foreach (Products p in products)
                {
                    UserRepository.Instancia.DeleteProduct(p);
                } */
            }
            else
            {
                //UserRepository.Instancia.AddNewProduct("Sillon Cafe", "14", "45.000", "2", "Sillon.png", "https://drive.google.com/file/d/15nSaE3VYS2IG4E82R2snKmYiVT1e7Gvk/view?usp=sharing");
                //UserRepository.Instancia.AddNewProduct("Escritorio", "5", "75.000", "2", "Escritorio.png", "https://drive.google.com/file/d/1zcVH7kM_iLQBnKxYWJtxZr9K2mWoyZVZ/view?usp=sharing");
                //UserRepository.Instancia.AddNewProduct("Sillon", "5", "75.000", "2", "Sillon.png", "https://drive.google.com/file/d/15nSaE3VYS2IG4E82R2snKmYiVT1e7Gvk/view?usp=sharing");
                //UserRepository.Instancia.AddNewProduct("Sillon Casual", "5", "75.000", "2", "SillonCasual.png", "https://drive.google.com/file/d/1l4wlYtik1z9B9wypORq7mDjurHFgIEi1/view?usp=sharing");
                //UserRepository.Instancia.AddNewProduct("Sillon Grande", "5", "75.000", "2", "SillonGrande.png", "https://drive.google.com/file/d/10z-aM-UhOfjra3m-b0SReRtdTFe4xT_f/view?usp=sharing");
                //UserRepository.Instancia.AddNewProduct("Sillon Rojo", "5", "75.000", "2", "SillonRojo.png", "https://drive.google.com/file/d/1cOaO50MC4cC7Sk4NouryCnBgSwO8IZ0W/view?usp=sharing");
                 //Descripcion = "A brilliant take on urban chic styling, this loveseat in vibrant blue makes high design highly affordable. Distinctive elements include quilted channel stitching for clean-lined allure and a velvety soft fabric you'll love living with. Sculptural track arms up the wow factor. If you're looking for big style on more modest scale, you're sure to appreciate this loveseat's space-conscious 59 wide profile."
            }
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
