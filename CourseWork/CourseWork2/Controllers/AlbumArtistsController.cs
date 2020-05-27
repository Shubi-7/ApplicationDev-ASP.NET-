using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWork2.Models;

namespace CourseWork2.Controllers
{
    public class AlbumArtistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AlbumArtists
        public ActionResult Index()
        {
            var AlbumArtists = db.AlbumArtists.Include(a => a.Artist);
            return View(AlbumArtists.ToList());
        }

        // GET: AlbumArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists AlbumArtist = db.AlbumArtists.Find(id);
            if (AlbumArtist == null)
            {
                return HttpNotFound();
            }
            return View(AlbumArtist);
        }

        // GET: AlbumArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name");
            return View();
        }

        // POST: AlbumArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,AlbumId")] AlbumArtists AlbumArtist)
        {
            if (ModelState.IsValid)
            {
                db.AlbumArtists.Add(AlbumArtist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", AlbumArtist.ArtistId);
            return View(AlbumArtist);
        }

        // GET: AlbumArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists AlbumArtist = db.AlbumArtists.Find(id);
            if (AlbumArtist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", AlbumArtist.ArtistId);
            return View(AlbumArtist);
        }

        // POST: AlbumArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,AlbumId")] AlbumArtists AlbumArtist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(AlbumArtist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", AlbumArtist.ArtistId);
            return View(AlbumArtist);
        }

        // GET: AlbumArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists AlbumArtist = db.AlbumArtists.Find(id);
            if (AlbumArtist == null)
            {
                return HttpNotFound();
            }
            return View(AlbumArtist);
        }

        // POST: AlbumArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumArtists AlbumArtist = db.AlbumArtists.Find(id);
            db.AlbumArtists.Remove(AlbumArtist);
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
    }
}

