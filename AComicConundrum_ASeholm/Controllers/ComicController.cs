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
        public JsonResult GetComics(/*string _strType,*/ string _strSearch)
        {
            /*
            IEnumerable<Comic> comics = Enumerable.Empty<Comic>();

            switch (_strType)
            {
                case "Artist":
                    break;
                case "Character":
                    break;
                case "Creator":
                    break;
                case "Title":
                    comics = m_service.GetComicsByTitle(_strSearch).Result;
                    break;
                case "Writer":
                    break;
                default:
                    comics = m_service.GetComicsByTitle(_strSearch).Result;
                    break;
            }*/
            //timestamp+public+private
            //TODO: Fix return
            try
            {
                m_vm.marvelRootObj = m_marvelservice.GetComicsByTitle(_strSearch).Result;
            }
            catch(Exception ex) { }

            //Rootobject ro = new Rootobject();
            //ro.data.results[0].creators.items[0].name
            return Json(m_vm.marvelRootObj, JsonRequestBehavior.AllowGet);
        }
    }
}
