using System;
using System.Collections.Generic;
using Datarynx.Enums;
using Datarynx.Model;

namespace Datarynx.Helpers
{
    public static class Mapper
    {
        public static AuditDatabaseModel ToDatabaseModel(this Audit audit)
        {
            return new AuditDatabaseModel
            {
                WeekNumber = audit.WeekNumber,
                WeekDate = audit.WeekDate.ToString(),
                CodingType = audit.CodingType,
                StoreAddress = audit.StoreAddress,
                StoreName = audit.StoreName,
                TaskState = (int)audit.TaskState,
            };
        }

        public static Audit ToModel(this AuditDatabaseModel auditDatabaseModel)
        {
            return new Audit
            {
                WeekNumber = auditDatabaseModel.WeekNumber,
                WeekDate = Convert.ToDateTime(auditDatabaseModel.WeekDate),
                CodingType = auditDatabaseModel.CodingType,
                StoreAddress = auditDatabaseModel.StoreAddress,
                StoreName = auditDatabaseModel.StoreName,
                TaskState = (TaskState)auditDatabaseModel.TaskState,
            };
        }

        public static List<Audit> ToListModel(this List<AuditDatabaseModel> auditDatabaseModel)
        {
            var list = new List<Audit>();
            auditDatabaseModel.ForEach((dmbModel) =>
            {
                list.Add(dmbModel.ToModel());
            });
            return list;
        }
    }
}
