﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    public class RestaurantesXML
    {
        public string NomeArquivo { get; private set; }

        IEnumerable<XElement> restaurantes;

        /// <summary>
        /// Constrói RestaurantesXML a partir de um nome de arquivo.
        /// </summary>
        /// <param name="nomeArquivo">Nome do arquivo XML a ser manipulado</param>
        public RestaurantesXML(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
            restaurantes = XDocument.Load(NomeArquivo).Descendants("restaurante");
        }

        public IList<string> ObterNomes()
        {
            //var resultado = new List<string>();

            //var nodos = restaurantes;

            //foreach (var item in nodos)
            //{
            //    resultado.Add(item.Attribute("nome").Value);
            //}

            //return resultado;

            /*var res = restaurantes
                .Select(n => new Restaurante
                {
                    Nome = n.Attribute("nome").Value,
                    Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value)
                });

            return res.Where(x => x.Capacidade < 100).Select(x => x.Nome).OrderBy(x => x).ToList();
            */

            return (
                from n in restaurantes
                orderby n.Attribute("nome").Value descending
                where Convert.ToInt32(n.Attribute("capacidade").Value) < 100
                select n.Attribute("nome").Value
            ).ToList();
        }

        //public double CapacidadeMedia()
        //{
        //    return (
        //        from n in restaurantes
        //        select Convert.ToInt32(n.Attribute("capacidade").Value)
        //    ).Average();
        //}

        public double CapacidadeMaxima()
        {
            var mad = (
                from n in restaurantes
                select Convert.ToInt32(n.Attribute("capacidade").Value)
            );

            return mad.Max();
        }

        //public IList<Restaurante> AgruparPorCategoria()
        //{
        //    var res = from n in restaurantes
        //              group n by n.Attribute("categoria").Value into g
        //              select new { 
        //                  Categoria = g.Key,
        //                  Restaurantes = g.ToList(),
        //                  SomatorioCapacidades = g.Sum(x => Convert.ToInt32(x.Attribute("capacidade").Value))
        //              };

        //    throw new NotImplementedException();
        //}


     
        //1A - Crie um método que ordene a lista por nome ascendente. Assinatura do método:
         public IList<string> OrdenarPorNomeAsc()
        {
            var res = (
               from n in restaurantes
               orderby n.Attribute("nome").Value 
               select n.Attribute("nome").Value
           ).ToList();

            return res;
        }

        //1B - Crie um método que retorne o Site dos restaurantes (que possuem site). Assinatura do método:
         public IList<string> ObterSites()
         {
             var res = (
                from n in restaurantes.Descendants("contato").Elements("site")
                where n.Value != null
                select n.Value
            ).ToList();

             return res;
         }

        //1C - Crie um método que retorne a capacidade média dos restaurantes. Assinatura do método:
         public double CapacidadeMedia()
         {
             var res = (
                from n in restaurantes
                select Convert.ToInt32(n.Attribute("capacidade").Value)
            ).Average();

             return res;
         }

        //1D - Crie um método que agrupe a lista de restaurantes por categoria. Assinatura do método:
        //OBS: o retorno object é para facilitar, visto que o tipo gerado no group by é anônimo.
        public object AgruparPorCategoria()
         {
            var res = (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                select new
                {
                    Categoria = g.Key,
                    Restaurantes = g.ToList(),
                }).ToList();

            return res;
         }

        //1E- Crie um método que retorne as categorias que têm apenas um restaurante (oportunidade de mercado!). Assinatura do método:

        public IList<Categoria> ApenasComUmRestaurante()
        {
            var res = (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                where g.Count() == 1
                select (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
                ).ToList();

            return res;
        }

        //F - Crie um método que retorne as duas categorias mais populares (acima de 2 restaurantes),
        //ordenadas por quantidade de restaurantes descendente. Assinatura do método:
        public IList<Categoria> ApenasMaisPopulares()
        {
            var res = (
                from n in restaurantes
                group n by n.Attribute("categoria").Value into g
                where g.Count() > 2
                select (Categoria)Enum.Parse(typeof(Categoria), g.Key, ignoreCase: true)
                ).Take(2).ToList();

            return res;
        }


        //2A - Crie um método de instância da classe RestaurantesXML que faça o mapeamento de todos os campos do XML 
        //para o objeto Restaurante. Todas as informações devem ser públicas. Assinatura do método:

        public IEnumerable<Restaurante> TodosRestaurantes()
        {
            return (
                from n in restaurantes
                let contato = n.Element("contato")
                let site = contato != null && contato.Element("site") != null ? contato.Element("site").Value : null
                let telefone = contato != null && contato.Element("telefone") != null ? contato.Element("telefone").Value : null
                let localizacao = n.Element("localizacao")
                select new Restaurante
                {
                    Nome = n.Attribute("nome").Value,
                    Capacidade = Convert.ToInt32(n.Attribute("capacidade").Value),
                    Categoria = (Categoria)Enum.Parse(typeof(Categoria), n.Attribute("categoria").Value, ignoreCase: true),
                    Contato = new Contato
                    {
                        Site = site,
                        Telefone = telefone
                    },
                    Localizacao = new Localizacao
                    {
                        Bairro = localizacao.Element("bairro").Value,
                        Logradouro = localizacao.Element("logradouro").Value,
                        Latitude = Convert.ToDouble(localizacao.Element("latitude").Value),
                        Longitude = Convert.ToDouble(localizacao.Element("longitude").Value)
                    }
                }
            );
        }
    }
}
