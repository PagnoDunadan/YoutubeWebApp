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
                new Video {VideoTitle = "Michael Jackson - Beat It (Official Video)", VideoUrl = "https://www.youtube.com/watch?v=oRdxUFDoQe0", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2011, 4, 11), VideoViews = 282141672, VideoDuration = 298, VideoThumbnail = "https://i.ytimg.com/vi/oRdxUFDoQe0/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLD6PJbqXe4JOhN0WMDFkjGfPtbq-w", VideoDescription = "Music video by Michael Jackson performing Beat It. © 1982 MJJ Productions Inc."},
                new Video {VideoTitle = "Michael Jackson - They Don't Care About Us (Brazil Version) (Official Video)", VideoUrl = "https://www.youtube.com/watch?v=QNJL6nfu__Q", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoViews = 380133496, VideoDuration = 281, VideoThumbnail = "https://i.ytimg.com/vi/QNJL6nfu__Q/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLCQMsgGXXKqLuAjR7l-LZKtHwEMZg", VideoDescription = "Music video by Michael Jackson performing They Don't Care About Us. (C) 1996 MJJ Productions Inc."},
                new Video {VideoTitle = "Michael Jackson - Billie Jean (Official Video)", VideoUrl = "https://www.youtube.com/watch?v=Zi_XLOBDo_Y", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoViews = 340318648, VideoDuration = 295, VideoThumbnail = "https://i.ytimg.com/vi/Zi_XLOBDo_Y/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLDnbev3KkYJLrVHo-3SgFH6pGKsMw", VideoDescription = "Billie Jean was the first short film made for Thriller, the biggest-selling album of all time. The short film for this No. 1 single, directed by Steve Barron, made history as the first video by a black artist to receive heavy rotation on MTV, and was later ranked by the network as one of the 100 greatest music videos of all time."},
                new Video {VideoTitle = "Michael Jackson - Smooth Criminal (Official Video)", VideoUrl = "https://www.youtube.com/watch?v=h_D3VFfhvs4", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2010, 11, 19), VideoViews = 108418432, VideoDuration = 565, VideoThumbnail = "https://i.ytimg.com/vi/h_D3VFfhvs4/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLC4tVIkOcxfdoprw-AC_0N_a1jZTw", VideoDescription = "The short film for Michael Jackson's Smooth Criminal was the centerpiece of the feature film Moonwalker, and featured the debut of Michael's iconic anti-gravity lean. Inspired in part by Fred Astaire's Girl Hunt Ballet dance number in the film The Band Wagon, Smooth Criminal was named Best Video at the BRIT Awards, Broadcast Film Critics Association and the People's Choice Awards."},
                new Video {VideoTitle = "Michael Jackson - Thriller (Official Video)", VideoUrl = "https://www.youtube.com/watch?v=sOnqjkJTMaA", VideoUploader = "michaeljacksonVEVO", VideoUploadDate = new DateTime(2009, 10, 2), VideoViews = 450227401, VideoDuration = 822, VideoThumbnail = "https://i.ytimg.com/vi/sOnqjkJTMaA/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLDn5tuWgKzV_n-KJ_S9pShXcqqgVg", VideoDescription = "Music video by Michael Jackson performing Thriller. (C) 1982 MJJ Productions Inc."},
                new Video {VideoTitle = "Sting - Desert Rose", VideoUrl = "https://www.youtube.com/watch?v=C3lWwBslWqg", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2009, 6, 16), VideoViews = 107702024, VideoDuration = 285, VideoThumbnail = "https://i.ytimg.com/vi/C3lWwBslWqg/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLCknWvx0ySv5e3q-iZhnRT-9xUtzg", VideoDescription = "Music video by Sting performing Desert Rose. (C) 1999 A&M Records"},
                new Video {VideoTitle = "Sting - Englishman In New York", VideoUrl = "https://www.youtube.com/watch?v=d27gTrPPAyk", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2011, 1, 11), VideoViews = 84984024, VideoDuration = 267, VideoThumbnail = "https://i.ytimg.com/vi/d27gTrPPAyk/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLCRVJEC_3m_2IyVshooLcCY3knqvQ", VideoDescription = "Music video by Sting performing Englishman In New York. (C) 1987 A&M Records"},
                new Video {VideoTitle = "Sting - Fields Of Gold", VideoUrl = "https://www.youtube.com/watch?v=KLVq0IAzh1A", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2011, 9, 20), VideoViews = 28006230, VideoDuration = 218, VideoThumbnail = "https://i.ytimg.com/vi/KLVq0IAzh1A/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLDiGMCPkz2cIAapCFk3ZegAwvMMyg", VideoDescription = "Music video by Sting performing Fields Of Gold. YouTube view counts pre-VEVO: 5,830,897. (C) 1993 A&M Records"},
                new Video {VideoTitle = "Sting - Fragile", VideoUrl = "https://www.youtube.com/watch?v=lB6a-iD6ZOY", VideoUploader = "StingVEVO", VideoUploadDate = new DateTime(2009, 12, 25), VideoViews = 51880246, VideoDuration = 231, VideoThumbnail = "https://i.ytimg.com/vi/lB6a-iD6ZOY/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLBovmlydpT98joAKT9iNzIZE1rS9w", VideoDescription = "Music video by Sting performing Fragile. YouTube view counts pre-VEVO: 1,794,143. (C) 1991 A&M Records"},
                new Video {VideoTitle = "Sting - Shape of My Heart (Leon)", VideoUrl = "https://www.youtube.com/watch?v=QK-Z1K67uaA", VideoUploader = "Cristian Nicolae", VideoUploadDate = new DateTime(2017, 1, 12), VideoViews = 11423146, VideoDuration = 278, VideoThumbnail = "https://i.ytimg.com/vi/QK-Z1K67uaA/hqdefault.jpg?sqp=-oaymwEXCNACELwBSFryq4qpAwkIARUAAIhCGAE=&rs=AOn4CLDyVsOCbXgxkr_igOLFZ6CDt8cm0A", VideoDescription = "Sting featuring Natalie Portman and Jean Reno."}
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