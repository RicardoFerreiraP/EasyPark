namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableHistoricos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vagas", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Vagas", new[] { "Cliente_ClienteID" });
            CreateTable(
                "dbo.Historicos",
                c => new
                    {
                        HistoricoID = c.Int(nullable: false, identity: true),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        Automovel_AutomovelID = c.Int(),
                        Vaga_VagaID = c.Int(),
                    })
                .PrimaryKey(t => t.HistoricoID)
                .ForeignKey("dbo.Automoveis", t => t.Automovel_AutomovelID)
                .ForeignKey("dbo.Vagas", t => t.Vaga_VagaID)
                .Index(t => t.Automovel_AutomovelID)
                .Index(t => t.Vaga_VagaID);
            
            DropColumn("dbo.Vagas", "Cliente_ClienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vagas", "Cliente_ClienteID", c => c.Int());
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis");
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            DropIndex("dbo.Historicos", new[] { "Automovel_AutomovelID" });
            DropTable("dbo.Historicos");
            CreateIndex("dbo.Vagas", "Cliente_ClienteID");
            AddForeignKey("dbo.Vagas", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
    }
}
