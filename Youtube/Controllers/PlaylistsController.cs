using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Youtube.Models;

namespace Youtube.Controllers
{
    public class PlaylistsController : Controller
    {
        private YoutubeContext db = new YoutubeContext();

        public class VideoModel
        {
            public int VideoID { get; set; }
            public string VideoTitle { get; set; }
            public string VideoUrl { get; set; }
            public string VideoUploader { get; set; }
            public DateTime VideoUploadDate { get; set; }
            public double VideoViews { get; set; }
            public int VideoDuration { get; set; }
            public string VideoThumbnail { get; set; }
            public string VideoDescription { get; set; }
        }

        public class PlaylistModel
        {
            public int PlaylistID { get; set; }
            public string PlaylistName { get; set; }
        }

        // GET: Playlists
        public ActionResult Index()
        {
            var data = db.Playlists
                .Select(p => new PlaylistModel
                {
                    PlaylistID = p.PlaylistID,
                    PlaylistName = p.PlaylistName
                }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Playlists/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Playlist playlist = db.Playlists.Find(id);
        //    if (playlist == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(playlist);
        //}

        // GET: Playlists/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Playlists/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "PlaylistID,PlaylistName")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.Add(playlist);
                db.SaveChanges();
                return Json(playlist);
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return Json(errors);
        }

        // GET: Playlists/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Playlist playlist = db.Playlists.Find(id);
        //    if (playlist == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(playlist);
        //}

        // POST: Playlists/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "PlaylistID,PlaylistName")] Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playlist).State = EntityState.Modified;
                db.SaveChanges();
                return Json(playlist);
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return Json(errors);
        }

        // GET: Playlists/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Playlist playlist = db.Playlists.Find(id);
        //    if (playlist == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(playlist);
        //}

        // POST: Playlists/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Playlist playlist = db.Playlists.Find(id);
            db.Playlists.Remove(playlist);
            db.SaveChanges();
            return Json(id);
        }

        // GET: Playlists/VideosFor/5
        public ActionResult VideosFor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var videos = db.Videos
                .Where(v => v.Playlists.Any(p => p.PlaylistID == id))
                .Select(v => new VideoModel
                {
                    VideoID = v.VideoID,
                    VideoTitle = v.VideoTitle,
                    VideoUrl = v.VideoUrl,
                    VideoUploader = v.VideoUploader,
                    VideoUploadDate = v.VideoUploadDate,
                    VideoViews = v.VideoViews,
                    VideoDuration = v.VideoDuration,
                    VideoThumbnail = v.VideoThumbnail,
                    VideoDescription = v.VideoDescription
                }).ToList();

            if (videos == null)
            {
                return HttpNotFound();
            }

            return Json(videos, JsonRequestBehavior.AllowGet);
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
