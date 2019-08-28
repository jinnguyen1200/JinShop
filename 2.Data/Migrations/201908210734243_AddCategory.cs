namespace _2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SanPham", newName: "Product");
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "CategoryID", c => c.Int());
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropColumn("dbo.Product", "CategoryID");
            DropTable("dbo.Category");
            RenameTable(name: "dbo.Product", newName: "SanPham");
        }
    }
}
