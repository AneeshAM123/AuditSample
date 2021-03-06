using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Datarynx.Enums;
using Datarynx.Interface;
using Datarynx.Model;
using Xamarin.Forms;

namespace Datarynx.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        List<Audit> _allAudits;
        #region Properties
        ObservableCollection<Audit> audits;
        public ObservableCollection<Audit> Audits
        {
            get { return audits; }
            set { SetProperty(ref audits, value); }
        }

        bool sortByAscending;
        public bool SortByAscending
        {
            get { return sortByAscending; }
            set { SetProperty(ref sortByAscending, value); }
        }

        int threshold = 50;
        public int Threshold
        {
            get { return threshold; }
            set { SetProperty(ref threshold, value); }
        }

        #endregion

        #region Commands
        public ICommand MenuCommand { get; set; }
        public ICommand SortCommand { get; set; }

        public ICommand RemainingItemsThresholdReachedCommand { get; set; }

        #region ctr
        public HomePageViewModel()
        {
            MenuCommand = new Command(async () => { await ExecuteMenuCommand(); });
            SortCommand = new Command(ExecuteSortCommand);
            RemainingItemsThresholdReachedCommand = new Command(ExecuteRemainingItemsThresholdReachedCommand);
            GetAudits();
        }
        #endregion


        #endregion

        #region Methods

        #region LoadData

        private void GetAudits()
        {
            var dataService = DependencyService.Get<IDataService>();
            _allAudits = dataService.GetAudits();
            Audits = new ObservableCollection<Audit>(_allAudits.Take(threshold));
        }
        #endregion

        #region Sort
        private void ExecuteSortCommand()
        {
            SortByAscending = !SortByAscending;
            if (SortByAscending)
            {
                _allAudits = new List<Audit>(_allAudits.OrderBy(x => x.WeekDate));
            }
            else
            {
                _allAudits = new List<Audit>(_allAudits.OrderByDescending(x => x.WeekDate));
            }
            Audits = new ObservableCollection<Audit>(_allAudits.Take(threshold));
        }

        private void ExecuteRemainingItemsThresholdReachedCommand()
        {
            try
            {
                var nextItems = _allAudits.GetRange(Audits.Count - 1, threshold);
                nextItems?.ForEach((item) =>
                {
                     Audits?.Add(item);
                });
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Menu
        private async Task ExecuteMenuCommand()
        {
            await Navigate(PageType.HamburgerMenu);
        }
        #endregion

        #endregion
    }
}
