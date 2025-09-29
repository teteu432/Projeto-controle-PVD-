using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_controle_de_Vendas.br.com.projeto.dao;
using Projeto_controle_de_Vendas.br.com.projeto.model;

namespace Projeto_controle_de_Vendas.br.com.Projeto.view
{
    public partial class frmclientes : Form
    {
        public frmclientes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 - receber dados dentro de um obj model client
            Cliente obj = new Cliente();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.celular = txtCelular.Text;
            obj.estado = txtEstado.Text;
            obj.cep = txtCep.Text;

            //2 - Criar obj Class Dao e chamar mtd cadastrarCliente

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarClientes(obj);
            new Helpers().Limpartela(this);
            tabelaCliente.DataSource = dao.listarClientes();




        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmclientes_Load(object sender, EventArgs e)
        {

            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //pegar dados da linha selecionada
            txtCodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            txtEstado.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            tabClientes.SelectedTab = tabPage1;
           // tabelaCliente.DataSource = dao.listarClientes();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botão excluir
            Cliente obj = new Cliente();

            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.excluircliente(obj);
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1 - receber dados dentro de um obj model client
            Cliente obj = new Cliente();
            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.celular = txtCelular.Text;
            obj.estado = txtEstado.Text;
            obj.cep = txtCep.Text;

            obj.codigo = int.Parse(txtCodigo.Text);

            //2 - Criar obj Class Dao e chamar mtd alterar

            ClienteDAO dao = new ClienteDAO();
            dao.alterarClientes(obj);

            //atrualizar tabela
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //pesquisar
            string nome = txtPesquisa.Text;

            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.BuscarClientePorNome(nome);

            if(tabelaCliente.Rows.Count == 0)
            {
                tabelaCliente.DataSource = dao.listarClientes();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            
            ClienteDAO dao = new ClienteDAO();
            
            tabelaCliente.DataSource = dao.ListarClientePorNome(nome);

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //botão de consultar cep
            try
            {

                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/"+cep+"/xml/";
                          
                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtEstado.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado. Digite manualmente");
            }  
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().Limpartela(this);
        }
    }
}
