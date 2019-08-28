namespace _2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPham", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPham", "IsActive");
        }
    }
}
