namespace WForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Nome = c.String(nullable: false, maxLength: 200),
                        EstadoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Nome = c.String(nullable: false, maxLength: 200),
                        UF = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrevisaoClimas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Clima = c.String(nullable: false, maxLength: 15),
                        TemperaturaMinima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TemperaturaMaxima = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CidadeId = c.Long(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrevisaoClimas", "CidadeId", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.PrevisaoClimas", new[] { "CidadeId" });
            DropIndex("dbo.Cidades", new[] { "EstadoId" });
            DropTable("dbo.PrevisaoClimas");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Cidades");
        }
    }
}
