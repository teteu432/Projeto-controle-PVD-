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
    public partial class frmfuncionarios : Form
    {
        public frmfuncionarios()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //botão salvar
            Funcionario obj = new Funcionario();

            //receber dados

            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.nivel_acesso = txtNivel.Text;
            obj.telefone = txtTelefone.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.celular = txtCelular.Text;
            obj.estado = txtEstado.Text;
            obj.cep = txtCep.Text;
            obj.cargo = txtCargo.Text;

            FuncionarioDao dao = new FuncionarioDao();
            dao.CadastrarFuncionario(obj);
            tabelaFuncionsrio.DataSource = dao.listarFucionarios();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

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

        private void frmfuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDao dao= new FuncionarioDao();   
            tabelaFuncionsrio.DataSource = dao.listarFucionarios();
        }

        private void tabPag2_Click(object sender, EventArgs e)
        {

        }

        private void tabelaFuncionsrio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaFuncionsrio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFuncionsrio.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionsrio.CurrentRow.Cells[1].Value.ToString();
            txtRg.Text = tabelaFuncionsrio.CurrentRow.Cells[2].Value.ToString();
            txtCpf.Text = tabelaFuncionsrio.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionsrio.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tabelaFuncionsrio.CurrentRow.Cells[5].Value.ToString();
            txtCargo.Text = tabelaFuncionsrio.CurrentRow.Cells[6].Value.ToString();
            txtNivel.Text = tabelaFuncionsrio.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = tabelaFuncionsrio.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = tabelaFuncionsrio.CurrentRow.Cells[9].Value.ToString();
            txtCep.Text = tabelaFuncionsrio.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tabelaFuncionsrio.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = tabelaFuncionsrio.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tabelaFuncionsrio.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tabelaFuncionsrio.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tabelaFuncionsrio.CurrentRow.Cells[15].Value.ToString();
            txtEstado.Text = tabelaFuncionsrio.CurrentRow.Cells[16].Value.ToString();
            

            tabFuncionarios.SelectedTab = tabPessoais;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Funcionario obj = new Funcionario();
            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDao dao = new FuncionarioDao();
            dao.deletarFuncionario(obj);

           tabelaFuncionsrio.DataSource = dao.listarFucionarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Editar
            Funcionario obj = new Funcionario();

            //receber dados

            obj.nome = txtNome.Text;
            obj.rg = txtRg.Text;
            obj.cpf = txtCpf.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.nivel_acesso = txtNivel.Text;
            obj.telefone = txtTelefone.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.celular = txtCelular.Text;
            obj.estado = txtEstado.Text;
            obj.cep = txtCep.Text;
            obj.cargo = txtCargo.Text;

            obj.codigo = int.Parse(txtCodigo.Text);
            

            FuncionarioDao dao = new FuncionarioDao();
            dao.alterarFuncionario(obj);
            tabelaFuncionsrio.DataSource = dao.listarFucionarios();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //BTN Pesquisar por nome
            string nome = txtPesquisa.Text;

            FuncionarioDao dao = new FuncionarioDao();
            tabelaFuncionsrio.DataSource= dao.BuscaFucionariosPorNome(nome);

            if (tabelaFuncionsrio.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionário não encontrado");
                tabelaFuncionsrio.DataSource = dao.listarFucionarios();

            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().Limpartela(this);
        }
    }
}
