using Xamarin.Forms;
using System.Threading.Tasks;

namespace LaArtistica.ViewModel.Base
{
    public class ViewModelBase : BindableObject
    {
        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false); 
    }
}
