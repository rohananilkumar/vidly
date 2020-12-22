namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoplateNumberAvailable : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies set numberavailable=numberinstock");
        }
        
        public override void Down()
        {
        }
    }
}
