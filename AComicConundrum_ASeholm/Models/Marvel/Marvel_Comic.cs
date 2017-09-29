using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AComicConundrum_ASeholm.Models.Marvel
{
    public class Marvel_Comic
    {
        [JsonProperty("id")]
        //[DisplayName("ID")]
        public int iID { get; set; }

        [JsonProperty("digitalId")]
        //[DisplayName("Digital ID")]
        public int iDigitalID { get; set; }

        [JsonProperty("title")]
        //[DisplayName("Title")]
        public string strTitle { get; set; }

        [JsonProperty("issueNumber")]
        //[DisplayName("Issue Number")]
        public int iIssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        //[DisplayName("Variant Description")]
        public string strVariantDescription { get; set; }

        [JsonProperty("description")]
        //[DisplayName("Description")]
        public string strDescription { get; set; }

        [JsonProperty("modified")]
        //[DisplayName("Last Modified")]
        public string strDateModified { get; set; }

        [JsonProperty("format")]
        //[DisplayName("Format")]
        public string strFormat { get; set; }

        [JsonProperty("pageCount")]
        //[DisplayName("Page Count")]
        public int iPageCount { get; set; }

        [JsonProperty("textObjects")]
        //[DisplayName("Text Objects")]
        public Dictionary<string, Marvel_Grouping> _textObjects { get; set; }

        [JsonProperty("resourceURI")]
        //[DisplayName("Resource URI")]
        public string strResourceURI { get; set; }

        [JsonProperty("urls")]
        //[DisplayName("URLs")]
        public Dictionary<string, Marvel_Grouping> _urls { get; set; }

        [JsonProperty("series")]
        //[DisplayName("Series")]
        public Dictionary<string, Marvel_Grouping> _series { get; set; }

        [JsonProperty("variants")]
        //[DisplayName("Variants")]
        public Dictionary<string, Marvel_Grouping> _variants { get; set; }

        [JsonProperty("collections")]
        //[DisplayName("Collections")]
        public Dictionary<string, Marvel_Grouping> _collections { get; set; }

        [JsonProperty("collectedIssues")]
        //[DisplayName("Collected Issues")]
        public Dictionary<string, Marvel_Grouping> _collectedIssues { get; set; }

        [JsonProperty("dates")]
        //[DisplayName("Dates")]
        public Dictionary<string, Marvel_Grouping> _dates { get; set; }

        [JsonProperty("prices")]
        //[DisplayName("Prices")]
        public Dictionary<string, Marvel_Grouping> _prices { get; set; }

        [JsonProperty("thumbnail")]
        //[DisplayName("Thumbnail")]
        public Dictionary<string, Marvel_Image> _thumbnail { get; set; }

        [JsonProperty("images")]
        //[DisplayName("Images")]
        public Dictionary<string, Marvel_Image> _images { get; set; }

        [JsonProperty("creators")]
        //[DisplayName("Creators")]
        public Dictionary<string, Marvel_Grouping> _creators { get; set; }

        /// <summary>
        /// Key = Role, Value = Name
        /// </summary>
        //[DisplayName("Artists")]
       // public Dictionary<string, string> _Artists { get; set; }

        /// <summary>
        /// Key = Role, Value = Name
        /// </summary>
        //[DisplayName("Writers")]
        //public Dictionary<string, string> _Writers { get; set; }

        [JsonProperty("characters")]
        //[DisplayName("Characters")]
        public Dictionary<string, Marvel_Grouping> _characters { get; set; }

        [JsonProperty("stories")]
        //[DisplayName("Stories")]
        public Dictionary<string, Marvel_Grouping> _stories { get; set; }

        [JsonProperty("events")]
        //[DisplayName("Events")]
        public Dictionary<string, Marvel_Grouping> _events { get; set; }
    }
}