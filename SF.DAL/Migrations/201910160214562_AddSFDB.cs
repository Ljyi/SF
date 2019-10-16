namespace SF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSFDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(nullable: false, maxLength: 50),
                        Channel = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        CreateTime = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        Remark = c.String(maxLength: 20),
                        UpdateUser = c.String(maxLength: 20),
                        UpdateTime = c.DateTime(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 100),
                        Status = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuCode = c.String(nullable: false, maxLength: 100),
                        Url = c.String(nullable: false, maxLength: 100),
                        MenuName = c.String(nullable: false, maxLength: 100),
                        MenuLevel = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        SortNumber = c.Int(nullable: false),
                        Icon = c.String(maxLength: 100),
                        Status = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        LogingName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Status = c.String(maxLength: 10),
                        IsAdmin = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SysMenuId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysMenu", t => t.SysMenuId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SysMenuId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRights", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRights", "SysMenuId", "dbo.SysMenu");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRights", new[] { "SysMenuId" });
            DropIndex("dbo.UserRights", new[] { "UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.UserRights");
            DropTable("dbo.User");
            DropTable("dbo.SysMenu");
            DropTable("dbo.Role");
            DropTable("dbo.Order");
        }
    }
}
