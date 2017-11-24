using System;
using System.Collections;
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
    public class VideosController : Controller
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

        // GET: Videos
        public ActionResult Index()
        {
            IEnumerable data = new YoutubeContext().Videos
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

            // Vrati sve videe koji su u playlisti Michael Jackson
            //IEnumerable data = new YoutubeContext().Videos
            //    .Where(v => v.Playlists.Any(p => p.PlaylistName.Contains("Michael Jackson")))
            //    .Select(v => new VideoModel
            //    {
            //        VideoID = v.VideoID,
            //        VideoTitle = v.VideoTitle,
            //        VideoAuthor = v.VideoAuthor,
            //        VideoDuration = v.VideoDuration,
            //        VideoThumbnail = v.VideoThumbnail
            //    }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Videos/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Video video = db.Videos.Find(id);
        //    if (video == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(video);
        //}

        // GET: Videos/Search/5
        public ActionResult Search(string searchExpression)
        {
            if (searchExpression == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           var videos = db.Videos
               .Where(v => v.VideoTitle.Contains(searchExpression) || v.VideoUploader.Contains(searchExpression))
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

        // GET: Videos/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Videos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "VideoID,VideoTitle,VideoUrl,VideoUploader,VideoUploadDate,VideoViews,VideoDuration,VideoThumbnail,VideoDescription")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return Json("Success!");
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return Json(errors);
        }

        // GET: Videos/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Video video = db.Videos.Find(id);
        //    if (video == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(video);
        //}

        // POST: Videos/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "VideoID,VideoTitle,VideoUrl,VideoUploader,VideoUploadDate,VideoViews,VideoDuration,VideoThumbnail,VideoDescription")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return Json(video);
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
            return Json(errors);
        }

        // GET: Videos/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Video video = db.Videos.Find(id);
        //    if (video == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(video);
        //}

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return Content("Deleted!");
        }

        // GET: Videos/PlaylistsFor/5
        public ActionResult PlaylistsFor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playlists = db.Videos
                .Find(id).Playlists
                .Select(p => new PlaylistModel
                {
                    PlaylistID = p.PlaylistID,
                    PlaylistName = p.PlaylistName,
                }).ToList();

            if (playlists == null)
            {
                return HttpNotFound();
            }
            return Json(playlists, JsonRequestBehavior.AllowGet);
        }

        // POST: Videos/PlaylistAdd/5
        [HttpPost]
        public ActionResult PlaylistAdd(int? id, Playlist sentPlaylist)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var video = db.Videos.Find(id);
            var playlist = db.Playlists.Find(sentPlaylist.PlaylistID);
            video.Playlists.Add(playlist);
            db.Entry(video).State = EntityState.Modified;
            db.SaveChanges();

            var playlists = db.Videos
                .Find(id).Playlists
                .Select(p => new PlaylistModel
                {
                    PlaylistID = p.PlaylistID,
                    PlaylistName = p.PlaylistName,
                }).ToList();

            if (playlists == null)
            {
                return HttpNotFound();
            }
            return Json(playlists, JsonRequestBehavior.AllowGet);
        }

        // POST: Videos/PlaylistDelete/5
        [HttpPost]
        public ActionResult PlaylistDelete(int? id, Playlist sentPlaylist)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var video = db.Videos.Find(id);
            var playlist = db.Playlists.Find(sentPlaylist.PlaylistID);
            video.Playlists.Remove(playlist);
            db.Entry(video).State = EntityState.Modified;
            db.SaveChanges();

            var playlists = db.Videos
                .Find(id).Playlists
                .Select(p => new PlaylistModel
                {
                    PlaylistID = p.PlaylistID,
                    PlaylistName = p.PlaylistName,
                }).ToList();

            if (playlists == null)
            {
                return HttpNotFound();
            }
            return Json(playlists, JsonRequestBehavior.AllowGet);
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
