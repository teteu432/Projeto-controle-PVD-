using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx;
using Projeto_controle_de_Vendas.br.com.projeto.conexao;
using Projeto_controle_de_Vendas.br.com.projeto.model;

namespace Projeto_controle_de_Vendas.br.com.projeto.dao
{
    public class FuncionarioDao
    {
        private MySqlConnection conexao;
        public FuncionarioDao()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region cadastrar Funcionario

        public void CadastrarFuncionario(Funcionario obj)
        {
            try
            {

                string sql = "insert into tb_funcionarios (nome,rg,cpf,email, senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado) " +
                   "values (@nome, @rg, @cpf, @email, @senha, @cargo, @nivel_acesso, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //organizar cmd sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario cadastrado com sucesso");

            }
            catch (Exception erro)
            {

                MessageBox.Show("aconteceu um erro: " + erro);
            }
            finally
            {
                conexao.Close();
            }
        }




        #endregion

        #region Método alteral funcionario

        public void alterarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "update tb_funcionarios set nome=@nome, rg=@rg, cpf=@cpf, email=@email, senha=@senha, cargo=@cargo, nivel_acesso=@nivel_acesso, telefone=@telefone, celular=@celular, " +
              "cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado " +
             "where id=@Codigo";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivel_acesso", obj.nivel_acesso);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@Codigo", obj.codigo);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario alterado cadastrado com sucesso");
            }
            catch (Exception)
            {

                MessageBox.Show("Aconteceu o erro");
                
            } 
            finally
            {
                conexao.Close();
            }
                
          
        }

        #endregion

        #region Método Excluir funcionario

        public void deletarFuncionario(Funcionario obj)
        {
            try
            {
                string sql = "delete from tb_funcionarios where id = @id";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);


                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario excluido com sucesso");
            }
            catch (Exception)
            {

                MessageBox.Show("Aconteceu um erro");
                
            }
            finally
            { conexao.Close(); }
        }

        #endregion

        #region Listar Funcionários
        public DataTable listarFucionarios()
        {
            try
            {
                DataTable tabelaFuncionario = new DataTable();

                string sql = "Select * from tb_funcionarios";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

            #endregion

        #region Método listar por nome

            public DataTable BuscaFucionariosPorNome(string nome)
        {
            try
            {
                DataTable tabelaFuncionario = new DataTable();

                string sql = "Select * from tb_funcionarios where nome = @nome";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaFuncionario);

                return tabelaFuncionario;

            }
            catch (Exception erro)
            {

                MessageBox.Show("erro ao executar o comando Sql: " + erro);
                return null;
            }
            finally
            {
                conexao.Close();
            }

            #endregion


        }
    }
}
