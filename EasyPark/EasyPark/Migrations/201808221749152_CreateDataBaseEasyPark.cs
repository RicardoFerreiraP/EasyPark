namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBaseEasyPark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automoveis",
                c => new
                    {
                        AutomovelID = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        Tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AutomovelID);
            
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
                        senha = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150),
                        CPF = c.String(nullable: false, maxLength: 11),
                        Telefone = c.String(nullable: false, maxLength: 12),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        VagaID = c.Int(nullable: false, identity: true),
                        Disponivel = c.Boolean(nullable: false),
                        Cliente_ClienteID = c.Int(),
                    })
                .PrimaryKey(t => t.VagaID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteID)
                .Index(t => t.Cliente_ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vagas", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Vagas", new[] { "Cliente_ClienteID" });
            DropTable("dbo.Vagas");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Clientes");
            DropTable("dbo.Automoveis");
        }
    }
}
