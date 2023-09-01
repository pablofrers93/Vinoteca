namespace Vinoteca.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyVentaEntityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventas", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventas", "Estado");
        }
    }
}
