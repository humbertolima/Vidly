namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name = 'Pay as you go' where SignUpFee = 0");
            Sql("update MembershipTypes set Name = 'Monthly' where SignUpFee = 30");
            Sql("update MembershipTypes set Name = 'Quarterly' where SignUpFee = 90");
            Sql("update MembershipTypes set Name = 'Annual' where SignUpFee = 300");

        }
        
        public override void Down()
        {
        }
    }
}
