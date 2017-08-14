namespace NissanCartTest01.WebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            CreateTable(
                "dbo.Foremen",
                c => new
                    {
                        ForemanId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        username = c.String(),
                    })
                .PrimaryKey(t => t.ForemanId);
            
            CreateTable(
                "dbo.Faults",
                c => new
                    {
                        FaultId = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Fault = c.String(),
                        Checked = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        p = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FaultId);
            
            AddColumn("dbo.JobCards", "ForemanId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookIns", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "ID_Number", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Customers", "ID_Number", c => c.String(nullable: false, maxLength: 14));
            AddPrimaryKey("dbo.Customers", "ID_Number");
            CreateIndex("dbo.JobCards", "ForemanId");
            CreateIndex("dbo.Vehicles", "ID_Number");
            AddForeignKey("dbo.JobCards", "ForemanId", "dbo.Foremen", "ForemanId", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "ID_Number", "dbo.Customers", "ID_Number", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ID_Number", "dbo.Customers");
            DropForeignKey("dbo.JobCards", "ForemanId", "dbo.Foremen");
            DropIndex("dbo.Vehicles", new[] { "ID_Number" });
            DropIndex("dbo.JobCards", new[] { "ForemanId" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "ID_Number", c => c.Long(nullable: false));
            AlterColumn("dbo.Vehicles", "ID_Number", c => c.Long(nullable: false));
            AlterColumn("dbo.BookIns", "Date", c => c.String(nullable: false));
            DropColumn("dbo.JobCards", "ForemanId");
            DropTable("dbo.Faults");
            DropTable("dbo.Foremen");
            AddPrimaryKey("dbo.Customers", "ID_Number");
        }
    }
}
