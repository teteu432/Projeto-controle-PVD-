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
    public class ProdutoDao
    {
        private MySqlConnection conexao;
        public ProdutoDao() 
        {
            this.conexao = new ConnectionFactory().getconnection(); 
        }

        #region Método cadastrar produto
        public void cadastrarProduto(Produtos obj)
        {
            try
            {
                //criar sql
                string sql = @"INSERT INTO tb_produtos (descricao, preco, qtd_estoque, for_id) 
                             VALUES(@descricao, @preco, @qtd, @for_id)"; 

                //organizar e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@for_id", obj.for_id);

                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceeu um erro: " + erro);
            }
        }
        #endregion

        #region Método LitarProduto

        public DataTable listarprodutos()
        {
            try
            {
                DataTable tabelaProduto = new DataTable();

                string sql = @"Select p.id as 'Código',
                                      p.descricao as 'Descrição',
                                      p.preco as 'preço',
                                      p.qtd_estoque as 'Qtd Estoque',
                                      f.nome as 'Fornecedor' from tb_produtos as p
                                      join tb_fornecedores as f on (p.for_id = f.id);";


                MySqlCommand executacmd = new MySqlCommand(sql, conexao); //abrir execução
                conexao.Open(); //executar comando
                executacmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaProduto);

                return tabelaProduto;

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
