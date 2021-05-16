using System;
using Datarynx.Enums;
using Newtonsoft.Json;

namespace Datarynx.Model
{
    public class Audit
    {
        [JsonProperty("week-no")]
        public string WeekNumber { get; set; }

        [JsonProperty("week-date")]
        public DateTime WeekDate { get; set; }

        [JsonProperty("store-name")]
        public string StoreName { get; set; }

        [JsonProperty("store-address")]
        public string StoreAddress { get; set; }

        [JsonProperty("coding-type")]
        public string CodingType { get; set; }

        [JsonProperty("Task-State")]
        public TaskState TaskState { get; set; }
    }
}
