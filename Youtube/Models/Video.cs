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
        public string VideoAuthor { get; set; }
        [Required]
        public int VideoDuration { get; set; }
        public string VideoThumbnail { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}