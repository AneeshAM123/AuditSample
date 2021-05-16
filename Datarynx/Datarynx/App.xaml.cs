using System.Collections.Generic;
using System.Threading.Tasks;
using Datarynx.Interface;
using Datarynx.Model;
using Datarynx.Service;
using Datarynx.Views;
using Xamarin.Forms;

namespace Datarynx
{
    public partial class App : Application
    {
        //json file contains audits
        string auditJson = "Datarynx.Json.audit.json";


        public App()
        {
            InitializeComponent();
            RegisterTypes();
            MainPage = new LoadingPage();
            DownloadAudtis();
        }

        private void RegisterTypes()
        {
            DependencyService.Register<IDataService>();
        }

        public async void DownloadAudtis()
        {
            await Task.Run(async () =>
            {
                var dataService = DependencyService.Get<IDataService>();
                var audits = JsonService<List<Audit>>.GetDeserializedData(auditJson);
                await dataService.InsertAudits(audits);

                Device.BeginInvokeOnMainThread(() =>
                {
                    MainPage = new NavigationPage(new HomePage());
                });
            });
        }
    }
}
