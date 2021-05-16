using System.Collections.Generic;
using Datarynx.Enums;
using Datarynx.Helpers;
using Datarynx.Model;
using Datarynx.ViewModel;
using Xamarin.Forms;

namespace Datarynx.ViewModels
{
    public class HamburgerMenuPageViewModel : BaseViewModel
    {
        #region Properties
        List<HomeMenuItem> homeMenuItems;
        public List<HomeMenuItem> HomeMenuItems
        {
            get { return homeMenuItems; }
            set { SetProperty(ref homeMenuItems, value); }
        }

        HomeMenuItem selectedMenuItem;
        public HomeMenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { SetProperty(ref selectedMenuItem, value); }
        }
        #endregion

        #region ctr
        public HamburgerMenuPageViewModel()
        {
            HomeMenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {MenuItemType = MenuItemType.About, Title= Constants.About },
                new HomeMenuItem {MenuItemType = MenuItemType.Logout, Title= Constants.Logout },
                new HomeMenuItem {MenuItemType = MenuItemType.Home, Title= Constants.Home  }
            };
        }

        #endregion

        #region Methods

        public async override void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals(nameof(SelectedMenuItem)))
            {
                if (SelectedMenuItem != null)
                {
                    if (SelectedMenuItem.MenuItemType == MenuItemType.Home)
                    {
                        await GoBack();
                    }
                    else
                    {
                        MessagingCenter.Send(SelectedMenuItem, nameof(HomeMenuItem));
                    }
                }
            }
        }

        #endregion
    }
}
