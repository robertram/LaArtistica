using LaArtistica.Models;
using LaArtistica.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace LaArtistica.ViewModel
{
    public class ProductViewModel : BindableObject
    {
        private ObservableCollection<Products> _products;

        public ProductViewModel()
        {
            LoadData();
        }

        public ObservableCollection<Products> Products
        {
            get { return _products;  }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public void LoadData()
        {
            Products = new ObservableCollection<Products>(ProductService.Instance.GetProducts());
        }
    }
}



