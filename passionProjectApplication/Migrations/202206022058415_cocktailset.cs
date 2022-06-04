namespace passionProjectApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cocktailset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cocktails",
                c => new
                    {
                        CocktailId = c.Int(nullable: false, identity: true),
                        CocktailName = c.String(),
                        IsIceRequired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CocktailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cocktails");
        }
    }
}
