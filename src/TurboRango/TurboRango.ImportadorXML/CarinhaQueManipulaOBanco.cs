using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRango.Dominio;

namespace TurboRango.ImportadorXML
{
    class CarinhaQueManipulaOBanco
    {
        private string connectionString;
        public CarinhaQueManipulaOBanco(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal void Inserir(Contato contato)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "insert into [dbo].[Contato] ([Site], [Telefone]) values (@Site, @Telefone)";
                using (var inserirContato = new SqlCommand(comandoSql, connection))
                {
                    inserirContato.Parameters.Add("@Site", SqlDbType.NVarChar).Value = contato.Site;
                    inserirContato.Parameters.Add("@Telefone", SqlDbType.NVarChar).Value = contato.Site;

                    connection.Open();
                    int resultado = inserirContato.ExecuteNonQuery();
                }
            }
        }

        internal IEnumerable<Contato> GetContato()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                string comandoSql = "select [Site], [Telefone] from [dbo].[Contato] (nolock)";
                using (var lerContato = new SqlCommand(comandoSql, connection))
                {

                    connection.Open();

                    var reader = lerContato.ExecuteReader();

                    while (reader.Read())
                    {
                        string site = reader.GetString(0);
                        string telefone = reader.GetString(1);
                    }
                }
            }

            return null;
        }
    }
}
