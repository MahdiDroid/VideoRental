namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Comdy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Scary')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");

        }

        public override void Down()
        {
        }
    }
}
