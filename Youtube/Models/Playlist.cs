using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Youtube.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        [Required]
        public string PlaylistName { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}