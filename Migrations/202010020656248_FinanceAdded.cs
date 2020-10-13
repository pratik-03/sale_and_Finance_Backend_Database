namespace Sales_and_Finance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Finances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Party = c.String(),
                        Debit = c.String(),
                        Credit = c.String(),
                        Balance = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Finances");
        }
    }
}
