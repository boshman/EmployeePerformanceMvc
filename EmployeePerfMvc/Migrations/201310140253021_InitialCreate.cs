namespace EmployeePerfMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoalAppraisals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Goal = c.String(),
                        EmployeeAppraisal = c.String(),
                        ManagerAppraisal = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GoalAppraisals", new[] { "EmployeeId" });
            DropForeignKey("dbo.GoalAppraisals", "EmployeeId", "dbo.Employees");
            DropTable("dbo.GoalAppraisals");
            DropTable("dbo.Employees");
        }
    }
}
