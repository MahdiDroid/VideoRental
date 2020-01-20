namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNametoMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name='PayAsGo'  WHERE id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly ' WHERE id=2");
            Sql("UPDATE MembershipTypes SET Name= 'Yearly'  WHERE id=3");



        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
