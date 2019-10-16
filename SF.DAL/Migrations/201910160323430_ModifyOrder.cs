namespace SF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Phone", c => c.String(nullable: false, maxLength: 11));
            AddColumn("dbo.Order", "CreateUser", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "CredateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "UpdateUser", c => c.String(maxLength: 50));
            DropColumn("dbo.Order", "CreateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "UpdateUser", c => c.String(maxLength: 20));
            DropColumn("dbo.Order", "CredateTime");
            DropColumn("dbo.Order", "CreateUser");
            DropColumn("dbo.Order", "Phone");
        }
    }
}
