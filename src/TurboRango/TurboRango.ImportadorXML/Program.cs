using System;
using System.Collections.Generic;
using System.Text;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Exemplos

            Restaurante restaurante = new Restaurante();

            //restaurante.
            //Console.Write(restaurante.Contato.Site);
            Console.WriteLine( 
                restaurante.Capacidade.HasValue ? 
                    restaurante.Capacidade.Value.ToString() : 
                    "oi"
                );

            restaurante.Nome = string.Empty + " ";

            Console.WriteLine(restaurante.Nome ?? "Nulo!!!");

            Console.WriteLine( !string.IsNullOrEmpty(restaurante.Nome.Trim()) ? "tem valor" : "não tem valor" );

            var oQueEuGosto = "bacon";

            var texto = String.Format("Eu gosto de {0}", oQueEuGosto);
            // var texto = String.Format("Eu gosto de \{oQueEuGosto}");

            StringBuilder pedreiro = new StringBuilder();
            pedreiro.AppendFormat("Eu gosto de {0}", oQueEuGosto);
            pedreiro.Append("!!!!!!");

            object obj = "1";
            int a = Convert.ToInt32(obj);
            int convertido = 10;
            bool conseguiu = Int32.TryParse("1gdfgfd", out convertido);
            int res = 12 + a;

            Console.WriteLine(pedreiro);

            #endregion

            #region Exercicios
            const string nomeArquivo = "restaurantes.xml";

            var restaurantesXML = new RestaurantesXML(nomeArquivo);
            var nomes = restaurantesXML.ObterNomes();
            var capacidadeMedia = restaurantesXML.CapacidadeMedia();
            var capacidadeMaxima = restaurantesXML.CapacidadeMaxima();
            var porCategoria = restaurantesXML.AgruparPorCategoria();
            var porNomeAsc = restaurantesXML.OrdenarPorNomeAsc();
            var sites = restaurantesXML.ObterSites();
            var comUmRest = restaurantesXML.ApenasComUmRestaurante();
            var maisPop = restaurantesXML.ApenasMaisPopulares();
            var todosRest = restaurantesXML.TodosRestaurantes();
            #endregion  

            #region ADO.NET

            var connString = @"Data Source=rodrigo\sqlexpress;Initial Catalog=TurboRango_dev;Integrated Security=True"; //Integrated Security=True - quando usar autenticacao windows

            var acessoAoBanco = new CarinhaQueManipulaOBanco(connString);

            acessoAoBanco.Inserir(new Contato
                {
                    Site = "www.dogao.gif",
                    Telefone = "51 9135-4040"
                });

            IEnumerable<Contato> contatos = acessoAoBanco.GetContato();

            #endregion
        }
    }
}
