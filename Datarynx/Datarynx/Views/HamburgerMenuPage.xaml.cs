using Datarynx.Enums;
using Datarynx.Model;
using Datarynx.ViewModels;
using Xamarin.Forms;

namespace Datarynx.Views
{
    public partial class HamburgerMenuPage : MasterDetailPage
    {
        public HamburgerMenuPage()
        {
            InitializeComponent();
            BindingContext = new HamburgerMenuPageViewModel();
            MasterBehavior = MasterBehavior.Split;
            IsPresented = true;
            MessagingCenter.Subscribe<HomeMenuItem>(this, nameof(HomeMenuItem), NavigateFromMenu);
        }

        public void NavigateFromMenu(HomeMenuItem homeMenuItem)
        {
            switch (homeMenuItem.MenuItemType)
            {
                case MenuItemType.Logout:
                    Detail =  new NavigationPage(new LogoutPage());
                    break;
                case MenuItemType.About:
                    Detail = new NavigationPage(new AboutPage());
                    break;
            }
            IsPresented = false;
        }
    }
}
