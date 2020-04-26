namespace KudoCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubcribed", c => c.Boolean(nullable: false));
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.MembershipTypes", "IsSubcribed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "IsSubcribed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "SignUpFee");
            DropColumn("dbo.Customers", "IsSubcribed");
        }
    }
}
