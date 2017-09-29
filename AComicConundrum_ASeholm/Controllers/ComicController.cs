using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AComicConundrum_ASeholm.DAL;
using AComicConundrum_ASeholm.Models;
using AComicConundrum_ASeholm.Models.Marvel;
using AComicConundrum_ASeholm.Services;
using AComicConundrum_ASeholm.ViewModels;

namespace AComicConundrum_ASeholm.Controllers
{
    public class ComicController : Controller
    {
        /// <summary>
        /// Class Variable. 
        /// Instantiate a database context object
        /// </summary>
        private ComicContext db = new ComicContext();

        private readonly ComicViewModel m_vm;

        private MarvelComicService m_marvelservice;

        /// <summary>
        /// Constructor for ComicController.
        /// </summary>
        public ComicController()
        {
            m_vm = new ComicViewModel();
            m_marvelservice = new MarvelComicService();
        }

        // GET: Comic
        /// <summary>
        /// Gets a list of comics from the Comics entity set by reading
        /// the Comics property of the database context.
        /// </summary>
        /// <returns>A list of comics</returns>
        public ActionResult Index()
        {
            m_vm.MyComicList = db.Comics.ToList();
            return View(db.Comics.ToList());
        }

        // GET: Comic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // GET: Comic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,strTitle,iIssueNumber,strSeries,strPublisher,strAuthor,strArtist,iYearPublished,bRead")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Comics.Add(comic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comic);
        }

        // GET: Comic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: Comic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,strTitle,iIssueNumber,strSeries,strPublisher,strAuthor,strArtist,iYearPublished")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comic);
        }

        // GET: Comic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comic comic = db.Comics.Find(id);
            if (comic == null)
            {
                return HttpNotFound();
            }
            return View(comic);
        }

        // POST: Comic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comic comic = db.Comics.Find(id);
            db.Comics.Remove(comic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// JsonResult is an ActionResult type in MVC. It helps to send the content in JavaScript Obect Notation (JSON) format.
        /// </summary>
        /// <param name="_strType"></param>
        /// <param name="_strSearch"></param>
        /// <returns></returns>
        public JsonResult GetComics(string _filter, string _order, string _limit, string _text)
        {
            //Text
            string text = "";
            if (_text != "" && _text != null)
                text = _text.Replace(",", "%2C").Replace(" ", "%20");
            else
                text = "Spider-Man";

            //Limit
            string limit = "";
            if (_limit != "" && _limit != null && _limit != "Limit" && _limit != " Limit ")
                limit = _limit.Replace("S", String.Empty).Replace("h", String.Empty).Replace("o", String.Empty).Replace("w", String.Empty).Replace(" ", String.Empty);
            else
                limit = "25";

            //Order
            string order = "";
            switch (_order)
            {
                case " Title (asc)":
                    order = "title";
                    break;
                case " Title (desc)":
                    order = "-title";
                    break;
                case " Issue# (acs)":
                    order = "issueNumber";
                    break;
                case " Issue# (desc)":
                    order = "-issueNumber";
                    break;
                default:
                    order = "title";
                    break;
            }

            //Filter
            if (_filter != null)
                _filter.Replace(" ", String.Empty);
            switch (_filter)
            {
                case " By Title":
                    m_vm.marvelRootObj = m_marvelservice.GetComicsByTitle(text, order, limit).Result;
                    break;
                case " By Character":
                    m_vm.marvelRootObj = m_marvelservice.GetComicsByCharacter(text, order, limit).Result;
                    break;
                case " By Contributor":
                    m_vm.marvelRootObj = m_marvelservice.GetComicsByContributor(text, order, limit).Result;
                    break;
                default:
                    m_vm.marvelRootObj = m_marvelservice.GetComicsByTitle(text, order, limit).Result;
                    break;
            }
           
            return Json(m_vm.marvelRootObj, JsonRequestBehavior.AllowGet);
        }
    }
}
