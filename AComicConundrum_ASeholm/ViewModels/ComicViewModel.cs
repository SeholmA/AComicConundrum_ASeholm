using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AComicConundrum_ASeholm.Models;
using AComicConundrum_ASeholm.Models.Marvel;

namespace AComicConundrum_ASeholm.ViewModels
{
    public class ComicViewModel
    {
        public virtual List<Comic> MyComicList { get; set; }

        public virtual Rootobject marvelRootObj { get; set; }

        public virtual IEnumerable<Results> marvelResults { get; set; }

        public virtual IEnumerable<Comic> ComicVineComicList { get; set; }

        public ComicViewModel()
        {
            MyComicList = new List<Comic>();
            marvelRootObj = new Rootobject();
            marvelResults = Enumerable.Empty<Results>();
            ComicVineComicList = Enumerable.Empty<Comic>();
        }
    }
}