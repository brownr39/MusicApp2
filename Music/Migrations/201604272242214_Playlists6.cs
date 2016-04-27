namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Playlists6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Playlists", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Playlist_PlaylistID", "dbo.Playlists");
            DropForeignKey("dbo.Albums", "Playlist_PlaylistID1", "dbo.Playlists");
            DropForeignKey("dbo.Playlists", "Album_AlbumID1", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistID" });
            DropIndex("dbo.Albums", new[] { "Playlist_PlaylistID1" });
            DropIndex("dbo.Playlists", new[] { "Album_AlbumID" });
            DropIndex("dbo.Playlists", new[] { "Album_AlbumID1" });
            CreateTable(
                "dbo.PlaylistAlbums",
                c => new
                    {
                        Playlist_PlaylistID = c.Int(nullable: false),
                        Album_AlbumID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Playlist_PlaylistID, t.Album_AlbumID })
                .ForeignKey("dbo.Playlists", t => t.Playlist_PlaylistID, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumID, cascadeDelete: true)
                .Index(t => t.Playlist_PlaylistID)
                .Index(t => t.Album_AlbumID);
            
            DropColumn("dbo.Albums", "PlaylistID");
            DropColumn("dbo.Albums", "Playlist_PlaylistID");
            DropColumn("dbo.Albums", "Playlist_PlaylistID1");
            DropColumn("dbo.Playlists", "AlbumID");
            DropColumn("dbo.Playlists", "Album_AlbumID");
            DropColumn("dbo.Playlists", "Album_AlbumID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Playlists", "Album_AlbumID1", c => c.Int());
            AddColumn("dbo.Playlists", "Album_AlbumID", c => c.Int());
            AddColumn("dbo.Playlists", "AlbumID", c => c.Int(nullable: false));
            AddColumn("dbo.Albums", "Playlist_PlaylistID1", c => c.Int());
            AddColumn("dbo.Albums", "Playlist_PlaylistID", c => c.Int());
            AddColumn("dbo.Albums", "PlaylistID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PlaylistAlbums", "Album_AlbumID", "dbo.Albums");
            DropForeignKey("dbo.PlaylistAlbums", "Playlist_PlaylistID", "dbo.Playlists");
            DropIndex("dbo.PlaylistAlbums", new[] { "Album_AlbumID" });
            DropIndex("dbo.PlaylistAlbums", new[] { "Playlist_PlaylistID" });
            DropTable("dbo.PlaylistAlbums");
            CreateIndex("dbo.Playlists", "Album_AlbumID1");
            CreateIndex("dbo.Playlists", "Album_AlbumID");
            CreateIndex("dbo.Albums", "Playlist_PlaylistID1");
            CreateIndex("dbo.Albums", "Playlist_PlaylistID");
            AddForeignKey("dbo.Playlists", "Album_AlbumID1", "dbo.Albums", "AlbumID");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistID1", "dbo.Playlists", "PlaylistID");
            AddForeignKey("dbo.Albums", "Playlist_PlaylistID", "dbo.Playlists", "PlaylistID");
            AddForeignKey("dbo.Playlists", "Album_AlbumID", "dbo.Albums", "AlbumID");
        }
    }
}
