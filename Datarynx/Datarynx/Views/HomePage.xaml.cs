using Datarynx.ViewModel;
using Xamarin.Forms;

namespace Datarynx.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }
    }
}
