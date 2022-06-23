namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catgories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Cocktails", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cocktails", "CategoryId");
            AddForeignKey("dbo.Cocktails", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cocktails", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Cocktails", new[] { "CategoryId" });
            DropColumn("dbo.Cocktails", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
