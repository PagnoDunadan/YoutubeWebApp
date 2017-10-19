using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Youtube.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Youtube.Models
{
    public class YoutubeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public YoutubeContext() : base("name=YoutubeContext")
        {
        }

        public System.Data.Entity.DbSet<Youtube.Models.Video> Videos { get; set; }

        public System.Data.Entity.DbSet<Youtube.Models.Playlist> Playlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Videos).WithMany(v => v.Playlists)
                .Map(t => t.MapLeftKey("PlaylistID")
                    .MapRightKey("VideoID")
                    .ToTable("PlaylistVideoMap"));
        }
    }
}
