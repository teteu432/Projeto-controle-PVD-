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
    public class ClienteDAO
    {
        private MySqlConnection conexao;
        public ClienteDAO() 
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region CadastrarCliente Ok
        public void cadastrarClientes(Cliente obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"INSERT INTO tb_clientes 
                (nome, rg, cpf, email, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado) 
                 VALUES (@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente cadastrado com sucesso");


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

        #region AlterarCliente ok

        public void alterarClientes(Cliente obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"update tb_clientes set
nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone,  celular=@celular, cep=@cep, endereco=@endereco,
numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado WHERE id=@id";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - open conexao e exec cmd sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Alterado com sucesso!");


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

        #region excluirCliente ok

        public void excluircliente(Cliente obj)
        {
            try
            {
                //1 passo- definir cmd sql
                string sql = @"delete from tb_clientes where id = @id";
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - open conexao e exec cmd sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente Exluido com sucesso");


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

        #region ListarClientes ok
        public DataTable listarClientes()
        {
            try
            {
                DataTable tabelacliente = new DataTable();

                string sql = "Select * from tb_clientes";

                
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                return tabelacliente;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally { conexao.Close(); } 
        }
        #endregion

        #region BuscarClientePorNome ok

        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                DataTable tabelacliente = new DataTable();

                string sql = "Select * from tb_clientes where nome = @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                return tabelacliente;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally { conexao.Close(); }
        }

        #endregion

        #region ListarClientePorNome

        public DataTable ListarClientePorNome(string nome)
        {
            try
            {
                DataTable tabelacliente = new DataTable();

                string sql = "Select * from tb_clientes where nome like @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                return tabelacliente;

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