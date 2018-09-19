namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TirarTag : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            AlterColumn("dbo.Historicos", "Vaga_VagaID", c => c.Int());
            CreateIndex("dbo.Historicos", "Vaga_VagaID");
            AddForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas", "VagaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas");
            DropIndex("dbo.Historicos", new[] { "Vaga_VagaID" });
            AlterColumn("dbo.Historicos", "Vaga_VagaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Historicos", "Vaga_VagaID");
            AddForeignKey("dbo.Historicos", "Vaga_VagaID", "dbo.Vagas", "VagaID", cascadeDelete: true);
        }
    }
}
