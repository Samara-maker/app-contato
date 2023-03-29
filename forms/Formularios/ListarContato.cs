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
using ProjetoPDS.RegrasDeNegocio;
using ProjetoPDS.Contexto;
using ProjetoPDS.Formularios;
using System.Management;
using System.Data.Common;

namespace ProjetoPDS.Formularios
{

    public partial class ListarContato : Form
    {

        private MySqlConnection _conexao;

        public ListarContato()
        {
            InitializeComponent();
            Conexao();
            dgv.DataSource = Listar();
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private DataTable Listar()
        {
            string query = "select * from contato";
            var comando = new MySqlCommand(query, _conexao);
            var adaptador = new MySqlDataAdapter(comando);

            DataTable tabela = new DataTable();
            adaptador.Fill(tabela);

            tabela.Columns.Remove("id_con");
            tabela.Columns["nome_con"].ColumnName = "Nome";
            tabela.Columns["sexo_con"].ColumnName = "Sexo";
            tabela.Columns["data_nasc_con"].ColumnName = "Data Nascimento";
            tabela.Columns["email_con"].ColumnName = "Email";
            tabela.Columns["telefone_con"].ColumnName = "Telefone";

            return tabela;
        }

        private void ListarContato_Load(object sender, EventArgs e)
        {

        }
    }
}
