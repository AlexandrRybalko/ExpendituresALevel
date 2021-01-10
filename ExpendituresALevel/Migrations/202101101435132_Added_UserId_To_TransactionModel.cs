namespace ExpendituresALevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserId_To_TransactionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionModels", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionModels", "UserId");
        }
    }
}
