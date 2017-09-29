using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AComicConundrum_ASeholm.Models.Marvel
{
    public class Marvel_Items
    {
        [JsonProperty("resourceURI")]
        public string strResourceURI { get; set; }


        [JsonProperty("name")]
        public string strName { get; set; }


        [JsonProperty("type")]
        public string strType { get; set; }


        [JsonProperty("role")]
        public string strRole { get; set; }


        [JsonProperty("price")]
        public string strPrice { get; set; }


        [JsonProperty("date")]
        public string strDate { get; set; }


        [JsonProperty("url")]
        public string strURL { get; set; }
    }
}