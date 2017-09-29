using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AComicConundrum_ASeholm.Models.Marvel;
using Newtonsoft.Json;

namespace AComicConundrum_ASeholm.Models.Marvel
{
    public class Results
    {
        [JsonProperty("offset")]
        public int iOffset { get; set; }

        [JsonProperty("limit")]
        public int iLimit { get; set; }

        [JsonProperty("total")]
        public int iTotal { get; set; }

        [JsonProperty("count")]
        public int iCount { get; set; }

        [JsonProperty("results")]
        public Dictionary<string, Marvel_Comic> MarvelComics { get; set; }//public Dictionary<string, Comic> Comics { get; set; }
    }
}