namespace Vinoteca.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyVentaEntityProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventas", "TransaccionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventas", "TransaccionId");
        }
    }
}
