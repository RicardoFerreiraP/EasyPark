namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automoveis", new[] { "Cliente_ClienteID" });
            AlterColumn("dbo.Automoveis", "Placa", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Automoveis", "Cliente_ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Automoveis", "Cliente_ClienteID");
            AddForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes", "ClienteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automoveis", new[] { "Cliente_ClienteID" });
            AlterColumn("dbo.Automoveis", "Cliente_ClienteID", c => c.Int());
            AlterColumn("dbo.Automoveis", "Placa", c => c.String(nullable: false));
            CreateIndex("dbo.Automoveis", "Cliente_ClienteID");
            AddForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
    }
}
