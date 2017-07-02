namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(Id, Name) Values(8, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
