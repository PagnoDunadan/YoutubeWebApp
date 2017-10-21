using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Youtube.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        [Required]
        public string VideoTitle { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string VideoUploader { get; set; }
        [Required]
        public DateTime VideoUploadDate { get; set; }
        [Required]
        public double VideoViews { get; set; }
        [Required]
        public int VideoDuration { get; set; }
        [Required]
        public string VideoThumbnail { get; set; }
        [Required]
        public string VideoDescription { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}