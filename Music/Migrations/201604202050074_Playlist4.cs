namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Playlist4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "PlaylistID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "PlaylistID");
        }
    }
}
