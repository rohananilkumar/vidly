namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres ( Name) values ('Action')");
            Sql("insert into genres ( Name) values ( 'Family')");
            Sql("insert into genres ( Name) values ( 'Romance')");
            Sql("insert into genres ( Name) values ( 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
