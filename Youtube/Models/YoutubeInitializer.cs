using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Youtube.Models;

namespace Youtube.Models
{
    public class YoutubeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<YoutubeContext>
    {
        protected override void Seed(YoutubeContext context)
        {
            var videos = new List<Video>
            {
                new Video {VideoTitle = "Beat It", VideoAuthor = "Michael Jackson", VideoDuration = 299, VideoThumbnail = "https://images.genius.com/ceb1ad5f941d020a5db86755610a6ec7.953x953x1.jpg"},
                new Video {VideoTitle = "They Don't Care About Us", VideoAuthor = "Michael Jackson", VideoDuration = 282, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d5/Mjtdcau.jpg/220px-Mjtdcau.jpg"},
                new Video {VideoTitle = "Billie Jean", VideoAuthor = "Michael Jackson", VideoDuration = 296, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/hr/0/0e/Billie_Jean.jpg"},
                new Video {VideoTitle = "Smooth Criminal", VideoAuthor = "Michael Jackson", VideoDuration = 566, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/3/33/Smooth_Criminal.jpg"},
                new Video {VideoTitle = "Thriller", VideoAuthor = "Michael Jackson", VideoDuration = 823, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/5/55/Michael_Jackson_-_Thriller.png"},
                new Video {VideoTitle = "Desert Rose", VideoAuthor = "Sting", VideoDuration = 286, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/6/6a/Desert_Rose_%28Sting_song%29_coverart.jpg"},
                new Video {VideoTitle = "Englishman In New York", VideoAuthor = "Sting", VideoDuration = 268, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/0/0b/StingEnglishmanInNewYork7InchSingleCover.jpg"},
                new Video {VideoTitle = "Fields Of Gold", VideoAuthor = "Sting", VideoDuration = 219, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/1/19/Fields-of-gold-sting.jpg"},
                new Video {VideoTitle = "Fragile", VideoAuthor = "Sting", VideoDuration = 232, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/8/82/StingFragile.jpg"},
                new Video {VideoTitle = "Shape of My Heart", VideoAuthor = "Sting", VideoDuration = 278, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/Sting_-_Shape_of_my_heart.jpg/220px-Sting_-_Shape_of_my_heart.jpg"}
            };
            videos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();

            var playlists = new List<Playlist>
            {
                new Playlist {PlaylistName = "Michael Jackson", Videos = videos.Where(v => v.VideoAuthor.Equals("Michael Jackson")).ToList()},
                new Playlist {PlaylistName = "Sting", Videos = videos.Where(v => v.VideoAuthor.Equals("Sting")).ToList()}
            };
            playlists.ForEach(p => context.Playlists.Add(p));
            context.SaveChanges();
        }
    }
}