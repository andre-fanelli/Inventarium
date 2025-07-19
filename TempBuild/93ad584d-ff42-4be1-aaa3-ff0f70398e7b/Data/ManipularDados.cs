using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Inventarium.Models;
using Inventarium.Data;

namespace Inventarium.Data
{
    public class ManipularDados
    {
        private readonly Conexao? conexao;

        public ManipularDados()
        {
            conexao = new Conexao();
        }

        Mensagens mensagem = new();

        public void InserirPC(string unidade, string depto, string processador, int ram, int storage, string hostname, string fabricante, string modelo, string ns, string patrimonio, string so)
        {
            
            string query = @"INSERT INTO cadPC (Unidade, Depto, Processador, RAM, Storage, Hostname, Fabricante, Modelo, NS, Patrimonio, SO, TenantId) VALUES  (@Unidade, @Depto, @Processador, @RAM, @Storage, @Hostname, @Fabricante, @Modelo, @NS, @Patrimonio, @SO, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new (query, conn))
            {
                    // Adiciona os parâmetros para evitar SQL Injection
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Processador", processador);
                cmd.Parameters.AddWithValue("@RAM", ram);
                cmd.Parameters.AddWithValue("@Storage", storage);
                cmd.Parameters.AddWithValue("@Hostname", hostname);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@SO", so);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
      
        }

        public void InserirNotebook(string unidade, string depto, string processador, int ram, int storage, string hostname, string fabricante, string modelo, string ns, string patrimonio, string so)
        {

            string query = @"INSERT INTO cadNote (Unidade, Depto, Processador, RAM, Storage, Hostname, Fabricante, Modelo, NS, Patrimonio, SO, TenantId) VALUES  (@Unidade, @Depto, @Processador, @RAM, @Storage, @Hostname, @Fabricante, @Modelo, @NS, @Patrimonio, @SO, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Processador", processador);
                cmd.Parameters.AddWithValue("@RAM", ram);
                cmd.Parameters.AddWithValue("@Storage", storage);
                cmd.Parameters.AddWithValue("@Hostname", hostname);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@SO", so);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void InserirMonitor(string unidade, string depto, string fabricante, string modelo, string ns, string patrimonio)
        {

            string query = @"INSERT INTO cadMonitor (Unidade, Depto, Fabricante, Modelo, NS, Patrimonio, TenantId) VALUES  (@Unidade, @Depto, @Fabricante, @Modelo, @NS, @Patrimonio, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void InserirImpressora(string unidade, string depto, string fabricante, string modelo, string tipo, string ns, string patrimonio)
        {

            string query = @"INSERT INTO cadImpressora (Unidade, Depto, Fabricante, Modelo, Tipo, NS, Patrimonio, TenantId) VALUES  (@Unidade, @Depto, @Fabricante, @Modelo, @Tipo, @NS, @Patrimonio, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void InserirAtivoRede(string unidade, string depto, string fabricante, string modelo, string tipo, string ns, string patrimonio)
        {

            string query = @"INSERT INTO cadRede (Unidade, Depto, Fabricante, Modelo, Tipo, NS, Patrimonio, TenantId) VALUES  (@Unidade, @Depto, @Fabricante, @Modelo, @Tipo, @NS, @Patrimonio, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Tipo", tipo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void InserirTablet(string unidade, string depto, string fabricante, string modelo, string ns, string patrimonio)
        {

            string query = @"INSERT INTO cadTablet (Unidade, Depto, Fabricante, Modelo, NS, Patrimonio, TenantId) VALUES  (@Unidade, @Depto, @Fabricante, @Modelo, @NS, @Patrimonio, @TenantId)";

            using (SqlConnection conn = conexao.AbrirConexao())
            using (SqlCommand cmd = new(query, conn))
            {
                cmd.Parameters.AddWithValue("@Unidade", unidade);
                cmd.Parameters.AddWithValue("@Depto", depto);
                cmd.Parameters.AddWithValue("@Fabricante", fabricante);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@NS", ns);
                cmd.Parameters.AddWithValue("@Patrimonio", patrimonio);
                cmd.Parameters.AddWithValue("@TenantId", AppConfig.TenantId);

                try
                {
                    cmd.ExecuteNonQuery();
                    mensagem.Sucesso();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
