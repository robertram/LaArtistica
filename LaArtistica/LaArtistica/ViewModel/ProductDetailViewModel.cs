using System.Threading.Tasks;
using LaArtistica.Models;
using LaArtistica.ViewModel.Base;


namespace LaArtistica.ViewModel

{
    public class ProductDetailViewModel : ViewModelBase
    {
        private Products _products;

        public Products Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public override Task InitializeAsync (object navigationData)
        {
            if (navigationData is Products)
                Products = (Products)navigationData;

            return base.InitializeAsync(navigationData);
        }
    }
}

