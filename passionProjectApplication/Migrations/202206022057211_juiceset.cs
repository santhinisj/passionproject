namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class juiceset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Juices",
                c => new
                    {
                        JuiceId = c.Int(nullable: false, identity: true),
                        JuiceName = c.String(),
                    })
                .PrimaryKey(t => t.JuiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Juices");
        }
    }
}
