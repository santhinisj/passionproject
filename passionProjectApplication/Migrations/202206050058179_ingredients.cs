namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CocktailJuices", "CocktailId", "dbo.Cocktails");
            DropForeignKey("dbo.CocktailJuices", "JuiceId", "dbo.Juices");
            DropForeignKey("dbo.CocktailLiquors", "CocktailId", "dbo.Cocktails");
            DropForeignKey("dbo.CocktailLiquors", "LiquorId", "dbo.Liquors");
            DropIndex("dbo.CocktailJuices", new[] { "CocktailId" });
            DropIndex("dbo.CocktailJuices", new[] { "JuiceId" });
            DropIndex("dbo.CocktailLiquors", new[] { "LiquorId" });
            DropIndex("dbo.CocktailLiquors", new[] { "CocktailId" });
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.IngredientCocktails",
                c => new
                    {
                        Ingredient_IngredientId = c.Int(nullable: false),
                        Cocktail_CocktailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_IngredientId, t.Cocktail_CocktailId })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Cocktails", t => t.Cocktail_CocktailId, cascadeDelete: true)
                .Index(t => t.Ingredient_IngredientId)
                .Index(t => t.Cocktail_CocktailId);
            
            DropTable("dbo.CocktailJuices");
            DropTable("dbo.Juices");
            DropTable("dbo.CocktailLiquors");
            DropTable("dbo.Liquors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Liquors",
                c => new
                    {
                        LiquorID = c.Int(nullable: false, identity: true),
                        LiquorName = c.String(),
                    })
                .PrimaryKey(t => t.LiquorID);
            
            CreateTable(
                "dbo.CocktailLiquors",
                c => new
                    {
                        CocktailLiquorsId = c.Int(nullable: false, identity: true),
                        LiquorId = c.Int(nullable: false),
                        CocktailId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailLiquorsId);
            
            CreateTable(
                "dbo.Juices",
                c => new
                    {
                        JuiceId = c.Int(nullable: false, identity: true),
                        JuiceName = c.String(),
                    })
                .PrimaryKey(t => t.JuiceId);
            
            CreateTable(
                "dbo.CocktailJuices",
                c => new
                    {
                        CocktailJuiceId = c.Int(nullable: false, identity: true),
                        CocktailId = c.Int(nullable: false),
                        JuiceId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailJuiceId);
            
            DropForeignKey("dbo.IngredientCocktails", "Cocktail_CocktailId", "dbo.Cocktails");
            DropForeignKey("dbo.IngredientCocktails", "Ingredient_IngredientId", "dbo.Ingredients");
            DropIndex("dbo.IngredientCocktails", new[] { "Cocktail_CocktailId" });
            DropIndex("dbo.IngredientCocktails", new[] { "Ingredient_IngredientId" });
            DropTable("dbo.IngredientCocktails");
            DropTable("dbo.Ingredients");
            CreateIndex("dbo.CocktailLiquors", "CocktailId");
            CreateIndex("dbo.CocktailLiquors", "LiquorId");
            CreateIndex("dbo.CocktailJuices", "JuiceId");
            CreateIndex("dbo.CocktailJuices", "CocktailId");
            AddForeignKey("dbo.CocktailLiquors", "LiquorId", "dbo.Liquors", "LiquorID", cascadeDelete: true);
            AddForeignKey("dbo.CocktailLiquors", "CocktailId", "dbo.Cocktails", "CocktailId", cascadeDelete: true);
            AddForeignKey("dbo.CocktailJuices", "JuiceId", "dbo.Juices", "JuiceId", cascadeDelete: true);
            AddForeignKey("dbo.CocktailJuices", "CocktailId", "dbo.Cocktails", "CocktailId", cascadeDelete: true);
        }
    }
}
