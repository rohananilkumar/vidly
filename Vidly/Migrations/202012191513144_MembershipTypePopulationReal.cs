namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypePopulationReal : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes ( signupfee, durationinmonths, percentage, Name) values (100,12,10, 'Pay As You Go')");
            Sql("insert into MembershipTypes (signupfee, durationinmonths, percentage, Name) values (0,0,0,'Monthly')");

            Sql("insert into MembershipTypes (signupfee, durationinmonths, percentage, Name) values (10,4,15,'Yearly')");

            Sql("insert into MembershipTypes ( signupfee, durationinmonths, percentage, Name) values (20,12,20,'Quarterly')");
        }
        
        public override void Down()
        {
        }
    }
}
