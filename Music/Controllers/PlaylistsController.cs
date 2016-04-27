using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class PlaylistsController : Controller
    {
        private MusicContext db = new MusicContext();

        // GET: Playlists
        public ActionResult Index()
        {
            return View(db.Playlists.ToList());
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View("Details");

            //var albums = db.Album
            //    .Where(a => a.PlaylistID == id);
            //return View(albums.ToList());

        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaylistID,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaylistID,Name")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Playlist playlist = db.Playlists.Find(id);
            
            if (playlist == null)
            {
                return HttpNotFound();
            }
            return View(playlist);
        }

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
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



        public ActionResult AddToPlaylist()
        {

            //Album album = db.Albums.Find(id);
            ViewBag.PlaylistID = new SelectList(db.Playlists, "PlaylistID", "Name");
            // Add it to the shopping cart
            //db.Playlists.Add(Albums);
            ViewBag.AlbumID = new SelectList(db.Album, "AlbumID", "Title");

            //db.Playlists.Add(album);



            return View();

        }

        [HttpPost]
        public ActionResult AddToPlaylist(int id, Playlist album)
        {

            //Album.AlbumID = (Playlist)Title;
            //db.Playlists.Add(albums);
            //db.SaveChanges();
            // .Include(a => a.Title)
            // .Where(a => a.Title == newTitle);
            // Albums = (List<Playlist>)albums = 
            //db.Albums.Find(Title);

            // var test = db.Albums
            //   .Single(albums => test.AlbumID == id);


            List<Album> AlbumsList = new List<Album>
            {
                new Album() {Title = "Test" }
            };
            var test = (from Title in db.Album select Title).ToString();
            
            db.Playlists.Add(album);

            ViewBag.AlbumID = new SelectList(db.Album, "AlbumID", "Title");
            ViewBag.PlaylistID = new SelectList(db.Playlists, "PlaylistID", "Name");

            return View();
        }

        
    }
}
