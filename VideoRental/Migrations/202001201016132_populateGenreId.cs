namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreId : DbMigration
    {
        public override void Up()
        {
           
            Sql("UPDATE Movies SET GenreId=1  WHERE id=1");
            Sql("UPDATE Movies SET GenreId=2  WHERE id=2");
            Sql("UPDATE Movies SET GenreId=1  WHERE id=3");
            Sql("UPDATE Movies SET GenreId=3  WHERE id=4");
            Sql("UPDATE Movies SET GenreId=4  WHERE id=5");



        }

        public override void Down()
        {
        }
    }
}
