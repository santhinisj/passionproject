namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liquorset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Liquors",
                c => new
                    {
                        LiquorID = c.Int(nullable: false, identity: true),
                        LiquorName = c.String(),
                    })
                .PrimaryKey(t => t.LiquorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Liquors");
        }
    }
}
