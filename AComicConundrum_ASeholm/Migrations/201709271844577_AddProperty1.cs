namespace AComicConundrum_ASeholm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comic", "strDescription", c => c.String());
            AddColumn("dbo.Comic", "iPageCount", c => c.Int(nullable: false));
            AddColumn("dbo.Comic", "strImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comic", "strImageUrl");
            DropColumn("dbo.Comic", "iPageCount");
            DropColumn("dbo.Comic", "strDescription");
        }
    }
}
