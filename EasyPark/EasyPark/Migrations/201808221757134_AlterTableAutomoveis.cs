namespace EasyPark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableAutomoveis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Automoveis", "Cliente_ClienteID", c => c.Int());
            CreateIndex("dbo.Automoveis", "Cliente_ClienteID");
            AddForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes", "ClienteID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automoveis", "Cliente_ClienteID", "dbo.Clientes");
            DropIndex("dbo.Automoveis", new[] { "Cliente_ClienteID" });
            DropColumn("dbo.Automoveis", "Cliente_ClienteID");
        }
    }
}
