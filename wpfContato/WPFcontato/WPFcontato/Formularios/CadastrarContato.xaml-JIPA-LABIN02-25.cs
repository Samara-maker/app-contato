using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFcontato.RegraDeNegocios;
using WPFcontato.Contexto;
using MySql.Data.MySqlClient;
using System.Windows.Markup;


namespace WPFcontato.Formularios
{
    /// <summary>
    /// Lógica interna para CadastrarContato.xaml
    /// </summary>
    public partial class CadastrarContato : Window
    {
        private MySqlConnection _conexao;
        public CadastrarContato()
        {
            InitializeComponent();
            Conexao();
            tbEMAIL.IsEnabled = false;
            tbNOME.IsEnabled = false;
            tbTELEFONE.IsEnabled = false;
            dtpDataNasc.IsEnabled = false;
            tbSEXO.IsEnabled = false;
            btCANCELAR.IsEnabled = true;
            btSALVAR.IsEnabled = true;
        }
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            tbEMAIL.IsEnabled = true;
            tbNOME.IsEnabled = true;
            tbTELEFONE.IsEnabled = true;
            dtpDataNasc.IsEnabled = true;
            tbSEXO.IsEnabled = true;
            btSALVAR.IsEnabled = true;
            btCANCELAR.IsEnabled = true;
           
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            tbEMAIL.IsEnabled = false;
            tbNOME.IsEnabled = false;
            tbTELEFONE.IsEnabled = false;
            dtpDataNasc.IsEnabled = false;
            tbSEXO.IsEnabled = false;
            btCANCELAR.IsEnabled = false;
            btSALVAR.IsEnabled = false;
         
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {


            try
            {

                var nome = tbNOME.Text;
                var email = tbEMAIL.Text;
                var sexo = tbSEXO.Text;
                var telefone = tbTELEFONE.Text;

                if(dtpDataNasc.SelectedDate !=null)
                {
                    DateTime dataNasc = (DateTime)dtpDataNasc.SelectedDate;

                    var sql = "INSERT INTO contato (nome_con, email_con, sexo_con, telefone_con, data_nasc_con) values (@_nome, @_email, @_sexo, @_telefone, @_data_nasc);";
                    var comando = new MySqlCommand(sql, _conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_data_nasc", dataNasc.ToString("yyyy-mm-dd"));
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("SALVO COM SUCESSO!!!");
                }

               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Ocorreram erros ao salvar as informações! Contate a esquipe de suporte do sistema");
            }

            Cadastramento objcadastramento = new Cadastramento();
            objcadastramento.Email = tbEMAIL.Text;
            objcadastramento.Nome = tbNOME.Text;
            objcadastramento.Telefone = tbTELEFONE.Text;
            objcadastramento.Data = dtpDataNasc;
            objcadastramento.Sexo = tbSEXO.Text;
            DadosContato.lista.Add(objcadastramento);
            tbEMAIL.IsEnabled = false;
            tbNOME.IsEnabled = false;
            tbTELEFONE.IsEnabled = false;
            dtpDataNasc.IsEnabled = false;
            tbSEXO.IsEnabled = false;
            btCANCELAR.IsEnabled = false;
            btSALVAR.IsEnabled = false;
            tbEMAIL.Clear();
            tbNOME.Clear();
            tbTELEFONE.Clear();
            tbSEXO.Clear();

        }

    }
}
