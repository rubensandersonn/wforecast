namespace WForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cidades", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Cidades", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Estadoes", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Estadoes", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.PrevisaoClimas", "ModifiedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.PrevisaoClimas", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Cidades", "CreatedDate");
            DropColumn("dbo.Estadoes", "CreatedDate");
            DropColumn("dbo.PrevisaoClimas", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrevisaoClimas", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Estadoes", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Cidades", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.PrevisaoClimas", "IsActive");
            DropColumn("dbo.PrevisaoClimas", "ModifiedDate");
            DropColumn("dbo.Estadoes", "IsActive");
            DropColumn("dbo.Estadoes", "ModifiedDate");
            DropColumn("dbo.Cidades", "IsActive");
            DropColumn("dbo.Cidades", "ModifiedDate");
        }
    }
}
