using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.Models;

namespace Youtube.Controllers
{
    public class SearchController : Controller
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

        // GET: Search/searchExpression
        public ActionResult Index(string searchExpression)
        {
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

            return Json(videos, JsonRequestBehavior.AllowGet);
        }
    }
}