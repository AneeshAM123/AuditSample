using System.Collections.Generic;
using System.Threading.Tasks;
using Datarynx.Model;

namespace Datarynx.Interface
{
    public interface IDataService
    {
        Task InsertAudits(List<Audit> items);
        List<Audit> GetAudits();
    }
}
