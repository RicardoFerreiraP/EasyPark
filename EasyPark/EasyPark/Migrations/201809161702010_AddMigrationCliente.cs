namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis");
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropIndex("dbo.Historicos", new[] { "Automovel_AutomovelID" });
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            AlterColumn("dbo.Historicos", "Automovel_AutomovelID", c => c.Int(nullable: false));
            AlterColumn("dbo.Historicos", "Vaga_VagaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Historicos", "Automovel_AutomovelID");
            CreateIndex("dbo.Historicos", "Vaga_VagaID");
            AddForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis", "AutomovelID", cascadeDelete: true);
            AddForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas", "VagaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis");
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            DropIndex("dbo.Historicos", new[] { "Automovel_AutomovelID" });
            AlterColumn("dbo.Historicos", "Vaga_VagaID", c => c.Int());
            AlterColumn("dbo.Historicos", "Automovel_AutomovelID", c => c.Int());
            CreateIndex("dbo.Historicos", "Vaga_VagaID");
            CreateIndex("dbo.Historicos", "Automovel_AutomovelID");
            AddForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas", "VagaID");
            AddForeignKey("dbo.Historicos", "Automovel_AutomovelID", "dbo.Automoveis", "AutomovelID");
        }
    }
}
