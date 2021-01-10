namespace ExpendituresALevel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetRoles", "TestDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "TestDescription", c => c.String());
        }
    }
}
