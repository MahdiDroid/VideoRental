namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreId6 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId=3  WHERE id=6");
        }
        
        public override void Down()
        {
        }
    }
}
