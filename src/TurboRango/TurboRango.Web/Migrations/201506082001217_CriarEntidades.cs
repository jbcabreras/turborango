namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarEntidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacidade = c.Int(),
                        Nome = c.String(),
                        Contato_Site = c.String(),
                        Contato_Telefone = c.String(),
                        Localizacao_Bairro = c.String(),
                        Localizacao_Latitude = c.Double(nullable: false),
                        Localizacao_Longitude = c.Double(nullable: false),
                        Localizacao_Logradouro = c.String(),
                        Categoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurantes");
        }
    }
}
