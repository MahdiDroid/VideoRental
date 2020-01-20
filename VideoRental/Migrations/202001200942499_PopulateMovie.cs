namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name) VALUES ('Hangover')");
            Sql("INSERT INTO Movies (Name) VALUES ('Die Hard')");
            Sql("INSERT INTO Movies (Name) VALUES ('The Terminator')");
            Sql("INSERT INTO Movies (Name) VALUES ('Toy Story')");
            Sql("INSERT INTO Movies (Name) VALUES ('Titanic')");



        }

        public override void Down()
        {
        }
    }
}
