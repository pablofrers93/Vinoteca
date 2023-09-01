namespace Vinoteca.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarritoEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carritos",
                c => new
                    {
                        ItemCarritoId = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        UserName = c.String(),
                        NombreProducto = c.String(),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemCarritoId);          
        }
        
        public override void Down()
        {
            DropTable("dbo.Carritos");
        }
    }
}
