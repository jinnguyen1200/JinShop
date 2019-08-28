namespace _2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            AlterColumn("dbo.Product", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            AlterColumn("dbo.Product", "CategoryID", c => c.Int());
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "Id");
        }
    }
}
