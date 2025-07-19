using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventarium.Data
{
    public class Conexao
    {
        private readonly string connectionString;

        public Conexao()
        {
            // Connection string com autenticação do Windows
            connectionString = @"Data Source=PC01\SQLEXPRESS;Initial Catalog=Inventarium;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlConnection AbrirConexao()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message, "Falha na conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
