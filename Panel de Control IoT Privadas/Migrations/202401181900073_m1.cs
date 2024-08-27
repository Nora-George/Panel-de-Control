namespace Panel_de_Control_IoT_Privadas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Correo = c.String(),
                        Contraseña = c.String(),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.Administradors");
        }
    }
}
