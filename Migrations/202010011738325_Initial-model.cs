namespace Sales_and_Finance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "Date", c => c.String());
            AlterColumn("dbo.Sales", "Unit", c => c.String());
            AlterColumn("dbo.Sales", "UnitCost", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "UnitCost", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
        }
    }
}
