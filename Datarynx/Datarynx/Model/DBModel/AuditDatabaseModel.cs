using Realms;

namespace Datarynx.Model
{
    public class AuditDatabaseModel : RealmObject
    {
        public string WeekNumber { get; set; }

        public string WeekDate { get; set; }

        public string StoreName { get; set; }

        public string StoreAddress { get; set; }

        public string CodingType { get; set; }

        public int TaskState { get; set; }
    }
}
