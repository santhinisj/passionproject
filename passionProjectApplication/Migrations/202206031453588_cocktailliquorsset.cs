namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cocktailliquorsset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CocktailLiquors",
                c => new
                    {
                        CocktailLiquorsId = c.Int(nullable: false, identity: true),
                        LiquorId = c.Int(nullable: false),
                        CocktailId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailLiquorsId)
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Liquors", t => t.LiquorId, cascadeDelete: true)
                .Index(t => t.LiquorId)
                .Index(t => t.CocktailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CocktailLiquors", "LiquorId", "dbo.Liquors");
            DropForeignKey("dbo.CocktailLiquors", "CocktailId", "dbo.Cocktails");
            DropIndex("dbo.CocktailLiquors", new[] { "CocktailId" });
            DropIndex("dbo.CocktailLiquors", new[] { "LiquorId" });
            DropTable("dbo.CocktailLiquors");
        }
    }
}
