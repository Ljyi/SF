namespace SF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExcelTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcelTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExcelName = c.String(nullable: false, maxLength: 250),
                        ExcelPath = c.String(nullable: false, maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        CreateUser = c.String(nullable: false, maxLength: 50),
                        CredateTime = c.DateTime(nullable: false),
                        UpdateUser = c.String(maxLength: 50),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExcelTable");
        }
    }
}
