namespace ExpendituresALevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransactionModels", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransactionModels", "UserId", c => c.Int(nullable: false));
        }
    }
}
