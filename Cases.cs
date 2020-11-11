using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19
{
    public class Cases
    {
        [JsonProperty("NIS5")]
        public int CaseNumber { get; set; }
        [JsonProperty("DATE")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date { get; set; }
        [JsonProperty("TX_DESCR_NL")]
        public string TxNl { get; set; }
        [JsonProperty("TX_DESCR_FR")]
        public string TxFr { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_NL")]
        public string TxAdmDstrNl { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_FR")]
        public string TxAdmDstrFr { get; set; }
        [JsonProperty("PROVINCE")]
        public string Province { get; set; }
        [JsonProperty("REGION")]
        public string Region { get; set; }
        [JsonProperty("CASES")]
        public string NumberOfCases { get; set; }
    }
}
