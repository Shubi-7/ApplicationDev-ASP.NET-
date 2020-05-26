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
            var albumArtists = db.AlbumArtists.Include(a => a.Album).Include(a => a.Artist);
            return View(albumArtists.ToList());
        }

        // GET: AlbumArtists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists albumArtists = db.AlbumArtists.Find(id);
            if (albumArtists == null)
            {
                return HttpNotFound();
            }
            return View(albumArtists);
        }

        // GET: AlbumArtists/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "id", "Name");
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name");
            return View();
        }

        // POST: AlbumArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,AlbumId")] AlbumArtists albumArtists)
        {
            if (ModelState.IsValid)
            {
                db.AlbumArtists.Add(albumArtists);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "id", "Name", albumArtists.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", albumArtists.ArtistId);
            return View(albumArtists);
        }

        // GET: AlbumArtists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists albumArtists = db.AlbumArtists.Find(id);
            if (albumArtists == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "id", "Name", albumArtists.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", albumArtists.ArtistId);
            return View(albumArtists);
        }

        // POST: AlbumArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,AlbumId")] AlbumArtists albumArtists)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumArtists).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "id", "Name", albumArtists.AlbumId);
            ViewBag.ArtistId = new SelectList(db.Artists, "Id", "Name", albumArtists.ArtistId);
            return View(albumArtists);
        }

        // GET: AlbumArtists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumArtists albumArtists = db.AlbumArtists.Find(id);
            if (albumArtists == null)
            {
                return HttpNotFound();
            }
            return View(albumArtists);
        }

        // POST: AlbumArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumArtists albumArtists = db.AlbumArtists.Find(id);
            db.AlbumArtists.Remove(albumArtists);
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
