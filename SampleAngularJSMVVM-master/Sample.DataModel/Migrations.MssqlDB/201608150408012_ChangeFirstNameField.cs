namespace Sample.DataModel.Migrations.MssqlDB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFirstNameField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Customers", "FristName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "FristName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Customers", "FirstName");
        }
    }
}
