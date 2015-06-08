using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    public class Restaurantes
    {
        private string StringDeConexao { get; set; }


        public Restaurantes(string stringDeConexao)
        {

            this.StringDeConexao = stringDeConexao;
        }

        public void Inserir(Restaurante restaurante)
        {
            using (var conexao = new SqlConnection(this.StringDeConexao))
            {
                using (var inserirRestaurante = new SqlCommand("INSERT INTO [dbo].[Restaurante]" +
                    "([Nome],[Capacidade],[Categoria],[IdContato], [IdLocalizacao])" + 
                    "VALUES (@Nome, @Capacidade,@Categoria, @IdContato, @IdLocalizacao); SELECT @@IDENTITY", conexao))
                {

                    inserirRestaurante.Parameters.Add("@Nome", SqlDbType.NVarChar).Value = restaurante.Nome;
                    inserirRestaurante.Parameters.Add("@Capacidade", SqlDbType.Int).Value = restaurante.Capacidade;
                    inserirRestaurante.Parameters.Add("@Categoria", SqlDbType.NVarChar).Value = restaurante.Categoria.ToString();
                    inserirRestaurante.Parameters.Add("@IdContato", SqlDbType.NVarChar).Value = this.InserirContato(restaurante.Contato);
                    inserirRestaurante.Parameters.Add("@IdLocalizacao", SqlDbType.VarChar).Value = this.InserirLocalizacao(restaurante.Localizacao);

                    conexao.Open();
                    int idRestaurante = Convert.ToInt32(inserirRestaurante.ExecuteScalar());


                    Debug.WriteLine("Restaurante criado! id no banco: {0}", idRestaurante);
                }
            }
        }


        internal int InserirContato(Contato contato)
        {
            int idContato;
            using (var conexao = new SqlConnection(this.StringDeConexao))
            {
                using (var inserirContato = new SqlCommand("INSERT INTO [dbo].[Contato]" +
                    "([Site],[Telefone]) VALUES (@Site, @Telefone); SELECT @@IDENTITY", conexao))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site == null ? (Object)DBNull.Value : contato.Site;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Telefone == null ? (Object)DBNull.Value : contato.Telefone;

                    conexao.Open();
                    idContato = Convert.ToInt32(inserirContato.ExecuteScalar());


                    Debug.WriteLine("Contato criado! id no banco: {0}", idContato);
                }
                return idContato;
            }

        }

        internal int InserirLocalizacao(Localizacao localizacao)
        {
            int idLocalizacao;
            using (var conexao = new SqlConnection(this.StringDeConexao))
            {
                using (var inserirLocalizacao = new SqlCommand("INSERT INTO [dbo].[Localizacao]" +
                    "( [Bairro],[Logradouro], [Latitude], [Longitude] )" +
                    "VALUES (@Bairro, @Logradouro, @Latitude, @Longitude); SELECT @@IDENTITY", conexao))
                {
                    inserirLocalizacao.Parameters.Add("@Bairro", SqlDbType.NVarChar).Value = localizacao.Bairro;
                    inserirLocalizacao.Parameters.Add("@Logradouro", SqlDbType.NVarChar).Value = localizacao.Logradouro;
                    inserirLocalizacao.Parameters.Add("@Latitude", SqlDbType.Float).Value = localizacao.Latitude;
                    inserirLocalizacao.Parameters.Add("@Longitude", SqlDbType.Float).Value = localizacao.Longitude;

                    conexao.Open();
                    idLocalizacao = Convert.ToInt32(inserirLocalizacao.ExecuteScalar());


                    Debug.WriteLine("Localizacao criada! id no banco: {0}", idLocalizacao);
                }
                return idLocalizacao;
            }
        }
    }
}