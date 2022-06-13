namespace GlobalSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kodegl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlCodes",
                c => new
                    {
                        GlCodeID = c.Int(nullable: false, identity: true),
                        KodeGL = c.String(),
                        NamaGL = c.String(),
                    })
                .PrimaryKey(t => t.GlCodeID);
            
            AddColumn("dbo.GlTransDs", "KodeGL", c => c.String());
            AddColumn("dbo.GlTransHes", "KodeGL", c => c.String(maxLength: 20));
            AlterColumn("dbo.GlTransHes", "Docno", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GlTransHes", "Docno", c => c.String(maxLength: 20));
            DropColumn("dbo.GlTransHes", "KodeGL");
            DropColumn("dbo.GlTransDs", "KodeGL");
            DropTable("dbo.GlCodes");
        }
    }
}
