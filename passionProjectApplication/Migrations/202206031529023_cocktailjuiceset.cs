namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cocktailjuiceset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CocktailJuices",
                c => new
                    {
                        CocktailJuiceId = c.Int(nullable: false, identity: true),
                        CocktailId = c.Int(nullable: false),
                        JuiceId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailJuiceId)
                .ForeignKey("dbo.Cocktails", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Juices", t => t.JuiceId, cascadeDelete: true)
                .Index(t => t.CocktailId)
                .Index(t => t.JuiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CocktailJuices", "JuiceId", "dbo.Juices");
            DropForeignKey("dbo.CocktailJuices", "CocktailId", "dbo.Cocktails");
            DropIndex("dbo.CocktailJuices", new[] { "JuiceId" });
            DropIndex("dbo.CocktailJuices", new[] { "CocktailId" });
            DropTable("dbo.CocktailJuices");
        }
    }
}
