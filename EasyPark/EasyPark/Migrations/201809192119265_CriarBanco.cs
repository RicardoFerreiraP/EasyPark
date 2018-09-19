namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automoveis",
                c => new
                    {
                        AutomovelID = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false, maxLength: 8),
                        Marca = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        Tipo = c.String(nullable: false),
                        Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.AutomovelID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .Index(t => t.Cliente_ClienteID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Nome = c.String(nullable: false, maxLength: 150),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Telefone = c.String(nullable: false, maxLength: 12),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.ClienteID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        Senha = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Telefone = c.String(nullable: false, maxLength: 12),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Historicos",
                c => new
                    {
                        HistoricoID = c.Int(nullable: false, identity: true),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(),
                        Automovel_AutomovelID = c.Int(),
                        Vaga_VagaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HistoricoID)
                .ForeignKey("dbo.Automoveis", t => t.Automovel_AutomovelID)
                .ForeignKey("dbo.Vagas", t => t.Vaga_VagaID, cascadeDelete: true)
                .Index(t => t.Automovel_AutomovelID)
                .Index(t => t.Vaga_VagaID);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        VagaID = c.Int(nullable: false, identity: true),
                        Disponivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VagaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis");
            DropForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            DropIndex("dbo.Historicos", new[] { "Automovel_AutomovelID" });
            DropIndex("dbo.Automoveis", new[] { "Cliente_ClienteID" });
            DropTable("dbo.Vagas");
            DropTable("dbo.Historicos");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Clientes");
            DropTable("dbo.Automoveis");
        }
    }
}
