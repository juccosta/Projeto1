using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmCadastro : Form
    {
        //INSTANCIANDO A CONEXÂO
        Conexao con = new Conexao();
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void dgvCadastro_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            carregarDados();
        }
        //CRIANDO A FUNÇÂO CARREGAR DADOS

        public carregarDados()
        {
            try
            {
                txtNome.Text = dgvCadastro.SelectedRows[0].Cells[0].Value.ToString();
                string sql = "insert into tbProduto(nome)values(@nome)";
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = txtNome.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados Cadastrado com Sucesso");
                con.DesConnectarBD();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }
    }
}
