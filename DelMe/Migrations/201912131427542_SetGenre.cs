namespace DelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Documentry')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
