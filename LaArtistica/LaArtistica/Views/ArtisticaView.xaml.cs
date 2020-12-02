using System;
using LaArtistica.ViewModel;
using Xamarin.Forms;

namespace LaArtistica.Views
{
    public partial class ArtisticaView : ContentPage
    {
        public ArtisticaView()
        {
            InitializeComponent();


            BindingContext = new ProductViewModel();
        }

        
    }
}