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
                new Video {VideoTitle = "Michael Jackson - Beat It", VideoUrl = "https://www.youtube.com/watch?v=oRdxUFDoQe0", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2011, 4, 11), VideoDuration = 298, VideoThumbnail = "https://images.genius.com/ceb1ad5f941d020a5db86755610a6ec7.953x953x1.jpg", VideoDescription = "Music video by Michael Jackson performing Beat It. © 1982 MJJ Productions Inc."},
                new Video {VideoTitle = "Michael Jackson - They Don't Care About Us", VideoUrl = "https://www.youtube.com/watch?v=QNJL6nfu__Q", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoDuration = 281, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/thumb/d/d5/Mjtdcau.jpg/220px-Mjtdcau.jpg", VideoDescription = "Music video by Michael Jackson performing They Don't Care About Us. (C) 1996 MJJ Productions Inc."},
                new Video {VideoTitle = "Michael Jackson - Billie Jean", VideoUrl = "https://www.youtube.com/watch?v=Zi_XLOBDo_Y", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoDuration = 295, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/hr/0/0e/Billie_Jean.jpg", VideoDescription = "Billie Jean was the first short film made for Thriller, the biggest-selling album of all time. The short film for this No. 1 single, directed by Steve Barron, made history as the first video by a black artist to receive heavy rotation on MTV, and was later ranked by the network as one of the 100 greatest music videos of all time."},
                new Video {VideoTitle = "Michael Jackson - Smooth Criminal", VideoUrl = "https://www.youtube.com/watch?v=h_D3VFfhvs4", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2010, 11, 19), VideoDuration = 565, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/3/33/Smooth_Criminal.jpg", VideoDescription = "The short film for Michael Jackson's Smooth Criminal was the centerpiece of the feature film Moonwalker, and featured the debut of Michael's iconic anti-gravity lean. Inspired in part by Fred Astaire's Girl Hunt Ballet dance number in the film The Band Wagon, Smooth Criminal was named Best Video at the BRIT Awards, Broadcast Film Critics Association and the People's Choice Awards."},
                new Video {VideoTitle = "Michael Jackson - Thriller", VideoUrl = "https://www.youtube.com/watch?v=sOnqjkJTMaA", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoDuration = 822, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/5/55/Michael_Jackson_-_Thriller.png", VideoDescription = "Music video by Michael Jackson performing Thriller. (C) 1982 MJJ Productions Inc."},
                new Video {VideoTitle = "Sting - Desert Rose", VideoUrl = "https://www.youtube.com/watch?v=C3lWwBslWqg", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2009, 6, 16), VideoDuration = 285, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/6/6a/Desert_Rose_%28Sting_song%29_coverart.jpg", VideoDescription = "Music video by Sting performing Desert Rose. (C) 1999 A&M Records"},
                new Video {VideoTitle = "Sting - Englishman In New York", VideoUrl = "https://www.youtube.com/watch?v=d27gTrPPAyk", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2011, 1, 11), VideoDuration = 267, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/0/0b/StingEnglishmanInNewYork7InchSingleCover.jpg", VideoDescription = "Music video by Sting performing Englishman In New York. (C) 1987 A&M Records"},
                new Video {VideoTitle = "Sting - Fields Of Gold", VideoUrl = "https://www.youtube.com/watch?v=KLVq0IAzh1A", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2011, 9, 20), VideoDuration = 218, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/1/19/Fields-of-gold-sting.jpg", VideoDescription = "Music video by Sting performing Fields Of Gold. YouTube view counts pre-VEVO: 5,830,897. (C) 1993 A&M Records"},
                new Video {VideoTitle = "Sting - Fragile", VideoUrl = "https://www.youtube.com/watch?v=lB6a-iD6ZOY", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2009, 12, 25), VideoDuration = 231, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/8/82/StingFragile.jpg", VideoDescription = "Music video by Sting performing Fragile. YouTube view counts pre-VEVO: 1,794,143. (C) 1991 A&M Records"},
                new Video {VideoTitle = "Sting - Shape of My Heart", VideoUrl = "https://www.youtube.com/watch?v=QK-Z1K67uaA", VideoUploader = "Cristian Nicolae", VideoUploadDate = new DateTime(2017, 1, 12), VideoDuration = 278, VideoThumbnail = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9b/Sting_-_Shape_of_my_heart.jpg/220px-Sting_-_Shape_of_my_heart.jpg", VideoDescription = "Sting featuring Natalie Portman and Jean Reno."}
            };
            videos.ForEach(v => context.Videos.Add(v));
            context.SaveChanges();

            var playlists = new List<Playlist>
            {
                new Playlist {PlaylistName = "Michael Jackson", Videos = videos.Where(v => v.VideoTitle.Contains("Michael Jackson")).ToList()},
                new Playlist {PlaylistName = "Sting", Videos = videos.Where(v => v.VideoTitle.Contains("Sting")).ToList()}
            };
            playlists.ForEach(p => context.Playlists.Add(p));
            context.SaveChanges();
        }
    }
}