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

        // GET: Videos
        public ActionResult Index()
        {
            // Vrati sve videe
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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoID,VideoTitle,VideoUrl,VideoUploader,VideoUploadDate,VideoDuration,VideoThumbnail,VideoDescription")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoID,VideoTitle,VideoUrl,VideoUploader,VideoUploadDate,VideoDuration,VideoThumbnail,VideoDescription")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
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
