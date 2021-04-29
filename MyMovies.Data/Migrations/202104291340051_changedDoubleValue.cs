namespace MyMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDoubleValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Rating", c => c.Double(nullable: false));
        }
    }
}
