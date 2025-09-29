using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Projeto_controle_de_Vendas.br.com.projeto.conexao;
using Projeto_controle_de_Vendas.br.com.projeto.model;

namespace Projeto_controle_de_Vendas.br.com.projeto.dao
{
    public class FornecedorDao
    {
        private MySqlConnection conexao;
        
        public FornecedorDao()
        {
            this.conexao = new ConnectionFactory().getconnection();


        }

        #region MÉTODO CADASTRAR FORNECEDOR

        public void cadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"INSERT INTO tb_fornecedores 
                (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                 VALUES (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);

                //3 passo - open conexao e exec cmd sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso");


            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO" + erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        #endregion

        #region Método listar fornecedor
        public DataTable listarFornecedor()
        {
            try
            {
                DataTable tabelaFornecedor = new DataTable();

                string sql = "Select * from tb_fornecedores";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally { conexao.Close(); }
        }

        #endregion

        #region Buscarfornecedor

        public DataTable BuscarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelaFornecedor = new DataTable();

                string sql = "Select * from tb_clientes where nome = @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFornecedor);

                return tabelaFornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally { conexao.Close(); }
        }

        #endregion

        #region alterarfornecedor ok
        public void alterarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"update tb_fornecedores 
                (nome, cnpj, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                 VALUES (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);

                //3 passo - open conexao e exec cmd sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso");


            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO" + erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        #endregion

        #region ExcluirFornecedor ok
        public void excluirfornecedor(Cliente obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"delete from tb_fornecedores where id = @id";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - open conexao e exec cmd sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor Exluido com sucesso");


            }
            catch (Exception erro)
            {

                MessageBox.Show("ERRO" + erro);
            }
            finally
            {
                conexao.Close();
            }
        }
        #endregion

        #region listar por nome ok

        public DataTable ListarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                string sql = "Select * from tb_fornecedores where nome like @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                return tabelafornecedor;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally { conexao.Close(); }
        }

        #endregion
    }
}
