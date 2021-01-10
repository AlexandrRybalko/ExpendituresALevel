namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserId_To_Transaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "UserId");
        }
    }
}
