namespace AComicConundrum_ASeholm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comic",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        strTitle = c.String(),
                        iIssueNumber = c.Int(nullable: false),
                        strSeries = c.String(),
                        strPublisher = c.String(),
                        strAuthor = c.String(),
                        strArtist = c.String(),
                        iYearPublished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comic");
        }
    }
}
