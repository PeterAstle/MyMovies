namespace MyMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Rating", c => c.Int(nullable: false));
        }
    }
}
