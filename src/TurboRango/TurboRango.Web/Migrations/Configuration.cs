namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TurboRango.Dominio;

    internal sealed class Configuration : DbMigrationsConfiguration<TurboRango.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TurboRango.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(TurboRango.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Restaurantes.AddOrUpdate(
              r => r.Nome,
              new Restaurante
                 {
                    Nome = "Tiririca",
                    Capacidade = 50,
                    Categoria = Categoria.Fastfood,
                    Contato = new Contato
                {
                    Site = "http://github.com/tiririca",
                    Telefone = "5555 5555"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Vila Nova",
                    Logradouro = "ERS 239, 2755",
                    Latitude = -29.6646122,
                    Longitude = -51.1188255
                }
            },
            new Restaurante
                 {
                    Nome = "GARFÃO RESTAURANTE E PIZZARIA",
                    Capacidade = 100,
                    Categoria = Categoria.Comum,
                    Contato = new Contato
                {
                    Site = "www.garfao.com",
                    Telefone = "(51) 3587-7700"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Liberdade",
                    Logradouro = "Rua Sete de Setembro, 1045 - Liberdade",
                    Latitude = -29.712571,
                    Longitude = -51.1272292
                }
            },
            new Restaurante
                 {
                    Nome = "OLÉ ARMAZÉM MEXICANO",
                    Capacidade = 30,
                    Categoria = Categoria.CozinhaMexicana,
                    Contato = new Contato
                {
                    Site = "",
                    Telefone = "3279-8828"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Centro",
                    Logradouro = "Rua Gomes Portinho, 448",
                    Latitude = -29.682078,
                    Longitude = -51.125199
                }
            },
            new Restaurante
                 {
                    Nome = "CHURRASCARIA PRIMAVERA",
                    Capacidade = 110,
                    Categoria = Categoria.Churrascaria,
                    Contato = new Contato
                {
                    Site = "www.grupoprimaveranh.com.br",
                    Telefone = "3595-8081"
                },
                Localizacao = new Localizacao
                {
                    Bairro = "Primavera",
                    Logradouro = "BR 116, 2554, Km 31",
                    Latitude = -29.693741,
                    Longitude = -51.144554
                }
            },
            new Restaurante
            {
                Nome = "SUSHI DAI",
                Capacidade = 40,
                Categoria = Categoria.CozinhaJaponesa,
                Localizacao = new Localizacao
                {
                    Logradouro = "Bagé, 149",
                    Bairro = "Boa Vista",
                    Latitude = -29.68942,
                    Longitude = -51.125224
                },
                Contato = new Contato
                    {
                        Site = "",
                        Telefone = ""
                    }
            },
                new Restaurante
                {
                    Nome = "TAKESHI",
                    Capacidade = 35,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Logradouro = "Rua Confraternização, 792",
                        Bairro = "Pátria Nova",
                        Latitude = -29.698669,
                        Longitude = -51.130195
                    },
                    Contato = new Contato
                    {
                        Site = "www.grupoprimaveranh.com.br",
                        Telefone = "3066-6660"
                    }
                },
                new Restaurante
                {
                    Nome = "HAI SAIKÔ",
                    Capacidade = 75,
                    Categoria = Categoria.CozinhaJaponesa,
                    Localizacao = new Localizacao
                    {
                        Logradouro = "Rua Gomes Portinho, 730",
                        Bairro = "Mauá",
                        Latitude = -29.684873,
                        Longitude = -51.122252
                    },
                    Contato = new Contato
                    {
                        Site = "www.haisaiko.com.br",
                        Telefone = "3593-5757"
                    }
                },
                new Restaurante
                {
                    Nome = "PICA-PAU LANCHES",
                    Capacidade = 30,
                    Categoria = Categoria.Fastfood,
                    Localizacao = new Localizacao
                    {
                        Logradouro = "Rua: José do Patrocínio, 880",
                        Bairro = "Rio Branco",
                        Latitude = -29.68339,
                        Longitude = -51.135376
                    },
                    Contato = new Contato
                    {
                        Site = "www.picapaulanches.com",
                        Telefone = "(51) 3593-8079"
                    }
                });
            
        }
    }
}
