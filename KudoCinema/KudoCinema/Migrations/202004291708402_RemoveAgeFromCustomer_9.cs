namespace KudoCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAgeFromCustomer_9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Age", c => c.Byte(nullable: false));
        }
    }
}
