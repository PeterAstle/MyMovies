namespace MyMovies.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integratedCreateMethods : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Favourite", "IsFavorite", c => c.Boolean(nullable: false));
            DropColumn("dbo.Favourite", "Check");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Favourite", "Check", c => c.Boolean(nullable: false));
            DropColumn("dbo.Favourite", "IsFavorite");
        }
    }
}
