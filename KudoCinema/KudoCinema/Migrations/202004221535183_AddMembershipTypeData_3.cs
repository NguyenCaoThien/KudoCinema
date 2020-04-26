namespace KudoCinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeData_3 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, Discount, DurationInMonths, SignUpFee) VALUES ('Pay as you go', 0, 0, 0)");      
            Sql("INSERT INTO MembershipTypes (Name, Discount, DurationInMonths, SignUpFee) VALUES ('Monthly', 5, 1, 50)");      
            Sql("INSERT INTO MembershipTypes (Name, Discount, DurationInMonths, SignUpFee) VALUES ('Quaterly', 10, 3, 100)");      
            Sql("INSERT INTO MembershipTypes (Name, Discount, DurationInMonths, SignUpFee) VALUES ('Annual', 15, 12, 150)");
        }
        
        public override void Down()
        {
        }
    }
}
