namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Playlists3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistAlbums", "Playlist_PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.PlaylistAlbums", "Album_AlbumID", "dbo.Albums");
            DropIndex("dbo.PlaylistAlbums", new[] { "Playlist_PlaylistID" });
            DropIndex("dbo.PlaylistAlbums", new[] { "Album_AlbumID" });
            AddColumn("dbo.Albums", "PlaylistID", c => c.Int(nullable: false));
            AddColumn("dbo.Albums", "Playlist_PlaylistID", c => c.Int());
            AddColumn("dbo.Albums", "Playlist_PlaylistID1", c => c.Int());
            AddColumn("dbo.Playlists", "AlbumID", c => c.Int(nullable: false));
            AddColumn("dbo.Playlists", "Album_AlbumID", c => c.Int());
            AddColumn("dbo.Playlists", "Album_AlbumID1", c => c.Int());
            CreateIndex("dbo.Albums", "Playlist_PlaylistID");
            CreateIndex("dbo.Albums", "Playlist_PlaylistID1");
            CreateIndex("dbo.Playlists", "Album_AlbumID");
            CreateIndex("dbo.Playlists", "Album_AlbumID1");
            AddForeignKey("dbo.Playlists", "Album_AlbumID", "dbo.Albums", "AlbumID");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistID", "dbo.Playlists", "PlaylistID");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistID1", "dbo.Playlists", "PlaylistID");
            AddForeignKey("dbo.Playlists", "Album_AlbumID1", "dbo.Albums", "AlbumID");
            DropTable("dbo.PlaylistAlbums");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaylistAlbums",
                c => new
                    {
                        Playlist_PlaylistID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistID, t.Album_AlbumID });
            
            DropForeignKey("dbo.Playlists", "Album_AlbumID1", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Playlist_PlaylistID1", "dbo.Playlists");
            DropForeignKey("dbo.Albums", "Playlist_PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "Album_AlbumID", "dbo.Albums");
            DropIndex("dbo.Playlists", new[] { "Album_AlbumID1" });
            DropIndex("dbo.Playlists", new[] { "Album_AlbumID" });
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistID1" });
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistID" });
            DropColumn("dbo.Playlists", "Album_AlbumID1");
            DropColumn("dbo.Playlists", "Album_AlbumID");
            DropColumn("dbo.Playlists", "AlbumID");
            DropColumn("dbo.Albums", "Playlist_PlaylistID1");
            DropColumn("dbo.Albums", "Playlist_PlaylistID");
            DropColumn("dbo.Albums", "PlaylistID");
            CreateIndex("dbo.PlaylistAlbums", "Album_AlbumID");
            CreateIndex("dbo.PlaylistAlbums", "Playlist_PlaylistID");
            AddForeignKey("dbo.PlaylistAlbums", "Album_AlbumID", "dbo.Albums", "AlbumID", cascadeDelete: true);
            AddForeignKey("dbo.PlaylistAlbums", "Playlist_PlaylistID", "dbo.Playlists", "PlaylistID", cascadeDelete: true);
        }
    }
}
