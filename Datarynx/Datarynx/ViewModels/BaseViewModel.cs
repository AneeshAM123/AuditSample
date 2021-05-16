using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Datarynx.Enums;
using Datarynx.Views;
using Xamarin.Forms;

namespace Datarynx.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
           
        }

        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            RaisePropertyChanged(propertyName);
            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void OnPropertyChanged(string propertyName) { }
        
        #endregion

        public async Task Navigate(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.HamburgerMenu:
                    await Application.Current.MainPage.Navigation.PushAsync(new HamburgerMenuPage());
                    break;
                default:
                    break;
            }
        }

        public async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
