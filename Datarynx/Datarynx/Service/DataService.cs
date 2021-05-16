using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datarynx.Helpers;
using Datarynx.Interface;
using Datarynx.Model;
using Datarynx.Service;
using Realms;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataService))]
namespace Datarynx.Service
{
    public class DataService : IDataService
    {
        public async Task InsertAudits(List<Audit> items)
        {
            try
            {
                await Realm.GetInstance().WriteAsync((a) =>
                {
                    Realm.GetInstance().RemoveAll<AuditDatabaseModel>();
                    foreach (var item in items)
                    {
                        Realm.GetInstance().Add(item.ToDatabaseModel());
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Audit> GetAudits()
        {
            try
            {
                var audits = Realm.GetInstance().All<AuditDatabaseModel>();
                return audits.ToList().ToListModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}