using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AComicConundrum_ASeholm.Models.Marvel
{
    public class Marvel_Grouping
    {
        [JsonProperty("available")]
        public int iAvailable { get; set; }


        [JsonProperty("collectionURI")]
        public string strCollectionURI { get; set; }


        [JsonProperty("items")]
        public Dictionary<string, Marvel_Items> _items { get; set; }


        [JsonProperty("returned")]
        public int iReturned { get; set; }
        
    }
}