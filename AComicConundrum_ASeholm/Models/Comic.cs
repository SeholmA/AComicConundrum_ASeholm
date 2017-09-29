using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Newtonsoft.Json;

namespace AComicConundrum_ASeholm.Models
{
    public class Comic
    {
        /// <summary>
        /// The unique ID of the comic resource (Primary Key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Title of the Comic
        /// </summary>
        [DisplayName("Title")]
        public string strTitle { get; set; }

        /// <summary>
        /// The number of issues in the series (will generally be 0 for collection formats)
        /// </summary>
        [DisplayName("Issue Number")]
        public int iIssueNumber { get; set; }

        /// <summary>
        /// The Series, or Collection, it is a part of.
        /// This is left blank if it is a single issue release.
        /// Typicially a summary representation of the series to which this comic belongs.
        /// </summary>
        [DisplayName("Series")]
        public string strSeries { get; set; }

        /// <summary>
        /// The Name of the Creators - Writers or Artists (or publishing company)
        /// </summary>
        [DisplayName("Publisher")]
        public string strPublisher { get; set; }

        /// <summary>
        /// The First & Last Name of the main author/writer
        /// </summary>
        [DisplayName("Author")]
        public string strAuthor { get; set; }

        /// <summary>
        /// The First & Last Name of the main artist (or the cover artist)
        /// </summary>
        [DisplayName("Artist")]
        public string strArtist { get; set; }

        /// <summary>
        /// Year the comic was published
        /// </summary>
        [DisplayName("Year Published")]
        public int iYearPublished { get; set; }

        /// <summary>
        /// Whether or not this comic has been read by the user.
        /// </summary>
        [DisplayName("Read")]
        public bool bRead { get; set; }

        /// <summary>
        /// The preferred (non-variant) description of the comic.
        /// </summary>
        [DisplayName("Description")]
        public string strDescription { get; set; }

        /// <summary>
        /// The number of story pages in the comic.
        /// </summary>
        [DisplayName("Page Count")]
        public int iPageCount { get; set; }

        /// <summary>
        /// The cover/promotional image (path + file exension)
        /// </summary>
        public string strImageUrl { get; set; }
    }
}